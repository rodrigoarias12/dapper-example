using AutoMapper;
using Persona.API.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persona.API.Model;
namespace Persona.API.Service
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<PersonaDTO, Persona.API.Model.Persona>();
            CreateMap<ContactoDTO, Contacto>();
        }
    }
}
