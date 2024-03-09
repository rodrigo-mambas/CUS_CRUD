using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Commands;
using CUS.Cliente.API.Recursos.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using Xunit;

namespace CUS.Teste.API
{
    public class GetClientePorIdQueryHandlerTest
    {
        [Fact]
        public void GetClientePorIdQuery_Sucesso()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            
            var getCliente = new GetClientePorIdQuery
            {
                Id = 1
            };

            var handler = new GetClientePorIdQueryHandler(mockDbContext.Object);
            // Act
            handler.Handle(getCliente, CancellationToken.None);

            // Assert
            Assert.NotNull(getCliente.Id);
   
        }
        [Fact]
        public async Task GetClientePorIdQuery_Erro()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());

            var mockGetCliente = new Mock<GetClientePorIdQuery>().Object;
            var handler = new GetClientePorIdQueryHandler(mockDbContext.Object);

            // Act / Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(mockGetCliente, CancellationToken.None));
        }
    }
}
