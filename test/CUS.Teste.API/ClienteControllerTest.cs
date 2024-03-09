
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CUS.Cliente.API.Controllers;
using CUS.Cliente.API.Models;
using CUS.Cliente.API.Recursos.Commands;
using CUS.Cliente.API.Recursos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CUS.Teste.API
{
    public class ClienteControllerTests
    {
        [Fact]
        public async Task GetClientes_DeveRetornarListaDeClientes()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new ClienteController(null, mockMediator.Object);
            var query = new GetTodosClientesQuery();
            var clientes = new List<CUS.Cliente.API.Models.Cliente> { new CUS.Cliente.API.Models.Cliente { Id = 1, Nome = "Cliente1" } };
            mockMediator.Setup(m => m.Send(query, default)).ReturnsAsync(clientes);

            // Act
            var result = await controller.GetClientes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoClientes = Assert.IsAssignableFrom<IEnumerable<CUS.Cliente.API.Models.Cliente>>(okResult.Value);

            //result.Result.StatusCode ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).StatusCode
            //Assert.Single(retornoClientes);
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).StatusCode);
        }

        // Outros testes para os outros métodos do ClienteController podem ser escritos da mesma forma
    }
}
