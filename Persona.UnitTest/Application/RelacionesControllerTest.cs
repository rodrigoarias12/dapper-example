using Persona.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persona.API.Controllers;
using Persona.API.Infrastructure;
using Persona.API.Model;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Persona.UnitTest.Application
{
    public class RelacionesControllerTest
    {
        private readonly DbContextOptions<PersonaContext> _dbOptions;

        public RelacionesControllerTest()
        {
            _dbOptions = new DbContextOptionsBuilder<PersonaContext>()
                .UseInMemoryDatabase(databaseName: "in-memory")
                .Options;

            using (var dbContext = new PersonaContext(_dbOptions))
            {
                dbContext.AddRange(GetFakeRelaciones());
                dbContext.SaveChanges();
            }
        }
        private List<Relacion> GetFakeRelaciones()
        {
            return new List<Relacion>()
            {

                new Relacion()
                {
                    IdDoc1 = 1,
                    IdDoc2 = 2,
                    IdRelacion=2,
                },
                 new Relacion()
                {
                    IdDoc1 = 1,
                    IdDoc2 = 3,
                    IdRelacion=3,
                },
                  new Relacion()
                {
                    IdDoc1 = 2,
                    IdDoc2 = 3,
                    IdRelacion=4,
                },
            };
        }
        [Fact]
        public async Task Get_Relacion_success()
        {
            //Arrange

            var Iddoc1 = 1;
            var Iddoc2 = 2;
            var expectedRelacion = "Ti@";
          

            var catalogContext = new PersonaContext(_dbOptions);

            //todo para el de estadisticas me pide la interfaz del repositorio buscar eso
            //Act
            var _realacionController = new RelacionesController(catalogContext);
            var actionResult = await _realacionController.Get(Iddoc1,Iddoc2);

            //Assert
            Assert.IsType<ActionResult<RelacionDTO>>(actionResult);
            var resultado = Assert.IsAssignableFrom<RelacionDTO>(actionResult.Value);
            Assert.Equal(expectedRelacion, actionResult.Value.Relacion);
        }
    }
}
