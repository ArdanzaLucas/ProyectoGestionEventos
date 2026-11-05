# Plan de implementación

El orden busca tener algo que funcione de punta a punta lo antes posible. Cada módulo
sigue el mismo patrón (View → Controller → Service → `Irepository<T>`). Ubicaciones queda
como modelo para copiar en los demás.

Diseño: [UML.md](UML.md) · Reglas: [ReglasDeNegocio.md](ReglasDeNegocio.md)

## Listas en memoria durante el desarrollo

El UML muestra el diseño **final**, que guarda todo en SQLite. Mientras se desarrollan los módulos, cada repositorio puede guardar los datos en una `List<T>` de forma **provisoria**, y para eso necesita ser singleton, para que la lista sea compartida. Como los repositorios se llaman igual e implementan la misma interfaz `Irepository<T>`, en la etapa 9 solo cambia el **interior** de cada repositorio: la lista pasa a ser SQL. Services, Controllers y Views no se tocan.

| # | Etapa | Qué incluye | Listo cuando |
|---|---|---|---|
| 1 | **Ubicaciones** | Crear, editar, baja lógica, validaciones V1, V2, V10 y V11, recargar la lista al abrir | CRUD completo sin errores con datos inválidos |
| 2 | **Servicios adicionales** | `OptionItem`, copiando el patrón de Ubicaciones | CRUD completo |
| 3 | **Catering** | Primero el CRUD de `MenuTag` (`FormMenuTags`, que se abre con el botón Etiquetas). Después `Menu` con precio por adulto y por niño, y la asignación de etiquetas con una lista de casillas | Se crean etiquetas, se asignan a menús y al borrar una desaparece de los menús |
| 4 | **Eventos** | CRUD de `EventItem` (V3, V4) | CRUD completo |
| 5 | **Presupuestos (lógica)** | `Quote`, `DetailMenu`, `DetailOptionItem`, `EstadoPresupuesto`, sus DTO, `QuoteRepository`, `QuoteService` y `QuoteController`: cálculos, estados, clonado y validaciones. Borrado en cascada desde Eventos | La lógica funciona probada con un script, sin pantalla |
| 6 | **Inicio** | `FormIndex` lista todos los presupuestos (evento, fecha, ubicación, invitados, estado, total) con filtro por evento, y tiene el panel para armarlos | Se arma, edita, acepta, cancela, clona y elimina un presupuesto desde la pantalla, con totales correctos |
| 7 | **Vista previa y PDF** | Botón Detalle en Inicio, que abre `FormReport` con la vista previa de la hoja, y clase `QuotePdf`, que dibuja el presupuesto (evento, ubicación, catering, servicios, totales y estado). El botón Imprimir la guarda como PDF con la impresora "Microsoft Print to PDF". Por ahora sin impresión en papel | Se ve el detalle de un presupuesto y se guarda como PDF |
| 8 | **Base de datos** | Paquete `Microsoft.Data.Sqlite`, `SqliteDatabase` con creación de tablas | Al abrir la app se crea `presupuestos.db` con todas las tablas |
| 9 | **Repositorios SQLite** | Reemplazar la lista interna de cada repositorio por SQL y quitarles el singleton. Hay que guardar `IsActive` en el `update` y agregar a `Quote` un constructor con estado, para leerlo de la base. Borrar la carpeta `Mock` y su llamada en `Program.cs` | Los datos persisten al cerrar y abrir la app, sin cambios en Services ni Views |
