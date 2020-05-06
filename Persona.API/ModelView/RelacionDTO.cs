using Persona.API.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Persona.API.Model
{
    public class RelacionDTO
    {
        public String Relacion { get; set; }

        private static readonly List<TipoRelacion> _relaciones = new List<TipoRelacion>()
            {
                new TipoRelacion(){id = 1,name= "Papa"},
                new TipoRelacion(){id = 2,name= "Ti@"},
                new TipoRelacion(){id = 3,name= "Heman@"},
                new TipoRelacion(){id = 4,name= "Prim@"},
             };
        public RelacionDTO(Relacion rel)
        {
            Relacion = _relaciones.Find(x => x.id == rel.IdRelacion).name;
        }

    }
}
