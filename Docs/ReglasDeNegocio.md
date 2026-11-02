# Reglas de negocio — Presupuesto de Eventos

Este documento define **qué calcula y qué valida** el sistema. El diagrama de clases
([UML.md](UML.md)) muestra **dónde** vive cada regla.

---

## 1. Entidades

| Entidad (código) | Qué representa | Datos |
|---|---|---|
| `EventItem` | Un evento a presupuestar (ej. "Casamiento Pérez"). Es el **contenedor** de sus presupuestos | nombre, invitados adultos, invitados niños, duración (horas), lista de presupuestos |
| `Ubication` | Un salón o lugar | nombre, precio **por hora**, activo |
| `Menu` | Un menú de catering | descripción, precio por adulto, precio por niño, etiquetas, activo |
| `MenuTag` | Etiqueta que se le puede asignar a un menú (ej. "Estándar", "Vegana", "Sin TACC"). Las crea el usuario. Funciona como **variante del plato** | descripción |
| `OptionItem` | Un servicio adicional (DJ, fotógrafo, decoración…) | nombre, precio fijo por evento, activo |
| `Quote` | Un presupuesto. Vive dentro de su `EventItem` | ubicación, menús, servicios, estado, totales |
| `DetailMenu` | Una línea de catering dentro del presupuesto: un menú en **una** de sus variantes | menú, etiqueta (copia del texto), cantidad de adultos, cantidad de niños, precio unitario por adulto y por niño (copia) |
| `DetailOptionItem` | Una línea de servicio dentro del presupuesto | servicio, precio unitario (copia) |
| `EstadoPresupuesto` | Estado del presupuesto (enum) | Pendiente, Aceptado, Cancelado |

## 2. Cálculos

Todos los importes son `decimal`. Los calcula `Quote.calculateTotals(duration)`. La llama el `EventItem` dueño del presupuesto, que le pasa su duración, cada vez que agrega, edita o clona un presupuesto.

| Concepto | Fórmula |
|---|---|
| Subtotal de un `DetailMenu` | `UnitPriceAdult × adultQuantity + UnitPriceChild × childQuantity` |
| `TotalMenus` | suma de los subtotales de todos los `DetailMenu` |
| `TotalUbication` | `UbicationPrice × eventItem.Duration` (el precio de la ubicación es por hora) |
| `TotalOptionItems` | suma de `UnitPrice` de todos los `DetailOptionItem` |

Los cálculos usan siempre los **precios copiados en el presupuesto**, nunca los del menú, servicio o ubicación directamente. Mientras el presupuesto está Pendiente, esas copias se actualizan con los precios actuales antes de calcular (ver E2 y E3).
| `Total` | `TotalUbication + TotalMenus + TotalOptionItems` |

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

### Datos básicos (las hace el Model en sus setters y lanza `ArgumentException`)
- V1. Nombre o descripción: obligatorio, no vacío.
- V2. Precios: `>= 0`.
- V3. Invitados adultos y niños: `>= 0`, y al menos 1 invitado en total.
- V4. Duración: `> 0` horas.
- V5. En `DetailMenu`, cada cantidad es `>= 0` y la suma es `> 0`.

### Etiquetas y menús (las hacen `MenuTagService` y `MenuService`)
- V13. La descripción de una etiqueta es obligatoria y **única**, sin distinguir mayúsculas: "vegano" y "Vegano" son la misma.
- V14. Un menú tiene **1 o más** etiquetas, sin repetir. Solo se pueden asignar etiquetas existentes, elegidas de la lista con casillas al crear o editar el menú. Si no se marca ninguna, no se guarda (por ejemplo, se usa "Estándar" para el plato común).
- La etiqueta **no cambia el precio**: todas las variantes de un menú cuestan lo mismo, según su precio por adulto y por niño.

### Presupuesto (las hace `EventItemService.validateQuote` antes de guardar)
- V6. Un presupuesto debe tener ubicación.
- V7. Un mismo menú **con la misma etiqueta** no puede aparecer dos veces en el mismo presupuesto. El mismo menú con etiquetas distintas sí: por ejemplo, Milanesa estándar y Milanesa vegana son dos líneas.
- V15. La etiqueta de una línea de catering tiene que ser una de las que **ese menú tiene asignadas**. Si la Milanesa no tiene "Sin TACC", no se puede pedir Milanesa sin TACC.
- V8. Un mismo servicio no puede aparecer dos veces en el mismo presupuesto.
- V9. La suma de adultos de todos los `DetailMenu` no puede superar `GuestAdults` del evento. Lo mismo vale para niños. Se permite que sea menor, por ejemplo para invitados sin catering.
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
- E2. Solo un presupuesto **Pendiente** se puede editar. Al editarlo, `refreshPrices()` copia los precios actuales de la ubicación, los menús y los servicios, y se recalculan los totales.
- E3. Al **aceptar** un presupuesto quedan **congelados** sus precios línea por línea (ubicación, cada menú y cada servicio) y sus totales. Si después cambia el precio de un menú, de un salón o de un servicio, o la duración del evento, ese presupuesto no cambia. El detalle impreso siempre coincide con el total. Lo mismo vale para un presupuesto Cancelado.
- E4. Un evento puede tener un solo presupuesto Aceptado. Lo controla el propio `EventItem.acceptQuote()` revisando su lista (`hasAcceptedQuote()`). Si ya tiene uno, lanza `InvalidOperationException` y la View muestra el mensaje. Los demás presupuestos Pendientes **no cambian**: se pueden seguir editando o cancelar a mano.
- E5. `clone()` crea un presupuesto nuevo, Pendiente, con la misma ubicación, menús y servicios, recalculado con los precios actuales. Sirve para armar variantes o para rehacer uno cancelado.
- E6. Aceptado y Cancelado son estados finales: no vuelven a Pendiente. Para cambiarlos se clona.

## 5. Integridad entre entidades

- I1. **Baja lógica:** eliminar una `Ubication`, `Menu` u `OptionItem` no la borra del repositorio. La marca como inactiva (`deactivate()`, que pone `IsActive = false`).
  - Las listas de los formularios de Ubicaciones, Catering y Servicios muestran solo los activos.
  - Los presupuestos que ya la usan no cambian y siguen mostrando su nombre y su precio.
  - No se puede ofrecer para presupuestos nuevos (V12).
- I4. `EventItem` y `Quote` sí se borran físicamente, con `removeById`.
- I5. **Etiquetas:** se borran físicamente.
  - **No se puede borrar** una etiqueta si es la **única** de algún menú, porque ese menú quedaría sin etiquetas (V14). Se muestra un mensaje con los menús afectados (`getMenusWithOnlyThisTag`), y primero hay que asignarles otra.
  - Si está asignada a otros menús que tienen más etiquetas, la View pide confirmación indicando a cuántos afecta (`countMenusUsing`). Al confirmar, la etiqueta desaparece de esos menús.
  - Los presupuestos **no cambian**: cada línea de catering guardó una copia del texto de la etiqueta, así que sigue diciendo, por ejemplo, "Vegana", aunque la etiqueta ya no exista o se haya renombrado.
- I2. Eliminar un `EventItem` elimina también todos sus presupuestos. Ocurre solo, por la composición: los presupuestos viven dentro del evento.
- I3. Los IDs los asigna el repositorio (`idCounter`), nunca la View. Los IDs de los presupuestos los asigna su `EventItem` (`_quoteIdCounter`), así que un presupuesto se identifica por el par (id de evento, id de presupuesto).

## 6. Dónde va cada cosa (capas)

| Capa | Responsabilidad | Ejemplo |
|---|---|---|
| **View** | Leer y validar el formato de los campos, mostrar mensajes, refrescar listas | V10, V11 |
| **Controller** | Puente fino entre View y Service. No tiene lógica | `ubicationController.addToRepository(dto)` |
| **Service** | Reglas que involucran varias entidades o repositorios, conversión entre DTO y Model | V6–V9, V12–V15, I1, I5 |
| **Model** | Reglas de una entidad y de lo que contiene, cálculos | V1–V5, E1–E6, I2, `calculateTotals()` |
| **Repository** | Guardar y buscar en la base SQLite. Implementa `Irepository<T>` | `getById`, `removeById` |
| **Dto** | Transportar datos entre View y Service. No tiene lógica. Referencia otras entidades por **id**, no por objeto | `QuoteDto.UbicationId` |
