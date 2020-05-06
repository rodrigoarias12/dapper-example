using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persona.API.Model;

namespace Persona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionesController : ControllerBase
    {
        private readonly PersonaContext _context;

        public RelacionesController(PersonaContext context)
        {
            _context = context;
        }
        // GET: api/Relaciones/5/1
        [HttpGet("{id1}/{id2}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RelacionDTO), (int)HttpStatusCode.OK)]
        public async Task< ActionResult<RelacionDTO>> Get(int id1,int id2)
        {
            var _relacion = await _context.Relacion.FindAsync(id1,id2);
          
            if (_relacion == null)
            {
                return NotFound();
            }
            var _relacionDTO = new RelacionDTO(_relacion);
            return _relacionDTO;
        }

    }
}
