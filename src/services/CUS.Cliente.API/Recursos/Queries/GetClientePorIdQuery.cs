using CUS.Cliente.API.Models;
using MediatR;

namespace CUS.Cliente.API.Recursos.Queries
{
    public class GetClientePorIdQuery : IRequest<CUS.Cliente.API.Models.Cliente>
    {
        public int Id { get; set; }
    }
}
