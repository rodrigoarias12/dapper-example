using Persona.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persona.API.Infrastructure.Repository
{
   public interface IEstadisticaRepository
    {
        public Task<EstadisticasDTO> GetEstadisticas();
    }
}
