using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Commands;
using CUS.Cliente.API.Recursos.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using Xunit;

namespace CUS.Teste.API
{
    public class GetTodosClientesQueryHandlerTest
    {

        [Fact]
        public async Task GetTodosClientesQuery_ErroSucesso()
        {
            // Arrange
            var mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());

            var mockGetCliente = new Mock<GetTodosClientesQuery>().Object;
            var handler = new GetTodosClientesQueryHandler(mockDbContext.Object);

            // Act / Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(mockGetCliente, CancellationToken.None));
        }
    }
}
