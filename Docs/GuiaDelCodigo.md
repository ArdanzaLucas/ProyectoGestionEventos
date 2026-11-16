# Guía del código: avances, capas y POO

Esta guía explica cómo está armado el proyecto hoy, a partir del código real. Sirve para entender qué hace cada capa, cómo están escritos los métodos y qué conceptos de programación orientada a objetos (POO) aparecen. También marca dónde el diseño todavía no cumple del todo esa teoría.

Otros documentos:
- [FlujoDeDatos.md](FlujoDeDatos.md): el recorrido de los datos paso a paso y cómo funciona cada pantalla.
- [ReglasDeNegocio.md](ReglasDeNegocio.md): todas las reglas y validaciones.
- [UML.md](UML.md): el diagrama de clases y el esquema de la base ([UML.drawio](UML.drawio), para abrir con draw.io).

**La idea principal:** cada capa tiene un solo trabajo y solo le habla a la de al lado. La pantalla pide, el Service decide, el Model calcula y valida, y el Repository guarda.

---

## 1. Qué se hizo últimamente

| Avance | Qué agregó | Estado |
|---|---|---|
| **Catering** | CRUD de menús y etiquetas. Cada menú tiene precio por adulto y por niño, y varias etiquetas | Subido (`0812869`) |
| **Eventos** | CRUD de eventos con cliente y fecha. Al borrar un evento se borran sus presupuestos | Subido (`511de63`) |
| **Presupuestos e Inicio** | Modelo, servicio y repositorio propios, y la pantalla para armarlos: cálculos, estados, clonado y validaciones | Subido (`287a4af`) |
| **Vista previa y PDF** | `FormReport` muestra la hoja, y `QuotePdf` la dibuja y la guarda con "Microsoft Print to PDF" | Subido (`3d8604a`) |
| **Ajustes de diseño** | Carpeta `Common`, excepción propia, reglas en los `set`, `MessageHelper` y un repositorio por service | Subido (`3d8604a`) |
| **Presupuestos congelados** | El presupuesto guarda su propia copia de los datos del evento, nombres y precios | Subido (`3d8604a`) |
| **Base de datos** | `SqliteDatabase` crea `Data/presupuestos.db` con todas las tablas | Sin subir, probado |
| **Repositorios SQLite** | Los seis repositorios guardan en la base. Los datos quedan al cerrar la app | Sin subir, probado |
| **Datos de prueba** | `MockData` carga ubicaciones, servicios, etiquetas, menús y eventos, solo si la base está vacía | Sin subir, probado |
| **Validaciones nuevas** | Nombres y eventos repetidos, topes de duración, invitados, precios, decimales y texto, eventos pasados, salón ocupado y cambios en eventos con presupuesto Aceptado | Sin subir, probado |
| **`Validator`** | Una clase con las validaciones que se repetían en los `set` del modelo | Sin subir, probado |
| **Campos numéricos** | Los formularios usan `NumericUpDown` en lugar de cuadros de texto para los números | Sin subir, en prueba |
| **Ideas de otro proyecto** | Mensaje ante errores inesperados, `NotFoundException`, id sin `set` público, horarios calculados en `Quote`, guía en las listas vacías y datos de prueba solo en Debug | Sin subir, en prueba |
| **Validaciones ordenadas** | Ningún constructor valida, todas las asignaciones pasan por las propiedades y algunas reglas pasan al Service | Sin subir, en prueba |

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
  Repository     Traduce el Model a SQL y al reves
    |   SQL
    v
  SQLite         El archivo Data/presupuestos.db
```

| Carpeta | Qué hace | Qué **no** hace |
|---|---|---|
| [View](../View) | Muestra datos, lee los controles y arma los DTO | Calcular totales o decidir reglas |
| [Controller](../Controller) | Recibe el pedido de la pantalla y crea el Service | Decidir algo: hoy solo pasa el pedido |
| [Service](../Service) | Aplica las reglas entre varios objetos y convierte entre DTO y Model. Solo usa su propio repositorio | Conocer los controles de la pantalla |
| [Model](../Model) | Representa el negocio, valida sus propios datos y hace sus cálculos | Saber dónde se guarda |
| [Repository](../Repository) | Agrega, busca, actualiza y borra en la base. Acá está también `SqliteDatabase` | Aplicar reglas |
| [Dto](../Dto) | Lleva datos entre la pantalla y el Service | Tener reglas: solo hay algún texto armado, como `DisplayName` |
| [Interface](../Interface) | `IRepository<T>`: los métodos que todo repositorio debe tener | Tener implementación |
| [Common](../Common) | Lo que usan varias capas: `EstadoPresupuesto`, `BusinessRuleException`, `NotFoundException` y `Validator` | Tener lógica de negocio propia de una entidad |
| [Mock](../Mock) | Datos de prueba para una base vacía. Solo se cargan al ejecutar en Debug | Formar parte del programa final |

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
    set { _price = Validator.requirePrice(value, "el precio de la ubicacion"); }
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

Los constructores no validan nada: solo asignan, y siempre a través de las propiedades. Así cada dato pasa por la validación de su `set`, y no hay una forma de crear el objeto que la saltee.

Cuando una regla necesita dos datos juntos, hay dos casos:
- **Si se puede revisar en el `set`**, va ahí. El máximo de 10000 invitados se revisa en el `set` de adultos sumando los niños, y al revés. Funciona en cualquier orden, porque el otro dato arranca en 0.
- **Si no se puede**, va en el Service. "Al menos un invitado" no puede ir en un `set`, porque al cargar los adultos los niños todavía valen 0. Lo revisa `EventItemService` antes de guardar.

### Validator: las validaciones que se repetían

[Validator](../Common/Validator.cs) es una clase estática con tres métodos. Cada uno revisa el valor, lanza la excepción si está mal y, si está bien, lo devuelve para guardarlo:

| Método | Qué revisa | Dónde se usa |
|---|---|---|
| `requireText(value, mensaje)` | Que no esté vacío y que tenga hasta 50 caracteres. Lo devuelve sin espacios en los extremos | Nombres y descripciones |
| `requirePrice(value, nombre)` | Entre 0 y 1000000000, con 2 decimales como máximo | Precios de ubicaciones, servicios y menús |
| `requireQuantity(value, nombre)` | Entre 0 y 10000 | Invitados y cantidades de platos |

```csharp
public static decimal requirePrice(decimal value, string nombre)
{
    if (value < 0)
    {
        throw new BusinessRuleException(nombre + " no puede ser negativo");
    }
    if (value > 1000000000)
    {
        throw new BusinessRuleException(nombre + " no puede ser mayor a 1000000000");
    }
    if (decimal.Round(value, 2) != value)
    {
        throw new BusinessRuleException(nombre + " no puede tener mas de 2 decimales");
    }
    return value;
}
```

Las reglas propias de un dato siguen en su clase, como la duración máxima de un evento.

### Repository: siempre los mismos cinco métodos

Cada repositorio implementa `addToRepository`, `getAll`, `getById`, `update` y `removeById`, y es un *singleton*: hay una sola instancia, que se pide con `getInstance()`. Cada método abre una conexión, ejecuta su SQL y la cierra al salir del `using`:

```csharp
public void addToRepository(Ubication ubication)
{
    using (SqliteConnection connection = database.getConnection())
    {
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO UBICATION (Name, Price, IsActive) VALUES (@name, @price, @isActive); SELECT last_insert_rowid();";
        command.Parameters.AddWithValue("@name", ubication.Name);
        command.Parameters.AddWithValue("@price", ubication.Price);
        command.Parameters.AddWithValue("@isActive", ubication.IsActive);
        ubication.Id = Convert.ToInt32(command.ExecuteScalar());
    }
}
```

- **Parámetros (`@name`):** los valores nunca se pegan dentro del texto del SQL. Así un nombre con comillas no rompe la consulta.
- **Lectura:** cada repositorio tiene un método privado, como `readUbication(reader)`, que arma un objeto del Model con una fila de la base.
- **No encontrado:** si `getById` no encuentra el id, lanza `NotFoundException` en lugar de devolver `null`. Así ningún service tiene que acordarse de revisar el `null`.
- **El id:** después del `INSERT`, el repositorio se lo pasa al objeto con `assignId(id)`, porque `Id` no tiene `set` público.
- **Transacciones:** `MenuRepository` y `QuoteRepository` guardan varias tablas a la vez (el menú y sus etiquetas, o el presupuesto y sus líneas). Lo hacen dentro de una transacción, para que no quede nada a medias si algo falla.
- **`SqliteDatabase`:** es el otro singleton. Sabe dónde está el archivo, crea las tablas al arrancar y entrega las conexiones con las claves foráneas activadas.

### Service: reglas y conversiones

`toModel` y `toDto` traducen entre los dos mundos. Los demás métodos siguen el mismo orden: convertir, validar, calcular y guardar.

```csharp
public void addQuote(QuoteDto dto)
{
    Quote quote = toModel(dto);

    validateEventNotPast(quote.EventDate, "crear");
    validateQuote(quote, null);

    quote.calculateTotals();
    repository.addToRepository(quote);
}
```

Cada service guarda su repositorio en un atributo del tipo de la **interfaz**, y lo pide una sola vez en el constructor:

```csharp
private IRepository<Quote> repository;

public QuoteService()
{
    repository = QuoteRepository.getInstance();
}
```

El resto del service solo conoce `IRepository<Quote>`: no sabe que los datos están en SQLite. Si mañana se quisiera guardar en memoria o en otra base, alcanzaría con cambiar esa línea del constructor.

Cada service usa solo su repositorio. Si necesita un objeto de otra entidad, se lo pide a ese service con un método que los controllers no llaman:

```csharp
// en UbicationService
public Ubication getModelById(int id)
{
    return repository.getById(id);
}

// en QuoteService.toModel
UbicationService ubicationService = new UbicationService();
Ubication ubication = ubicationService.getModelById(dto.UbicationId);
```

Las reglas que necesitan mirar otros datos guardados van en métodos privados con nombre `validate...`, como `validateUniqueName`, `validateUbicationFree` o `validateScheduleChange`.

### Controller: una línea de trabajo

```csharp
public void addQuote(QuoteDto dto)
{
    QuoteService service = new QuoteService();
    service.addQuote(dto);
}
```

### View: leer, pedir y recargar

Los campos numéricos son `NumericUpDown`, así que no aceptan letras y el formulario ya no tiene que convertir texto. El formulario arma el DTO, llama al controller y, si una regla no se cumple, muestra el aviso:

```csharp
private void btnGuardarUbicacion_Click(object sender, EventArgs e)
{
    decimal price = decimal.Round(nudUbicationPrice.Value, 2);

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

El `decimal.Round` está porque el control muestra 2 decimales pero por dentro guarda los que se escribieron. Así se guarda lo mismo que se ve.

Cuatro convenciones se repiten en todos los formularios:
- `idEditando` vale 0 si se está creando, o el id si se está editando.
- `fila.Tag = dto` guarda el DTO completo en la fila, para recuperarlo al seleccionarla.
- `reloadMtlv()` vuelve a pedir los datos y redibuja la lista.
- Todos los avisos pasan por `MessageHelper`: `showWarning`, `showError`, `showInfo` y `confirm`.

---

## 4. Cómo se mueven los datos

El recorrido completo, con cada pantalla, está en [FlujoDeDatos.md](FlujoDeDatos.md). Acá va el resumen.

### Guardar un dato simple: una ubicación

```
FormUbications     lee los campos y arma  UbicationDto("Salon", 50000)
      |
UbicationController.addToRepository(dto)
      |
UbicationService   toModel(dto)  ->  new Ubication(...), y sus set validan
      |            validateUniqueName(...)  no puede haber otra activa con ese nombre
      |
UbicationRepository   INSERT en la base, que le asigna el id
      |
FormUbications     reloadMtlv() pide la lista de nuevo
```

### Mostrar datos: el camino inverso

```
UbicationRepository.getAll()        SELECT de las activas, y un Ubication por fila
      |
UbicationService.getUbications()    usa toDto() con cada una
      |
UbicationController                 List<UbicationDto>
      |
FormUbications                      una fila por DTO
```

La baja lógica la decide el Service con `deactivate()`. La ubicación sigue guardada, pero el `getAll()` del Repository filtra con `WHERE IsActive = 1` y no la trae. Los presupuestos viejos la siguen encontrando con `getById`, que trae activas e inactivas.

### Guardar un presupuesto: el caso completo

La pantalla manda solo **ids y cantidades**. El Service busca los objetos reales y completa el resto.

```
FormIndex          buildQuoteDto(): id de evento, id de ubicacion, lineas y servicios
      |
QuoteController.addQuote(dto)
      |
QuoteService.addQuote(dto)
      |-- toModel(dto)               pide EventItem, Ubication, Menu y OptionItem a sus services
      |                              el presupuesto y sus lineas copian los datos actuales
      |-- validateEventNotPast(...)  el evento no puede haber pasado
      |-- validateQuote(...)         lineas repetidas, etiqueta del menu, elementos de baja
      |-- quote.calculateTotals()    el Model hace la cuenta con sus copias
      |
QuoteRepository.addToRepository(quote)    el presupuesto y sus lineas, en una transaccion
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

El Model y el Service no conocen la pantalla, y por eso se pueden probar o reutilizar sin ella. Además, el `catch` atrapa solo `BusinessRuleException`: un error de programación no se muestra como si fuera una regla.

Hay dos casos más:
- **`NotFoundException`** hereda de `BusinessRuleException`, así que los formularios la atrapan con el mismo `catch` y muestran su mensaje, como "no se encontro el presupuesto".
- **Un error que no es de reglas**, como la base bloqueada, lo atrapa `Program.cs` con `Application.ThreadException`. Muestra "ocurrio un error inesperado" con `MessageHelper.showError`, en lugar de cerrar la app.

### Datos de prueba

`MockData.load()` se llama al arrancar, solo al ejecutar en Debug (`#if DEBUG`), y solo carga si no hay ubicaciones, servicios, etiquetas, menús ni eventos en la base. Carga todo a través de los **Controllers**, igual que un formulario, así que los datos pasan por todas las validaciones. Para sacarlo, se borra la carpeta `Mock` y la llamada en `Program.cs`, sin tocar las demás capas.

---

## 5. La teoría de POO en este código

### Encapsulamiento

Cada objeto protege sus datos y expone solo lo necesario.

| Ejemplo | Qué protege |
|---|---|
| `set` que validan, como `Price` | El objeto no puede quedar con un dato inválido |
| `IsActive` con `private set`, que se cambia con `deactivate()` | Solo se puede dar de baja de la forma prevista |
| `Id` con `private set`, que se asigna con `assignId(id)` | El id se asigna una sola vez: si el objeto ya tiene uno, `assignId` lanza un error |
| `State` con `private set`, que se cambia con `accept()` y `cancel()` | El estado solo cambia por los caminos permitidos |
| Todas las propiedades de `Quote`, `EventItem`, `Ubication`, `OptionItem`, `Menu`, `MenuTag`, `DetailMenu` y `DetailOptionItem` con `private set` | Solo se cargan en los constructores (y en `calculateTotals()` para los totales de `Quote`). En `Quote`, la ubicación y las listas no pueden ser nulas, y en las líneas, el menú o el servicio |
| `Quote.accept()` y `cancel()` | Lanzan un error si el presupuesto no está Pendiente |
| `calculateTotals()` | Si ya no está Pendiente, no cambia nada: queda congelado |
| Constructor privado de los repositorios y de `SqliteDatabase` | Nadie puede crear una segunda instancia |
| `private FormReport formReport` | Cada formulario guarda sus controles y datos para sí |

Hay seis constructores que existen solo para leer de la base:
- `Quote(id, estado, datos del evento, ubicación, nombre y precio, líneas, servicios, totales)` recibe todas las copias guardadas y permite armar un presupuesto Aceptado o Cancelado, que de otra forma solo nacería Pendiente. No recalcula ni compara con los datos actuales.
- `Ubication(id, name, price, isActive)` permite armar una ubicación dada de baja sin llamar después a `deactivate()`.
- `OptionItem(id, name, price, isActive)` hace lo mismo con un servicio dado de baja.
- `DetailMenu(menu, menuDescription, tagDescription, adultos, niños, precioAdulto, precioNiño)` recibe la descripción y los precios guardados de la línea, en lugar de copiar los actuales del menú.
- `DetailOptionItem(optionItem, optionItemName, unitPrice)` hace lo mismo con el nombre y el precio guardados del servicio.
- `Menu(..., isActive)` permite armar un menú dado de baja. Usa las propiedades como los demás. La regla "al menos una etiqueta" la revisa `MenuService` al crear y editar, no el `set` de `TagList`: un menú dado de baja puede quedar sin etiquetas si se borró la única que tenía, y así se puede leer igual.

### Abstracción

Quien usa un objeto sabe qué hace, no cómo lo hace.
- `FormIndex` llama a `quoteController.acceptQuote(id)` sin saber qué se valida.
- `FormReport` llama a `pdf.save(ruta)` sin saber cómo se escribe un PDF.
- `IRepository<T>` describe qué hace un repositorio, sin decir dónde guarda. Por eso, al pasar de listas en memoria a SQLite, cambió solo el interior de cada repositorio: los Services, Controllers y pantallas no se tocaron.

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
| **Implementación de una interfaz** | Los seis repositorios implementan `IRepository<T>`, y los services los usan a través de ella (`private IRepository<Ubication> repository`) |
| **Genéricos** | `IRepository<Quote>`, `List<DetailMenu>`: el mismo código para distintos tipos |
| **Sobrecarga** | `Ubication` tiene un constructor con id y otro sin id. `Quote` y `Menu` suman uno para leer de la base |
| **Sobrescritura** | `protected override void Dispose(...)` en los Designer |

### Principios de diseño

- **Responsabilidad única:** `QuotePdf` solo dibuja y guarda la hoja, y `FormReport` solo la muestra. `MessageHelper` solo muestra avisos, y `Validator` solo valida.
- **Bajo acoplamiento:** la pantalla no conoce los repositorios ni la base. Por eso se pudo pasar a SQLite sin tocarla.
- **Alta cohesión:** el cálculo de un presupuesto está en `Quote`, no repartido entre formularios.
- **No repetirse:** el dibujo de la hoja existe una sola vez, y las validaciones comunes están en `Validator`.
- **Patrón Singleton:** los repositorios y `SqliteDatabase`.
- **Patrón DTO:** objetos solo para transportar datos entre capas.
- **Eventos:** `btnImprimir.Click += btnImprimir_Click` y `printDocument.PrintPage += ...`. El objeto avisa que pasó algo, sin conocer a quien lo escucha.

---

## 6. Dónde la teoría se cumple a medias

Esto no impide que el programa funcione, pero conviene conocerlo para explicar bien el diseño.

| Qué pasa | Por qué importa | Cuándo mirarlo |
|---|---|---|
| **Las tablas se crean solo si no existen** | Si se agrega una columna, una base que ya existe no la toma sola. Habría que borrarla o modificarla a mano | Al cambiar el esquema |
| **La ruta de `Data` se calcula subiendo tres carpetas desde el ejecutable** | Funciona desde Visual Studio, pero en una app publicada apuntaría a otro lugar | Si se publica la app |
| Los Controllers solo pasan el pedido | Hoy agregan poco. Dan un punto de entrada único, pero la capa es casi un trámite | Es una decisión de diseño |
| `FormIndex` tiene más de 600 líneas | Maneja la lista y también la carga, así que tiene más de una responsabilidad | Mejora opcional |
| `FormIndex` y `FormReport` se conocen entre sí, igual que `FormMenus` y `FormMenuTags` | Es simple, pero genera dependencia en los dos sentidos | Bajo impacto |
| `EventItemService` y `QuoteService` se llaman entre sí, igual que `MenuService` y `MenuTagService` | Hoy no da problemas, porque cada service se crea dentro del método, pero hay dependencia en los dos sentidos | Bajo impacto |
| `getModelById` es público, y los Services son `internal` | Lo decidimos así para no pasar repositorios ajenos. Los Controllers no deben llamarlo, pero el compilador no lo impide | Bajo impacto |
| Quedan algunos controles en los formularios: elegir fila o combo, "al menos un plato" antes de agregar una línea, y "solo se puede editar un pendiente" | Evitan abrir un panel o armar una línea que igual se rechazaría. Las dos últimas repiten una regla del modelo | Se pueden revisar |
| Los `NumericUpDown` corrigen sin avisar | Un valor fuera de rango pasa al tope al salir del campo, y un precio sin tocar se guarda en 0 | Es una decisión de diseño |

**Sobre la arquitectura:** esto es una arquitectura **en capas** con nombres parecidos a MVC, no un MVC estricto. En MVC clásico, el Controller toma decisiones; acá las toma el Service.

---

## 7. Orden para leer el código

1. **Módulo simple, de abajo hacia arriba:** [BusinessRuleException.cs](../Common/BusinessRuleException.cs) → [Validator.cs](../Common/Validator.cs) → [Ubication.cs](../Model/Ubication.cs) → [UbicationDto.cs](../Dto/UbicationDto.cs) → [SqliteDatabase.cs](../Repository/SqliteDatabase.cs) → [UbicationRepository.cs](../Repository/UbicationRepository.cs) → [UbicationService.cs](../Service/UbicationService.cs) → [UbicationController.cs](../Controller/UbicationController.cs) → [FormUbications.cs](../View/FormUbications.cs).
2. **Relación entre objetos:** [Menu.cs](../Model/Menu.cs), [MenuRepository.cs](../Repository/MenuRepository.cs), que guarda las etiquetas en otra tabla, y [MenuTagService.cs](../Service/MenuTagService.cs), que revisa los menús antes de borrar una etiqueta.
3. **El negocio completo:** [Quote.cs](../Model/Quote.cs) → [DetailMenu.cs](../Model/DetailMenu.cs) → [QuoteService.cs](../Service/QuoteService.cs) → [QuoteRepository.cs](../Repository/QuoteRepository.cs).
4. **La pantalla más grande:** [FormIndex.cs](../View/FormIndex.cs).
5. **Lo último:** [MessageHelper.cs](../View/MessageHelper.cs) → [QuotePdf.cs](../View/QuotePdf.cs) → [FormReport.cs](../View/FormReport.cs) → [FormMain.cs](../FormMain.cs) → [Program.cs](../Program.cs), para ver cómo se arma todo.

### Para comprobar si se entendió

Probá contestar estas preguntas mirando el código:
- ¿Por qué `DetailMenu` copia la descripción y el precio en vez de leerlos siempre de `Menu`?
- ¿Por qué `validateQuote` está en el Service y `Subtotal` en el Model?
- Al pasar a SQLite, ¿qué archivos cambiaron y cuáles no se tocaron? ¿Por qué?
- Si un presupuesto se acepta dos veces, ¿qué clase lo impide y cómo llega el mensaje a la pantalla?
- ¿Por qué `QuoteRepository` arma el presupuesto con un constructor distinto al que usa `QuoteService`?
