using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persona.API.Model
{
    public partial class EstadisticasDTO
    {
        public int Cantidad_Mujeres { get; set; }
        public int Cantidad_Hombres { get; set; }
        public int Porcentaje_Argentinos { get; set; }
    }
}
