using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Commands;
using CUS.Cliente.API.Recursos.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using Xunit;

namespace CUS.Teste.API
{
    public class ClienteCreateCommandHandlerTest
    {


        [Fact]
        public void ClienteCreateCommand_Sucesso()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            var createCliente = new ClienteCreateCommand
            {
                Nome = "Teste",
                Cpf = "12345678909"
            };

            var getClienteCpf = new GetClientePorCpfQuery
            {
                Cpf = createCliente.Cpf
            };
            //var mockClienteCpf = new Mock<GetClientePorCpfQueryHandler>(getClienteCpf); ;
            //var a = new GetClientePorCpfQueryHandler();
            var handler = new ClienteCreateCommandHandler(mockDbContext.Object);
            // Act
            var result = handler.Handle(createCliente, CancellationToken.None);

            // Assert
            Assert.True(createCliente.IsValid);
   
        }
        [Fact]
        public void ClienteCreateCommand_Erro()
        {
            // Arrange
            var mockClienteCpf = new Mock<GetClientePorCpfQueryHandler>();
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            var handler = new ClienteCreateCommandHandler(mockDbContext.Object);
            var createCliente = new ClienteCreateCommand
            {
                Nome = "Teste",
                Cpf = "123a34d"
            };

            // Act
            handler.Handle(createCliente, CancellationToken.None);

            // Assert
            Assert.False(createCliente.IsValid);

        }
    }
}
