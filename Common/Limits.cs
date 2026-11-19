using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Common
{
    public static class Limits
    {
        public const int MaxTextLength = 50;
        public const decimal MaxPrice = 1000000000;
        public const int MaxQuantity = 10000;
        public const int MaxGuests = 10000;
        public const int MinDuration = 1;
        public const int MaxDuration = 24;
    }
}
