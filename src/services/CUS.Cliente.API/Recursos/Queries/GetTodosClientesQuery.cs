using MediatR;

namespace CUS.Cliente.API.Recursos.Queries
{
    public class GetTodosClientesQuery : IRequest<IEnumerable<CUS.Cliente.API.Models.Cliente>>
    {
    }
}
