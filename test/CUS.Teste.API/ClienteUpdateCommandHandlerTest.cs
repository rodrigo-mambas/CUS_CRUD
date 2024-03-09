using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Commands;
using CUS.Cliente.API.Recursos.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using Xunit;

namespace CUS.Teste.API
{
    public class ClienteUpdateCommandHandlerTest
    {
        [Fact]
        public void ClienteUpdateCommand_Sucesso()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            
            var updateCliente = new ClienteUpdateCommand
            {
                Id = 1,
                Nome = "Teste",
                Cpf = "12345678909"
            };

            var getClienteCpf = new GetClientePorIdQuery
            {
                Id = updateCliente.Id
            };
            var mockClienteCpf = new Mock<GetClientePorIdQueryHandler>(getClienteCpf); 

            var handler = new ClienteUpdateCommandHandler(mockDbContext.Object);
            // Act
            //var result = handler.Handle(updateCliente, CancellationToken.None);

            // Assert
            Assert.True(updateCliente.IsValid);
   
        }
        [Fact]
        public void ClienteUpdateCommand_Erro()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());

            var updateCliente = new ClienteUpdateCommand
            {
                Id = 1,
                Nome = "Teste",
                Cpf = "12345678909"
            };

            var getClienteCpf = new GetClientePorIdQuery
            {
                Id = updateCliente.Id
            };
            var mockClienteCpf = new Mock<GetClientePorIdQueryHandler>(getClienteCpf);

            var handler = new ClienteUpdateCommandHandler(mockDbContext.Object);
            // Act
            var result = handler.Handle(updateCliente, CancellationToken.None);

            // Assert
            //Assert.True(updateCliente.IsValid);


            // Assert
            //Assert.False(createCliente.IsValid);
            Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(updateCliente, CancellationToken.None));

        }
    }
}
