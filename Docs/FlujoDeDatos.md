# Flujo de datos y pantallas

Este texto explica cómo se crean los datos, cómo viajan entre las capas y qué hace cada pantalla, a partir del código actual. Las reglas de negocio completas están en [ReglasDeNegocio.md](ReglasDeNegocio.md), y los diagramas de clases, en [UML.md](UML.md).

**La idea en una frase:** la pantalla arma un DTO con lo que escribió el usuario, el Service lo convierte en un objeto del Model que se valida solo, y el Repository lo guarda en SQLite. Para mostrar, el camino es el mismo pero al revés.

---

## 1. Las capas y qué viaja entre ellas

```
  View           formularios: leen los controles y muestran listas
    |   DTO
    v
  Controller     puerta de entrada: le pasa el pedido al Service
    |   DTO
    v
  Service        reglas entre varios objetos. Convierte DTO <-> Model
    |   Model
    v
  Repository     traduce el Model a SQL y al reves
    |   SQL
    v
  SQLite         el archivo Data/presupuestos.db
```

Entre la pantalla y el Service viajan **DTO**, y entre el Service y el Repository viajan objetos del **Model**. Ningún objeto del Model llega a la pantalla.

| | DTO (carpeta `Dto`) | Model (carpeta `Model`) |
|---|---|---|
| **Para qué sirve** | Llevar datos de una capa a otra | Representar el negocio |
| **Qué tiene** | Datos planos, listos para mostrar: `UbicationName`, `TotalGuests` | Datos, validaciones y comportamiento: `accept()`, `calculateTotals()` |
| **Cómo nombra a otros objetos** | Por **id**: `UbicationId`, `MenuId` | Por **objeto**: `Ubication`, `Menu` |
| **Valida algo** | No | Sí, en sus `set`. Los constructores solo asignan a través de las propiedades |
| **Quién lo crea** | La pantalla, o el Service con `toDto` | El Service con `toModel`, o el Repository al leer la base |

Así la pantalla no puede llamar a `accept()` por su cuenta ni cambiar un objeto guardado sin pasar por las reglas.

### Quién crea cada pieza

| Pieza | Quién la crea | Cuántas hay |
|---|---|---|
| Formularios | `FormMain`, al cargar | Uno de cada uno, toda la vida del programa |
| Controllers | `FormMain`, en su constructor, y se los pasa a cada formulario | Uno de cada uno |
| Services | Cada método del Controller hace `new XService()` | Uno nuevo por pedido |
| Repositories | Su propio `getInstance()`, que cada Service llama en su constructor y guarda como `IRepository<T>` | Uno solo (singleton) |
| `SqliteDatabase` | Su `getInstance()`, al arrancar | Uno solo (singleton) |
| Conexión a la base | `SqliteDatabase.getConnection()` | Una por consulta, se cierra al terminar |

---

## 2. El arranque

```
Program.Main()
  |-- Application.ThreadException    un error inesperado muestra un mensaje en vez de cerrar la app
  |-- SqliteDatabase.getInstance()   crea Data/presupuestos.db y las tablas si no existen
  |-- MockData.load()                solo en Debug: si la base esta vacia, carga datos de prueba
  '-- Application.Run(new FormMain())
        |-- constructor: crea los 6 controllers
        '-- FormMain_Load: crea los formularios, los mete en cada pestaña
                           y le pasa a cada uno los controllers que usa
```

- **`MockData`** carga los datos de prueba usando los Controllers, igual que lo haría un formulario. Por eso esos datos pasan por todas las validaciones.
- **Pestañas:** `FormMain.TabCtrl_SelectedIndexChanged` llama a `resetView()` del formulario de la pestaña elegida. Así, cada vez que entrás a una pestaña, vuelve a la lista y la recarga desde la base. Por eso un cambio hecho en otra pestaña se ve enseguida.

---

## 3. Cómo nace un dato: crear una ubicación

Es el camino más simple, y todos los demás formularios siguen el mismo.

```
FormUbications.btnGuardarUbicacion_Click
  |   lee mtbUbicationName y nudUbicationPrice
  |   arma  new UbicationDto("Salon", 50000)        sin id: todavia no existe
  v
UbicationController.addToRepository(dto)           solo crea el service y le pasa el dto
  v
UbicationService.addToRepository(dto)
  |-- toModel(dto)  ->  new Ubication("Salon", 50000)
  |                     sus set validan: Validator.requireText y requirePrice
  |-- validateUniqueName(...)                      no puede haber otra activa igual
  v
UbicationRepository.addToRepository(ubication)
  |   INSERT INTO UBICATION ...; SELECT last_insert_rowid();
  '   la base asigna el id y el repositorio se lo pasa con assignId(id)
  v
FormUbications
  |-- reloadMtlv()            vuelve a pedir la lista
  '-- btnVolverAtras_Click    vuelve a la lista y limpia los campos
```

Tres cosas a tener en cuenta:
- **Las validaciones están en dos lugares.** Las de un solo dato van en los `set` del Model: un texto vacío o un precio negativo. Las que necesitan mirar otros objetos van en el Service: un nombre repetido o un salón ocupado.
- **Editar es igual que crear.** Si `idEditando` no es 0, el formulario llama a `updateUbication(idEditando, dto)`. El Service arma un objeto nuevo con `toModel`, valida, y el repositorio hace un `UPDATE` con ese id.
- **El id lo pone la base**, nunca la pantalla. Por eso el DTO de un dato nuevo se crea sin id.

---

## 4. Cómo vuelve a la pantalla: mostrar la lista

```
UbicationRepository.getAll()
  |   SELECT Id, Name, Price, IsActive FROM UBICATION WHERE IsActive = 1
  |   readUbication() arma un Ubication por fila
  v   List<Ubication>
UbicationService.getUbications()
  |   convierte cada una con toDto()
  v   List<UbicationDto>
UbicationController.getUbications()
  v   List<UbicationDto>
FormUbications.reloadMtlv()
      una fila por DTO, y guarda el DTO entero en fila.Tag
```

**`fila.Tag`:** cada fila de la lista guarda su DTO completo. Al tocar Editar o Eliminar, el formulario lo recupera con `(UbicationDto)fila.Tag` y ya tiene el id y los datos, sin volver a consultar la base.

---

## 5. Cuando una regla no se cumple

El error sube desde la capa que lo detecta hasta la pantalla, que es la única que lo muestra.

```
Validator.requirePrice()      throw new BusinessRuleException("el precio de la ubicacion no puede ser negativo")
  ^  sube por
Ubication.Price (set)  ->  UbicationService  ->  UbicationController
  ^  lo atrapa
FormUbications                catch (BusinessRuleException ex)
                              MessageHelper.showWarning(ex.Message)
                              return;   no recarga ni vuelve a la lista
```

- **El Model y el Service no conocen la pantalla.** Solo lanzan la excepción con el mensaje.
- **El formulario atrapa solo `BusinessRuleException`.** Un error de programación no se muestra como si fuera una regla, y así se nota.
- **Todos los avisos pasan por `MessageHelper`:** `showWarning`, `showError`, `showInfo` y `confirm`, para que se vean siempre iguales.
- **Si no existe:** cuando un repositorio no encuentra un id, lanza `NotFoundException`. Como hereda de `BusinessRuleException`, el formulario la muestra igual que cualquier regla.
- **Errores inesperados:** un error que no es de reglas, como la base bloqueada, lo atrapa `Program.cs` y muestra "ocurrio un error inesperado", sin cerrar la app.

---

## 6. Cómo se lee un presupuesto de la base

Un presupuesto es el único dato que se arma con otros objetos, y además guarda **copias congeladas** de lo que tenía al guardarse.

```
QuoteRepository.getById(id)
  |-- SELECT ... FROM QUOTE WHERE Id = @id
  |-- UbicationRepository.getById(UbicationId)          la ubicacion real
  |-- loadDetailMenus()        una fila de DETAIL_MENU por linea
  |       MenuRepository.getById(MenuId)                el menu real
  |       new DetailMenu(menu, ...) con la descripcion y los precios
  |       guardados, usando el constructor de lectura
  |-- loadDetailOptionItems()  igual, con OptionItemRepository
  '-- new Quote(id, estado, datos del evento, ubicacion, nombre y precio,
      lineas, servicios, totales): el constructor de lectura recibe
      todas las copias guardadas de una vez
```

Después, `QuoteService.toDto` arma el `QuoteDto` **solo con las copias**. Por eso un presupuesto no cambia si después se modifica el salón, un menú, un servicio o el evento.

Los objetos reales (`Ubication`, `Menu`, `OptionItem`) se usan solo para saber sus ids, revisar si están dados de baja y clonar.

---

## 7. Las pantallas

Todas las pantallas de carga siguen el mismo esquema:
- **Dos paneles:** uno con la lista y los botones Crear, Editar y Eliminar, y otro con los campos de carga. Los botones muestran uno y esconden el otro.
- **`idEditando`:** vale 0 si se está creando, o el id del registro si se está editando.
- **Volver:** esconde la carga, muestra la lista, limpia los campos y pone `idEditando` en 0.
- **Campos numéricos:** son `NumericUpDown`, así que no aceptan letras y corrigen solos los valores fuera de rango. El formulario lee `Value` sin tener que convertir texto.
- **Lista vacía:** `VisualHelper.showEmptyMessage` muestra una guía, como "Todavia no hay ubicaciones. Toque Crear para agregar una.", y la esconde cuando hay filas.
- **Doble clic:** en cualquier lista, hace lo mismo que el botón Editar.
- **Sin ids a la vista:** las listas no muestran el id; cada fila guarda su DTO en `Tag`, y de ahí sale el id para editar o eliminar. Solo Inicio muestra el N° del presupuesto, porque es el que figura en el PDF.
- **Tamaño de la ventana:** se puede agrandar o maximizar. `VisualHelper.fitColumns` reparte el ancho de las columnas en proporción a su ancho original, sin achicarlas por debajo de ese ancho, y `VisualHelper.centerContent` mantiene centrados los campos de carga.
- **Labels:** son `MaterialLabel`, con la Roboto que trae MaterialSkin. Los títulos usan `H6`, los campos `Body1`, las secciones `Subtitle2`, y los textos de ayuda van en gris (`HighEmphasis = false`).

### Ubicaciones (`FormUbications`) y Servicios adicionales (`FormOptionItem`)

Las dos son iguales: nombre y precio.

| Acción | Qué viaja | Qué pasa |
|---|---|---|
| **Crear o editar** | `UbicationDto(nombre, precio)` | Visto en la sección 3 |
| **Eliminar** | Solo el id | Pide confirmación. El Service busca el objeto, llama a `deactivate()` y lo guarda con `update`: es una **baja lógica**, el registro sigue en la base con `IsActive = 0` |
| **Lista** | `List<UbicationDto>` | Solo los activos |

La baja lógica existe porque los presupuestos viejos siguen apuntando a esa ubicación o servicio.

### Eventos (`FormEvents`)

Campos: nombre, cliente, fecha y hora, adultos, niños y duración.

| Acción | Qué viaja | Qué pasa |
|---|---|---|
| **Crear** | `EventItemDto(...)` sin id | El Service rechaza una fecha anterior a hoy y un evento repetido (mismo nombre, cliente y día). El Service también revisa que haya al menos un invitado. El Model revisa los textos y los topes |
| **Editar** | El mismo DTO y `idEditando` | Si el evento tiene un presupuesto Aceptado, `validateScheduleChange` no deja cambiar fecha, hora ni duración. El nombre, el cliente y los invitados sí |
| **Eliminar** | Solo el id | Antes de confirmar, el formulario pide `countQuotes(id)` para avisar cuántos presupuestos se borran. El Service borra primero los presupuestos con `QuoteService.removeQuotesByEventItem` y después el evento. Es un **borrado físico** |

Acá dos services colaboran: `EventItemService` le pide a `QuoteService` lo que tiene que ver con presupuestos, en vez de tocar `QuoteRepository` directamente.

### Catering: menús (`FormMenus`) y etiquetas (`FormMenuTags`)

Los dos formularios están en la misma pestaña. El botón **Etiquetas** esconde `FormMenus` y muestra `FormMenuTags`, y su botón Volver hace lo contrario y recarga los menús, por si cambió alguna etiqueta.

**Menús:** descripción, precio por adulto, precio por niño y etiquetas, elegidas con casillas.

```
FormMenus.btnGuardarMenu_Click
  |   las casillas marcadas son MenuTagDto: se juntan en una lista
  |   new MenuDto(descripcion, precioAdulto, precioNino, etiquetas)
  v
MenuService.toModel(dto)
  |   por cada MenuTagDto le pide a MenuTagService.getModelById(id) el MenuTag real
  |   new Menu(..., tags)
  |   validateHasTags(menu)   exige al menos una etiqueta
  v
MenuRepository.addToRepository(menu)
      en una transaccion: INSERT INTO MENU, y una fila de MENU_MENU_TAG por etiqueta
```

- **Etiquetas por id:** del `MenuTagDto` solo se usa el id. La descripción la trae el objeto real.
- **Baja:** eliminar un menú es una baja lógica, igual que en ubicaciones.

**Etiquetas:** solo tienen descripción, que no se puede repetir.

| Acción | Qué pasa |
|---|---|
| **Crear o editar** | `MenuTagDto(descripcion)`. El Service rechaza una repetida sin importar mayúsculas |
| **Eliminar** | Si algún menú activo quedaría sin etiquetas, no se borra. Lo controla `MenuTagService.removeMenuTag`, y el formulario lo revisa antes con `getMenusWithOnlyThisTag(id)` para avisar sin pedir confirmación. Si no, confirma con `countMenusUsing(id)` y borra. Es un **borrado físico**, y la base la quita sola de los menús que la tenían (`ON DELETE CASCADE`) |

Borrar una etiqueta no afecta a los presupuestos, porque cada línea de catering guarda el **texto** de la etiqueta, no el objeto.

### Inicio (`FormIndex`)

Es la pantalla principal, y la más grande: tiene la lista de presupuestos y el panel para armarlos.

**La lista:**
- **Filtro por evento:** el combo tiene un primer elemento "Todos" con id 0. Si se elige un evento, se pide `getQuotesByEventItem(id)`, y si no, `getQuotes()`.
- **Columnas:** número, evento, fecha, ubicación, invitados, estado y total. Todo sale de las copias del `QuoteDto`.

**Armar un presupuesto:** al tocar Crear, `loadCombos()` llena los combos con DTO activos: eventos, ubicaciones, menús y servicios. Si el filtro tenía un evento elegido, lo deja seleccionado.

```
1. Elegis evento y ubicacion en los combos
2. Elegis un menu -> el combo de etiquetas se llena con las de ESE menu
3. Cargas adultos y ninos, y tocas Agregar linea
     se agrega un DetailMenuDto(menuId, etiqueta, adultos, ninos) a la lista "lineas"
     si esa variante ya estaba, se suman las cantidades
4. Marcas los servicios
5. Cada cambio llama a refreshTotals()
```

**Los totales en vivo:** la pantalla nunca calcula. `refreshTotals()` arma el DTO y le pregunta al Service:

```
FormIndex.refreshTotals()
  |   buildQuoteDto(): ids de evento y ubicacion, las lineas y los ids de servicios
  v
QuoteService.calculatePreview(dto)
  |   toModel(dto): busca los objetos reales y copia sus datos y precios
  |   quote.calculateTotals()
  |   toDto(quote)                      NO lo guarda
  v
FormIndex     muestra los subtotales de cada linea y los totales
```

Así, lo que se ve mientras se carga se calcula con el mismo código que después se guarda.

**Guardar:**

```
FormIndex.btnGuardarQuote_Click
  |   revisa que haya evento y ubicacion elegidos
  |   buildQuoteDto()                   solo ids y cantidades
  v
QuoteService.addQuote(dto)
  |-- toModel(dto)
  |     EventItemService.getModelById    el evento real
  |     UbicationService.getModelById    la ubicacion real
  |     MenuService.getModelById         por cada linea
  |     OptionItemService.getModelById   por cada servicio
  |     new DetailMenu, new DetailOptionItem, new Quote: copian nombres y precios
  |-- validateEventNotPast(...)         el evento no puede haber pasado
  |-- validateQuote(...)                lineas repetidas, etiqueta del menu, elementos de baja
  |-- quote.calculateTotals()
  v
QuoteRepository.addToRepository(quote)
      en una transaccion: INSERT INTO QUOTE, y las filas de DETAIL_MENU y DETAIL_OPTION_ITEM
```

- **Solo ids y cantidades:** la pantalla nunca manda precios ni nombres. Los busca el Service, así que no se puede guardar un precio viejo o inventado.
- **Editar:** solo se puede con un Pendiente. El panel se carga con los datos del `QuoteDto` y el combo del evento queda bloqueado. Si la ubicación o un servicio fueron dados de baja, se agregan al combo como "(dada de baja)" para poder conservarlos. Al guardar, `updateQuote` arma todo de nuevo con `toModel`, así que **el Pendiente toma los datos y precios actuales**.

**Las otras acciones de la lista:**

| Botón | Qué viaja | Qué pasa en el Service |
|---|---|---|
| **Aceptar** | El id | `quote.accept()` cambia el estado. Después revisa que el evento no haya pasado, que sus datos no hayan cambiado desde que se guardó, que el evento no tenga otro Aceptado y que el salón no esté ocupado en ese horario. Recién ahí lo guarda |
| **Cancelar** | El id | `quote.cancel()` y lo guarda |
| **Clonar** | El id | Crea un Pendiente nuevo con la misma ubicación, menús y servicios, pero con los datos y precios **actuales**. No deja clonar si el evento pasó, si usa algo dado de baja o si un menú ya no tiene la etiqueta de una línea |
| **Eliminar** | El id | Pide confirmación, y avisa si es el Aceptado. Es un borrado físico, y la base borra sus líneas |
| **Detalle** | El `QuoteDto` de la fila | Abre la vista previa, sin pasar por el Controller |

Aceptar y Cancelar son estados finales: el presupuesto ya no se edita ni cambia, y `calculateTotals()` no hace nada. Para cambiarlo, se clona.

### Detalle (`FormReport` y `QuotePdf`)

Está en el mismo panel que Inicio: el botón Detalle esconde `FormIndex` y muestra `FormReport`.

```
FormIndex.btnIndexReport_Click
  |   toma el QuoteDto de fila.Tag, que ya trae todas las copias
  v
FormReport.showQuote(dto)
  |   new QuotePdf(dto)
  |   printPreview.Document = pdf.getDocument()   la vista previa dibuja la hoja
  v
QuotePdf.printDocument_PrintPage   dibuja evento, ubicacion, catering, servicios, totales y estado
```

- **Imprimir:** abre "Guardar como" y llama a `pdf.save(ruta)`, que dibuja **la misma hoja** con la impresora "Microsoft Print to PDF". Por eso lo que se ve es lo que se guarda. Si sale bien, avisa con `showInfo` y se queda en la vista previa.
- **Volver:** esconde `FormReport` y vuelve a mostrar `FormIndex`.

Esta pantalla no consulta la base ni pasa por el Controller: todo lo que necesita ya viene en el `QuoteDto`.

---

## 8. Resumen del recorrido

| Momento | Qué se crea | Dónde |
|---|---|---|
| El usuario toca Guardar | Un DTO sin id | En el formulario |
| El pedido llega al Service | Un objeto del Model, que se valida al crearse | `toModel` |
| El Service revisa reglas entre objetos | Nada: lanza `BusinessRuleException` si algo falla | Métodos `validate...` |
| Se guarda | Una fila en la base, que le da el id | Repository |
| Se vuelve a mostrar | Objetos del Model leídos de la base, y después DTO | Repository y `toDto` |
| Se dibuja | Una fila por DTO, con el DTO en `fila.Tag` | `reloadMtlv()` |
