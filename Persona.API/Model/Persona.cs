using System;
using System.Collections.Generic;

namespace Persona.API.Model
{
    public partial class Persona
    {
        public int IdDoc { get; set; }
        public int? IdTipoDoc { get; set; }
        public int? IdPais { get; set; }
        public string Sexo { get; set; }
        public int? Edad { get; set; }
        public string Nombre { get; set; }
    }
}
