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
using Persona.API.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Persona.API.ModelView;
using Microsoft.Extensions.Logging;
using Persona.API.Service;

namespace Persona.UnitTest.Application
{
    public class PersonasControllerTest
    {

        private readonly DbContextOptions<PersonaContext> _dbOptions;
      
        public PersonasControllerTest()
        {

            //db
            _dbOptions = new DbContextOptionsBuilder<PersonaContext>()
                .UseInMemoryDatabase(databaseName: "in-memory")
                .Options;

            using (var dbContext = new PersonaContext(_dbOptions))
            {
                dbContext.AddRange(GetFakePersonas());
                dbContext.SaveChanges();
            }
        }
        private List<Persona.API.Model.Persona> GetFakePersonas()
        {
            return new List<Persona.API.Model.Persona>()
            {

                new Persona.API.Model.Persona()
                {
                    IdDoc = 1,
                    IdTipoDoc = 2,
                    IdPais = 1,
                    Sexo = "M",
                    Edad=31,
                    Nombre = "fakeUserA",
                },
                new Persona.API.Model.Persona()
                {
                     IdDoc = 2,
                    IdTipoDoc = 2,
                    IdPais = 1,
                    Sexo = "M",
                    Edad=31,
                    Nombre = "fakeUserB",
                },
                new Persona.API.Model.Persona()
                {  IdDoc = 3,
                    IdTipoDoc = 2,
                    IdPais = 12,
                    Sexo = "F",
                    Edad=31,
                    Nombre = "fakeUserC",
                },

            };
        }
      
        [Fact]
        public async Task Get_Persona_success()
        {

            //mapper
         
          

            var myProfile = new AutoMapping();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            //logger
            var mockLog = new Mock<ILogger<PersonasController>>();
            ILogger<PersonasController> logger = mockLog.Object;


            //Arrange

            var Iddoc = 1;

            var expectedidpais = 1;
            var expectedEdad = 31;

            var catalogContext = new PersonaContext(_dbOptions);

            //todo para el de estadisticas me pide la interfaz del repositorio buscar eso
            //Act
            var perController = new PersonasController(catalogContext, mapper, logger);
            var actionResult = await perController.GetPersona(Iddoc);

            //Assert
            Assert.IsType<ActionResult<Persona.API.Model.Persona>>(actionResult);
            var resultado = Assert.IsAssignableFrom<Persona.API.Model.Persona>(actionResult.Value);
            Assert.Equal(expectedEdad, resultado.Edad);
            Assert.Equal(expectedidpais, resultado.IdPais);
        }
    }
}
