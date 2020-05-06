using Microsoft.AspNetCore.Mvc;
using Persona.API.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Persona.API.ModelView
{
    public class PersonaDTO
    {
        [Required]
        public int IdDoc { get; set; }
        [Required]
        public int? IdTipoDoc { get; set; }
        [Required]
        public int? IdPais { get; set; }
        [Required]
        public string Sexo { get; set; }
        [ValidarEdad(ErrorMessage = "No pueden crearse personas menores a 18 años.")]
        public int? Edad { get; set; }
        public string Nombre { get; set; }
        [ValidarContacto(ErrorMessage = "Las personas deben tener al menos un dato de contacto.")]
        public List<ContactoDTO> Contactos { get; set; }
    }
    public class ValidarEdad : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int number = int.Parse(value.ToString());
            if (number > 18)
                return true;
            else return false;
        }
    }

    public class ValidarContacto : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            IList collection = (IList)value;
            if (collection.Count > 0)
                return true;
            else return false;
        }
    }
}
