using MediatR;

namespace CUS.Cliente.API.Recursos.Commands
{
    public class ClienteDeleteCommand : IRequest<CUS.Cliente.API.Models.Cliente>
    {
        public int Id { get; set; }
    }
}
