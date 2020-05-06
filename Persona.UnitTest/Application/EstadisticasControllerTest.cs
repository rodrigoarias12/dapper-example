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

namespace Persona.UnitTest.Application
{
    public class EstadisticasControllerTest
    {

        
        private readonly Mock<IEstadisticaRepository> _repo;
        public EstadisticasControllerTest()
        {
        
            _repo = new Mock<IEstadisticaRepository>();
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
        public async Task Get_Estadistica_success()
        {
            //Arrange


            var expectedPorcentajePais = 100;
            var expectedCantH = 31;
            var expectedCantM = 32;

            var fakeEstadisticas = new EstadisticasDTO();
            _repo.Setup(x => x.GetEstadisticas())
              .Returns(Task.FromResult(fakeEstadisticas));

            //Act
            var perController = new EstadisticasController(_repo.Object);
            var actionResult = await perController.Get();

            //Assert
            Assert.IsType<ActionResult<EstadisticasDTO>>(actionResult);
            var resultado = Assert.IsAssignableFrom<EstadisticasDTO>(actionResult.Value);
            //Assert.Equal(expectedPorcentajePais, resultado.Porcentaje_Argentinos);
            //Assert.Equal(expectedCantH, resultado.Cantidad_Hombres);
            //Assert.Equal(expectedCantM, resultado.Cantidad_Mujeres);
        }
      
    }
}
