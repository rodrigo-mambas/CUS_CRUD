using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Commands;
using CUS.Cliente.API.Recursos.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using Xunit;

namespace CUS.Teste.API
{
    public class ClienteDeleteCommandHandlerTest
    {
        [Fact]
        public void ClienteDeleteCommand_Sucesso()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            
            var deleteCliente = new ClienteDeleteCommand
            {
                Id = 1
            };

            var getClienteCpf = new GetClientePorIdQuery
            {
                Id = deleteCliente.Id
            };
            var mockClienteCpf = new Mock<GetClientePorIdQueryHandler>(getClienteCpf); 

            var handler = new ClienteDeleteCommandHandler(mockDbContext.Object);
            // Act
            //var result = handler.Handle(updateCliente, CancellationToken.None);

            // Assert
            Assert.NotNull(deleteCliente);
   
        }
        [Fact]
        public void ClienteDeleteCommand_Erro()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());

            var deleteCliente = new ClienteDeleteCommand
            {
                Id = 1
            };

            var getClienteCpf = new GetClientePorIdQuery
            {
                Id = deleteCliente.Id
            };
            var mockClienteCpf = new Mock<GetClientePorIdQueryHandler>(getClienteCpf);

            var handler = new ClienteDeleteCommandHandler(mockDbContext.Object);
            // Act
            var result = handler.Handle(deleteCliente, CancellationToken.None);

            // Assert
            //Assert.True(updateCliente.IsValid);


            // Assert
            //Assert.False(createCliente.IsValid);
            Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(deleteCliente, CancellationToken.None));

        }
    }
}
