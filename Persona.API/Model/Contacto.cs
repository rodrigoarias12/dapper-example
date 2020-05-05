using System;
using System.Collections.Generic;

namespace Persona.API.Model
{
    public partial class Contacto
    {
        public int IdDoc { get; set; }
        public int IdTipoContacto { get; set; }
        public string Descripcion { get; set; }
    }
}
