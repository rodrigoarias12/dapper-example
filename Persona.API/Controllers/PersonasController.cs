using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persona.API.Model;
using Persona.API.ModelView;

namespace Persona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaContext _context;

        public PersonasController(PersonaContext context)
        {
            _context = context;
        }

        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona.API.Model.Persona>>> GetPersona()
        {
            return await _context.Persona.ToListAsync();
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona.API.Model.Persona>> GetPersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Persona/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona.API.Model.Persona persona)
        {
            if (id != persona.IdDoc)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Persona
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Persona.API.Model.Persona>> PostPersona(PersonaDTO Nuevo)
        {
            Persona.API.Model.Persona nueva_persona = new Persona.API.Model.Persona();
            _context.Persona.Add(nueva_persona);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonaExists(nueva_persona.IdDoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersona", new { id = nueva_persona.IdDoc }, nueva_persona);
        }

        [HttpPost(":id1/padre/:id2")]
        public async Task<ActionResult<Persona.API.Model.Relacion>> PostPersona(int id1, int id2)
        {
            Relacion AddRelacion = new Relacion();
            AddRelacion.IdDoc1 = id1;
            AddRelacion.IdDoc2 = id2;
            AddRelacion.IdRelacion = 1;
            //Agregar Relacion
            _context.Relacion.Add(AddRelacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
               
                    return Conflict();
             
            }

            return Ok( AddRelacion);
        }


        // DELETE: api/Persona/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persona.API.Model.Persona>> DeletePersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();

            return persona;
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.IdDoc == id);
        }
      
    }
}
