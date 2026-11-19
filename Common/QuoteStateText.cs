namespace ProyectoPresupuestoEvento.Common
{
    public static class QuoteStateText
    {

        //metodos

        public static string GetDisplayName(QuoteState state)
        {
            if (state == QuoteState.Accepted)
            {
                return "Aceptado";
            }
            if (state == QuoteState.Cancelled)
            {
                return "Cancelado";
            }
            return "Pendiente";
        }
    }
}
