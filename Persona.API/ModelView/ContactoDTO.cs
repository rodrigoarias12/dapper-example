using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Persona.API.ModelView
{
    public class ContactoDTO
    {
        [Required]
        public int IdTipoContacto { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
