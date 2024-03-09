using CUS.Cliente.API.Models;
using MediatR;

namespace CUS.Cliente.API.Recursos.Queries
{
    public class GetClientePorCpfQuery : IRequest<CUS.Cliente.API.Models.Cliente>
    {
        public string Cpf { get; set; }
    }
}
