using CUS.Cliente.API.Context;
using Flunt.Notifications;
using MediatR;

namespace CUS.Cliente.API.Recursos.Commands
{
    public class ClienteUpdateCommandHandler : Notifiable<Notification>,IRequestHandler<ClienteUpdateCommand, CUS.Cliente.API.Models.Cliente>
    {
        private readonly AppDbContext _context;

        public ClienteUpdateCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CUS.Cliente.API.Models.Cliente> Handle(ClienteUpdateCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (!request.IsValid)
            {
                string errorMessage = string.Join(", ", request.Notifications.ToList().Select(x => x.Message));
                throw new Exception(errorMessage);
            }

            var cliente = _context.Clientes.Where(a => a.Id == request.Id).FirstOrDefault();
            if (cliente is null)
            {
                throw new Exception("Cliente nao encontrado na base de dados.");
            }
            else
            {
                cliente.Nome = request.Nome;
                cliente.Cpf = request.Cpf;
                await _context.SaveChangesAsync();
                return cliente;
            }
        }
    }
}
