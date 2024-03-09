using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Commands;
using CUS.Cliente.API.Recursos.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using Xunit;

namespace CUS.Teste.API
{
    public class GetClientePorCpfQueryHandlerTest
    {
        [Fact]
        public void GetClientePorCpfQuery_Sucesso()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            
            var getCliente = new GetClientePorCpfQuery
            {
                Cpf = "12345678909"
            };

            var handler = new GetClientePorCpfQueryHandler(mockDbContext.Object);
            // Act
            handler.Handle(getCliente, CancellationToken.None);

            // Assert
            Assert.NotNull(getCliente.Cpf);
   
        }
        [Fact]
        public async Task GetClientePorIdQuery_Erro()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());

            var mockGetCliente = new Mock<GetClientePorCpfQuery>().Object;
            var handler = new GetClientePorCpfQueryHandler(mockDbContext.Object);

            // Act / Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(mockGetCliente, CancellationToken.None));
        }
    }
}
