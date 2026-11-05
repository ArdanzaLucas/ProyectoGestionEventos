# Guía del código: avances, capas y POO

Esta guía explica cómo está armado el proyecto hoy, a partir del código real. Sirve para entender qué hace cada capa, cómo viajan los datos y qué conceptos de programación orientada a objetos (POO) aparecen. También marca dónde el diseño todavía no cumple del todo esa teoría.

Para las reglas de negocio está [ReglasDeNegocio.md](ReglasDeNegocio.md), y para los diagramas de clases, [UML.md](UML.md).

**La idea principal:** cada capa tiene un solo trabajo y solo le habla a la de al lado. La pantalla pide, el Service decide, el Model calcula y el Repository guarda.

---

## 1. Qué se hizo últimamente

| Avance | Qué agregó | Estado |
|---|---|---|
| **Catering** | CRUD de menús y etiquetas. Cada menú tiene precio por adulto y por niño, y varias etiquetas | Subido (`0812869`) |
| **Eventos** | CRUD de eventos con cliente y fecha. Al borrar un evento se borran sus presupuestos | Subido (`511de63`) |
| **Presupuestos** | Modelo, servicio y repositorio propios: cálculos, estados, clonado y validaciones | Subido (`287a4af`) |
| **Inicio** | Lista con filtro por evento y panel para armar presupuestos | Subido (`287a4af`) |
| **Títulos y reinicio** | Título en cada lista. Al entrar a una pestaña, vuelve a la lista y recarga los datos | Subido (`287a4af`) |
| **PDF** | `QuotePdf` dibuja la hoja y la guarda con "Microsoft Print to PDF" | Sin subir |
| **Datos de prueba** | `MockData` carga ubicaciones, servicios, etiquetas, menús y eventos al abrir el programa | Sin subir, es provisorio |
| **Vista previa** | `FormReport` muestra la hoja, con los botones Imprimir y Volver | Sin subir, en prueba |
| **Ajustes de diseño** | Carpeta `Common`, excepción propia, reglas en los `set`, `MessageHelper` y un repositorio por service | Sin subir, en prueba |
| **Presupuestos congelados** | El presupuesto guarda su propia copia de los datos del evento, nombres y precios | Sin subir, en prueba |

---

## 2. Las capas

```
  View           Formularios: muestran datos y reciben clics
    |   DTO
    v
  Controller     Puerta de entrada: le pasa el pedido al Service
    |   DTO
    v
  Service        Reglas de negocio. Convierte DTO <-> Model
    |   Model
    v
  Repository     Guarda y busca objetos (hoy en una lista, despues en SQLite)
```

| Carpeta | Qué hace | Qué **no** hace |
|---|---|---|
| [View](../View) | Muestra datos, lee lo que se escribe y convierte el texto a número | Calcular totales o decidir reglas |
| [Controller](../Controller) | Recibe el pedido de la pantalla y crea el Service | Decidir algo: hoy solo pasa el pedido |
| [Service](../Service) | Aplica las reglas entre varios objetos y convierte entre DTO y Model. Solo usa su propio repositorio | Conocer los controles de la pantalla |
| [Model](../Model) | Representa el negocio, valida sus propios datos y hace sus cálculos | Saber dónde se guarda |
| [Repository](../Repository) | Agrega, busca, actualiza y borra | Aplicar reglas |
| [Dto](../Dto) | Lleva datos entre la pantalla y el Service | Tener reglas: solo hay algún texto armado, como `DisplayName` |
| [Interface](../Interface) | `Irepository<T>`: los métodos que todo repositorio debe tener | Tener implementación |
| [Common](../Common) | Lo que usan todas las capas: `EstadoPresupuesto` y `BusinessRuleException` | Tener lógica de negocio |

Por qué hay un **Model** y un **DTO** de lo mismo:
- `Quote` (Model) tiene comportamiento (`accept()`, `calculateTotals()`) y referencias a otros objetos, como su `Ubication`.
- `QuoteDto` solo tiene datos planos listos para mostrar, como `UbicationName` o `TotalGuests`. Así la pantalla no puede llamar a `accept()` por su cuenta ni modificar el objeto guardado.

---

## 3. Cómo están escritos los métodos

### Model: propiedades y comportamiento

Los atributos son privados y se accede a ellos con propiedades. Hay tres formas, según lo que haga falta:

```csharp
// 1. un set que protege el dato
public decimal Price
{
    get { return _price; }
    set
    {
        if (value < 0)
        {
            throw new BusinessRuleException("el precio de la ubicacion no puede ser negativo");
        }
        _price = value;
    }
}

// 2. sin set: solo cambia con un metodo
public bool IsActive
{
    get { return _isActive; }
}

public void deactivate()
{
    _isActive = false;
}

// 3. propiedad calculada: no guarda nada, hace la cuenta al pedirla
public decimal Subtotal
{
    get { return _unitPriceAdult * _adultQuantity + _unitPriceChild * _childQuantity; }
}
```

Cuando una regla necesita dos datos juntos, va en el constructor, porque en el `set` de uno todavía no está cargado el otro. Por ejemplo, `EventItem` revisa ahí que haya al menos un invitado.

### Repository: siempre los mismos cinco métodos

Cada repositorio implementa `addToRepository`, `getAll`, `getById`, `update` y `removeById`. Durante el desarrollo es un *singleton*: hay una sola instancia, y por eso todos ven la misma lista.

```csharp
public static UbicationRepository getInstance()
{
    if (instance == null)
    {
        instance = new UbicationRepository();
    }
    return instance;
}
```

### Service: reglas y conversiones

`toModel` y `toDto` traducen entre los dos mundos. Los demás métodos siguen el mismo orden: convertir, validar, calcular y guardar.

```csharp
public void addQuote(QuoteDto dto)
{
    Quote quote = toModel(dto);
    EventItem eventItem = getEventItem(quote.EventItemId);

    validateQuote(quote, null);

    quote.calculateTotals(eventItem.Duration);
    QuoteRepository.getInstance().addToRepository(quote);
}
```

Cada service usa solo su repositorio. Si necesita un objeto de otra entidad, se lo pide a ese service con un método que los controllers no llaman:

```csharp
// en UbicationService
public Ubication getModelById(int id)
{
    return UbicationRepository.getInstance().getById(id);
}

// en QuoteService.toModel
UbicationService ubicationService = new UbicationService();
Ubication ubication = ubicationService.getModelById(dto.UbicationId);
```

### Controller: una línea de trabajo

```csharp
public void addQuote(QuoteDto dto)
{
    QuoteService service = new QuoteService();
    service.addQuote(dto);
}
```

### View: leer, convertir, pedir y recargar

El formulario solo revisa lo que el modelo no puede recibir: un texto que no es un número. Lo demás lo decide el modelo, y el formulario muestra el aviso.

```csharp
private void btnGuardarUbicacion_Click(object sender, EventArgs e)
{
    decimal price;
    if (!decimal.TryParse(mtbUbicationPrice.Text, out price))
    {
        MessageHelper.showWarning("ingrese un precio valido");
        return;
    }

    UbicationDto ubicationDto = new UbicationDto(mtbUbicationName.Text, price);

    try
    {
        if (idEditando == 0)
        {
            ubicationController.addToRepository(ubicationDto);
        }
        else
        {
            ubicationController.updateUbication(idEditando, ubicationDto);
        }
    }
    catch (BusinessRuleException ex)
    {
        MessageHelper.showWarning(ex.Message);
        return;
    }

    reloadMtlv();
    btnVolverAtras_Click(sender, e);
}
```

Tres convenciones se repiten en todos los formularios:
- `idEditando` vale 0 si se está creando, o el id si se está editando.
- `fila.Tag = dto` guarda el DTO completo en la fila, para recuperarlo al seleccionarla.
- `reloadMtlv()` vuelve a pedir los datos y redibuja la lista.
- Todos los avisos pasan por `MessageHelper`: `showWarning`, `showError`, `showInfo` y `confirm`.

---

## 4. Cómo se mueven los datos

### Guardar un dato simple: una ubicación

```
FormUbications     lee los campos y arma  UbicationDto("Salon", 50000)
      |
UbicationController.addToRepository(dto)
      |
UbicationService   toModel(dto)  ->  new Ubication(...), y sus set validan
      |
UbicationRepository   le asigna el id y la agrega a la lista
      |
FormUbications     reloadMtlv() pide la lista de nuevo
```

### Mostrar datos: el camino inverso

```
UbicationRepository.getAll()        List<Ubication>
      |
UbicationService.getUbications()    deja solo las activas y usa toDto()
      |
UbicationController                 List<UbicationDto>
      |
FormUbications                      una fila por DTO
```

La baja lógica se resuelve en el Service: la ubicación sigue guardada, pero no se devuelve.

### Guardar un presupuesto: el caso completo

La pantalla manda solo **ids y cantidades**. El Service busca los objetos reales y completa el resto.

```
FormIndex          armarQuoteDto(): id de evento, id de ubicacion, lineas y servicios
      |
QuoteController.addQuote(dto)
      |
QuoteService.addQuote(dto)
      |-- toModel(dto)          pide EventItem, Ubication, Menu y OptionItem a sus services
      |                         el presupuesto y sus lineas copian los datos actuales
      |-- validateQuote(...)    revisa las reglas V7, V8, V12 y V15
      |-- quote.calculateTotals()    el Model hace la cuenta con sus copias
      |
QuoteRepository.addToRepository(quote)
```

El presupuesto guarda su propia copia de los datos del evento, los nombres y los precios. Por eso no cambia si después se modifica un evento, un salón, un menú o un servicio. Solo un Pendiente toma los datos actuales, y únicamente al editarlo y guardarlo.

### Cuando una regla no se cumple

El error viaja hacia arriba, de la capa que lo detecta hasta la pantalla que lo muestra:

```csharp
// QuoteService: detecta el problema
throw new BusinessRuleException("el evento ya tiene un presupuesto aceptado");

// FormIndex: lo muestra
try
{
    quoteController.acceptQuote(selected.Id);
}
catch (BusinessRuleException ex)
{
    MessageHelper.showWarning(ex.Message);
}
```

El Model y el Service no conocen la pantalla, y por eso se podrían probar o reutilizar sin ella. Además, el `catch` atrapa solo `BusinessRuleException`: un error de programación no se muestra como si fuera una regla.

### Vista previa y PDF

```
FormIndex (boton Detalle)     toma el QuoteDto de la fila, que ya trae todas sus copias
      |
FormReport.showQuote(...)     crea QuotePdf y le da su PrintDocument a la vista previa
      |
QuotePdf                      printDocument_PrintPage dibuja la hoja
      |
FormReport (boton Imprimir)   pdf.save(ruta) dibuja la misma hoja en un archivo
```

Como las dos salidas usan el mismo dibujo, lo que se ve es lo que se guarda.

### Datos de prueba

`MockData` carga todo a través de los **Controllers**, igual que un formulario. Para sacarlo se borra la carpeta `Mock` y la llamada en `Program.cs`, sin tocar las demás capas.

---

## 5. La teoría de POO en este código

### Encapsulamiento

Cada objeto protege sus datos y expone solo lo necesario.

| Ejemplo | Qué protege |
|---|---|
| `set` que validan, como `Price` | El objeto no puede quedar con un dato inválido |
| `IsActive` sin `set`, con `deactivate()` | Solo se puede dar de baja de la forma prevista |
| `State` sin `set`, con `accept()` y `cancel()` | El estado solo cambia por los caminos permitidos |
| `Quote.accept()` y `cancel()` | Lanzan un error si el presupuesto no está Pendiente |
| `calculateTotals()` | Si ya no está Pendiente, no cambia nada: queda congelado |
| Constructor privado del repositorio | Nadie puede crear una segunda instancia |
| `private FormReport formReport` | Cada formulario guarda sus controles y datos para sí |

### Abstracción

Quien usa un objeto sabe qué hace, no cómo lo hace.
- `FormIndex` llama a `quoteController.acceptQuote(id)` sin saber qué se valida.
- `FormReport` llama a `pdf.save(ruta)` sin saber cómo se escribe un PDF.
- `Irepository<T>` describe qué hace un repositorio, sin decir dónde guarda. Por eso, en la etapa 9, debería cambiar solo el interior de cada repositorio.

### Composición y asociación

Es la relación que más se usa en el proyecto: los objetos se arman con otros objetos.

```
Quote  ---tiene--->  List<DetailMenu>         las lineas nacen y mueren con el presupuesto
Quote  ---tiene--->  List<DetailOptionItem>
DetailMenu  --usa-->  Menu                    el menu existe por su cuenta
Menu   ---tiene--->  List<MenuTag>            las etiquetas existen por su cuenta
Quote  ---guarda-->  EventItemId              referencia por id, y copia los datos del evento
FormMain ---tiene-->  FormIndex, FormEvents, ...
```

El cálculo muestra cómo colaboran: `Quote.calculateTotals` le pide a cada línea su `Subtotal`. Cada objeto resuelve la parte que le corresponde.

### Herencia

Se usa solo donde la da el framework:
- `FormReport : Form` hereda todo lo que hace ser una ventana.
- `FormMain : MaterialForm` hereda el estilo de MaterialSkin.
- `BusinessRuleException : Exception` es la única herencia escrita por nosotros: "es una" excepción, así que se puede lanzar y atrapar como cualquier otra.

Entre las clases del negocio **no hay herencia**, y está bien: un `Quote` no "es un" `Menu`, sino que "tiene" menús. Es el criterio conocido como *preferir composición sobre herencia*.

### Polimorfismo

| Forma | Dónde aparece |
|---|---|
| **Implementación de una interfaz** | Los seis repositorios implementan `Irepository<T>` |
| **Genéricos** | `Irepository<Quote>`, `List<DetailMenu>`: el mismo código para distintos tipos |
| **Sobrecarga** | `Ubication` tiene un constructor con id y otro sin id |
| **Sobrescritura** | `protected override void Dispose(...)` en los Designer |

### Principios de diseño

- **Responsabilidad única:** `QuotePdf` solo dibuja y guarda la hoja, y `FormReport` solo la muestra. `MessageHelper` solo muestra avisos.
- **Bajo acoplamiento:** la pantalla no conoce los repositorios, así que cambiar cómo se guarda no debería afectarla. Tampoco usa nada de la carpeta `Model`.
- **Alta cohesión:** el cálculo de un presupuesto está en `Quote`, no repartido entre formularios.
- **No repetirse:** el dibujo de la hoja existe una sola vez.
- **Patrón Singleton:** los repositorios, de forma provisoria.
- **Patrón DTO:** objetos solo para transportar datos entre capas.
- **Eventos:** `btnImprimir.Click += btnImprimir_Click` y `printDocument.PrintPage += ...`. El objeto avisa que pasó algo, sin conocer a quien lo escucha.

---

## 6. Dónde la teoría se cumple a medias

Esto no impide que el programa funcione, pero conviene conocerlo para explicar bien el diseño.

| Qué pasa | Por qué importa | Cuándo mirarlo |
|---|---|---|
| **`update` de los repositorios no copia `IsActive`.** Hoy la baja funciona porque `getById` devuelve el mismo objeto de la lista | Al pasar a SQL, si no se guarda ese dato, **las bajas lógicas se perderían** | **Etapa 9, sin falta** |
| **`Quote.State` no tiene `set`** y `QuoteRepository.update` no lo copia | Es lo correcto hoy, pero al leer de la base hay que poder crear un presupuesto Aceptado | **Etapa 9:** agregar un constructor con estado |
| `getAll()` devuelve la lista interna | Quien la recibe podría modificarla sin pasar por el repositorio | Desaparece con SQL |
| Los Services usan la clase concreta: `UbicationRepository.getInstance()` | La interfaz funciona como contrato, pero no hay polimorfismo real: no se puede cambiar un repositorio por otro sin tocar el Service | Mejora opcional |
| Los Controllers solo pasan el pedido | Hoy agregan poco. Dan un punto de entrada único, pero la capa es casi un trámite | Es una decisión de diseño |
| `FormIndex` tiene más de 600 líneas | Maneja la lista y también la carga, así que tiene más de una responsabilidad | Mejora opcional |
| `FormIndex` y `FormReport` se conocen entre sí, igual que `FormMenus` y `FormMenuTags` | Es simple, pero genera dependencia en los dos sentidos | Bajo impacto |
| `EventItemService` y `QuoteService` se llaman entre sí, igual que `MenuService` y `MenuTagService` | Hoy no da problemas, porque cada service se crea dentro del método, pero hay dependencia en los dos sentidos | Bajo impacto |
| `getModelById` es público, y los Services son `internal` | Lo decidimos así para no pasar repositorios ajenos. Los Controllers no deben llamarlo, pero el compilador no lo impide | Bajo impacto |
| Quedan algunos controles en los formularios: elegir fila o combo, "al menos un plato" antes de agregar una línea, y "solo se puede editar un pendiente" | Evitan abrir un panel o armar una línea que igual se rechazaría. Las dos últimas repiten una regla del modelo | Se pueden revisar |

**Sobre la arquitectura:** esto es una arquitectura **en capas** con nombres parecidos a MVC, no un MVC estricto. En MVC clásico, el Controller toma decisiones; acá las toma el Service.

---

## 7. Orden para leer el código

1. **Módulo simple, de abajo hacia arriba:** [BusinessRuleException.cs](../Common/BusinessRuleException.cs) → [Ubication.cs](../Model/Ubication.cs) → [UbicationDto.cs](../Dto/UbicationDto.cs) → [UbicationRepository.cs](../Repository/UbicationRepository.cs) → [UbicationService.cs](../Service/UbicationService.cs) → [UbicationController.cs](../Controller/UbicationController.cs) → [FormUbications.cs](../View/FormUbications.cs).
2. **Relación entre objetos:** [Menu.cs](../Model/Menu.cs) y [MenuTagService.cs](../Service/MenuTagService.cs), que revisa los menús antes de borrar una etiqueta.
3. **El negocio completo:** [Quote.cs](../Model/Quote.cs) → [DetailMenu.cs](../Model/DetailMenu.cs) → [QuoteService.cs](../Service/QuoteService.cs).
4. **La pantalla más grande:** [FormIndex.cs](../View/FormIndex.cs).
5. **Lo último:** [MessageHelper.cs](../View/MessageHelper.cs) → [QuotePdf.cs](../View/QuotePdf.cs) → [FormReport.cs](../View/FormReport.cs) → [FormMain.cs](../FormMain.cs), para ver cómo se arma todo.

### Para comprobar si se entendió

Probá contestar estas preguntas mirando el código:
- ¿Por qué `DetailMenu` copia la descripción y el precio en vez de leerlos siempre de `Menu`?
- ¿Por qué `validateQuote` está en el Service y `Subtotal` en el Model?
- ¿Qué archivos habría que cambiar para guardar en SQLite, y cuáles no deberían tocarse?
- Si un presupuesto se acepta dos veces, ¿qué clase lo impide y cómo llega el mensaje a la pantalla?
