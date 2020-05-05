using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persona.API.Infrastructure.Repository;
using Persona.API.Model;

namespace Persona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticasController : ControllerBase
    {
        private readonly IEstadisticaRepository _employeeRepo;

        public EstadisticasController(IEstadisticaRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstadisticasDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EstadisticasDTO>> Get()
        {
            EstadisticasDTO devolucion = await _employeeRepo.GetEstadisticas();
            if (devolucion == null)
            {
                return NotFound();
            }
            return Ok(devolucion);
        }


    }
}