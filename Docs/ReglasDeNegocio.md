# Reglas de negocio — Presupuesto de Eventos

Este documento define **qué calcula y qué valida** el sistema. El diagrama de clases
([UML.md](UML.md)) muestra **dónde** vive cada regla.

---

## 1. Entidades

| Entidad (código) | Qué representa | Datos |
|---|---|---|
| `EventItem` | Un evento a presupuestar (ej. "Casamiento Pérez"). Puede tener varios presupuestos | nombre, cliente (nombre), fecha y hora de inicio, invitados adultos, invitados niños, duración (horas enteras) |
| `Ubication` | Un salón o lugar | nombre, precio **por hora**, activo |
| `Menu` | Un menú de catering | descripción, precio por adulto, precio por niño, etiquetas, activo |
| `MenuTag` | Etiqueta que se le puede asignar a un menú (ej. "Estándar", "Vegana", "Sin TACC"). Las crea el usuario. Funciona como **variante del plato** | descripción |
| `OptionItem` | Un servicio adicional (DJ, fotógrafo, decoración…) | nombre, precio fijo por evento, activo |
| `Quote` | Un presupuesto. Pertenece a un evento: guarda su id y una copia de sus datos | evento (id y copia de nombre, cliente, fecha, invitados y duración), ubicación (copia de nombre y precio), menús, servicios, estado, totales |
| `DetailMenu` | Una línea de catering dentro del presupuesto: un menú en **una** de sus variantes | menú (copia de la descripción), etiqueta (copia del texto), cantidad de adultos, cantidad de niños, precio unitario por adulto y por niño (copia) |
| `DetailOptionItem` | Una línea de servicio dentro del presupuesto | servicio (copia del nombre), precio unitario (copia) |
| `EstadoPresupuesto` | Estado del presupuesto (enum) | Pendiente, Aceptado, Cancelado |

## 2. Cálculos

Todos los importes son `decimal`. Los calcula `Quote.calculateTotals()`, con la duración copiada en el presupuesto. La llama `QuoteService` al crear, editar y clonar un presupuesto, y al calcular la vista mientras se carga.

| Concepto | Fórmula |
|---|---|
| Subtotal de un `DetailMenu` | `UnitPriceAdult × adultQuantity + UnitPriceChild × childQuantity` |
| `TotalMenus` | suma de los subtotales de todos los `DetailMenu` |
| `TotalUbication` | `UbicationPrice × eventItem.Duration` (el precio de la ubicación es por hora) |
| `TotalOptionItems` | suma de `UnitPrice` de todos los `DetailOptionItem` |
| `Total` | `TotalUbication + TotalMenus + TotalOptionItems` |

Los cálculos y lo que se muestra usan siempre **los datos copiados en el presupuesto**, nunca los del evento, menú, servicio o ubicación directamente. Esas copias se toman al crear o clonar, y en un Pendiente se actualizan con los datos actuales **solo al editarlo y guardarlo** (ver E2 y E3).

**Ejemplo:** evento de 5 h, 80 adultos y 20 niños, en un salón de $50.000/h.
El menú Milanesa ($15.000 por adulto y $8.000 por niño) para todos, en tres variantes. DJ $200.000.

| Línea de catering | Adultos | Niños | Subtotal |
|---|---|---|---|
| Milanesa · Estándar | 65 | 18 | 15.000 × 65 + 8.000 × 18 = 1.119.000 |
| Milanesa · Vegana | 10 | 0 | 15.000 × 10 = 150.000 |
| Milanesa · Sin TACC | 5 | 2 | 15.000 × 5 + 8.000 × 2 = 91.000 |

- Ubicación: 50.000 × 5 = **250.000**
- Menús: 1.119.000 + 150.000 + 91.000 = **1.360.000** (las variantes cuestan lo mismo)
- Servicios: **200.000**
- **Total = 1.810.000**

## 3. Validaciones

### Datos básicos (las hace el Model en sus `set` y lanza `BusinessRuleException`)
- V1. Nombre o descripción: obligatorio, no vacío. En un evento, el nombre del cliente también es obligatorio.
- V2. Precios: `>= 0`.
- V3. Invitados adultos y niños: `>= 0`, y al menos 1 invitado en total. El total se revisa en el constructor de `EventItem`, porque necesita los dos datos.
- V4. Duración: horas enteras, `> 0`.
- V16. Fecha del evento: al **crear** un evento, el día no puede ser anterior a hoy (hoy a cualquier hora se acepta). Al **editarlo** se acepta cualquier fecha, para no trabar eventos que ya pasaron. La revisa `EventItemService` al crear, porque depende de la operación y no vale siempre.
- V5. En `DetailMenu`, cada cantidad es `>= 0` y la suma es `> 0`. La suma se revisa en el constructor.

### Etiquetas y menús (las hacen `MenuTagService` y `MenuService`)
- V13. La descripción de una etiqueta es obligatoria (la revisa `MenuTag`) y **única** (la revisa `MenuTagService`), sin distinguir mayúsculas: "vegano" y "Vegano" son la misma.
- V14. Un menú tiene **1 o más** etiquetas, sin repetir. Solo se pueden asignar etiquetas existentes, elegidas de la lista con casillas al crear o editar el menú. Si no se marca ninguna, `Menu` lo rechaza en el `set` de `TagList` y no se guarda (por ejemplo, se usa "Estándar" para el plato común).
- La etiqueta **no cambia el precio**: todas las variantes de un menú cuestan lo mismo, según su precio por adulto y por niño.

### Presupuesto (las hace `QuoteService.validateQuote` antes de guardar)
Si una regla no se cumple, `QuoteService` lanza `BusinessRuleException` con el mensaje, y la View lo muestra con `MessageHelper`.
- V6. Un presupuesto debe tener ubicación.
- V7. Un mismo menú **con la misma etiqueta** no puede aparecer dos veces en el mismo presupuesto. El mismo menú con etiquetas distintas sí: por ejemplo, Milanesa estándar y Milanesa vegana son dos líneas. En la pantalla, si se agrega una variante que ya está en la lista, **se suman las cantidades** a esa línea.
- V15. La etiqueta de una línea de catering tiene que ser una de las que **ese menú tiene asignadas**. Si la Milanesa no tiene "Sin TACC", no se puede pedir Milanesa sin TACC.
- V8. Un mismo servicio no puede aparecer dos veces en el mismo presupuesto.
- V9. **No hay límite** de platos según los invitados. Un presupuesto puede pedir más platos que invitados, por ejemplo si el evento tiene varios bloques de menú (entrada, principal, postre, bebida) o si se encarga comida de más. También puede pedir menos, por ejemplo para invitados sin catering. Como referencia, el panel de carga muestra los invitados del evento al lado del catering.
- V12. Un presupuesto nuevo o clonado solo puede usar ubicación, menús y servicios **activos**. Al editar un presupuesto Pendiente se pueden conservar los elementos que ya tenía aunque se hayan dado de baja, pero no se pueden agregar elementos inactivos.

### Formularios (las hace la View antes de llamar al Controller)
- V10. Los campos numéricos se leen con `decimal.TryParse` o `int.TryParse`. Si fallan, se muestra un mensaje y no se llama al controller.
- V11. Editar o eliminar sin una fila seleccionada muestra un mensaje en lugar de romper la app.

## 4. Ciclo de vida del presupuesto

```
          accept()
Pendiente ────────► Aceptado
    │
    │ cancel()
    ▼
Cancelado
```

- E1. Todo presupuesto nuevo (o clonado) nace **Pendiente**.
- E2. Solo un presupuesto **Pendiente** se puede editar. Al guardarlo, toma los datos actuales del evento, la ubicación, los menús y los servicios (nombres, precios, invitados y duración), y se recalculan los totales. Mientras no se edite y se guarde, conserva los datos que tenía, también si cambia la **duración** del evento. Si se acepta sin guardarlo de nuevo, queda con los datos que tenía.
- E3. Al **aceptar** un presupuesto queda **congelado** por completo: datos del evento, nombres, precios línea por línea y totales, **con lo que tiene en ese momento**: aceptar no los actualiza. Si después cambia algo del evento, un menú, un salón o un servicio, ese presupuesto no cambia. El detalle impreso siempre coincide con el total. Lo mismo vale para un presupuesto Cancelado.
- E4. Un evento puede tener un solo presupuesto Aceptado. Lo controla `QuoteService.acceptQuote`, buscando otro Aceptado con el mismo evento. Si ya hay uno, lanza `BusinessRuleException` y la View muestra el mensaje. Los demás presupuestos Pendientes **no cambian**: se pueden seguir editando o cancelar a mano.
- E5. `clone()` crea un presupuesto nuevo, Pendiente, con la misma ubicación, menús y servicios, recalculado con los datos y precios actuales. Se puede clonar un presupuesto en cualquier estado. Sirve para armar variantes o para rehacer uno cancelado. Si usa algún elemento dado de baja, no se puede clonar (V12).
- E6. Aceptado y Cancelado son estados finales: no vuelven a Pendiente. Para cambiarlos se clona.

## 5. Integridad entre entidades

- I1. **Baja lógica:** eliminar una `Ubication`, `Menu` u `OptionItem` no la borra del repositorio. La marca como inactiva (`deactivate()`, que pone `IsActive = false`).
  - Las listas de los formularios de Ubicaciones, Catering y Servicios muestran solo los activos.
  - Los presupuestos que ya la usan no cambian y siguen mostrando su nombre y su precio.
  - No se puede ofrecer para presupuestos nuevos (V12).
- I4. `EventItem` y `Quote` sí se borran físicamente, con `removeById`. Un presupuesto se puede eliminar en **cualquier estado**, con confirmación. Si es el Aceptado, el mensaje lo avisa.
- I5. **Etiquetas:** se borran físicamente.
  - **No se puede borrar** una etiqueta si es la **única** de algún menú, porque ese menú quedaría sin etiquetas (V14). Se muestra un mensaje con los menús afectados (`getMenusWithOnlyThisTag`), y primero hay que asignarles otra.
  - Si está asignada a otros menús que tienen más etiquetas, la View pide confirmación indicando a cuántos afecta (`countMenusUsing`). Al confirmar, la etiqueta desaparece de esos menús.
  - Los presupuestos **no cambian**: cada línea de catering guardó una copia del texto de la etiqueta, así que sigue diciendo, por ejemplo, "Vegana", aunque la etiqueta ya no exista o se haya renombrado.
- I2. Eliminar un `EventItem` elimina también todos sus presupuestos: `EventItemService.removeEventItem` llama a `QuoteService.removeQuotesByEventItem`. La View pide confirmación avisando cuántos tiene (`countQuotes`).
- I3. Los IDs los asigna el repositorio (`idCounter`), nunca la View. Cada presupuesto tiene su propio id y guarda el id de su evento.

## 6. Dónde va cada cosa (capas)

| Capa | Responsabilidad | Ejemplo |
|---|---|---|
| **View** | Leer los campos, convertir el texto a número, mostrar mensajes con `MessageHelper` y refrescar listas. Las reglas no van acá | V10, V11 |
| **Controller** | Puente fino entre View y Service. No tiene lógica | `ubicationController.addToRepository(dto)` |
| **Service** | Reglas que involucran varias entidades u operaciones, conversión entre DTO y Model. Cada service usa solo su repositorio y le pide lo demás a otro service | V6–V9, V12–V16, I1, I5 |
| **Model** | Reglas de una entidad y de lo que contiene, cálculos | V1–V5, E1–E6, I2, `calculateTotals()` |
| **Repository** | Guardar y buscar en la base SQLite. Implementa `Irepository<T>` | `getById`, `removeById` |
| **Dto** | Transportar datos entre View y Service. No tiene lógica. Referencia otras entidades por **id**, no por objeto | `QuoteDto.UbicationId` |
