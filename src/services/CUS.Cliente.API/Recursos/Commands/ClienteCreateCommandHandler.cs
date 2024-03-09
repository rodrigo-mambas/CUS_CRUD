using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Contracts;
using CUS.Cliente.API.Recursos.Queries;
using Flunt.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;

namespace CUS.Cliente.API.Recursos.Commands
{
    public class ClienteCreateCommandHandler : Notifiable<Notification>, IRequestHandler<ClienteCreateCommand, CUS.Cliente.API.Models.Cliente>

    {
        private readonly AppDbContext _context;
        private readonly GetClientePorCpfQueryHandler _getClientePorCpfQueryHandler;

        //public ClienteCreateCommandHandler(AppDbContext context, GetClientePorCpfQueryHandler getClientePorCpfQueryHandler)
        public ClienteCreateCommandHandler(AppDbContext context)
        {
            _context = context;
            //_getClientePorCpfQueryHandler = getClientePorCpfQueryHandler;
        }

        public async Task<CUS.Cliente.API.Models.Cliente> Handle(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            await Validacao(request, cancellationToken);

            var cliente = new CUS.Cliente.API.Models.Cliente();

            cliente.Nome = request.Nome;
            cliente.Cpf = request.Cpf;

            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();
            return cliente;
        }

        private async Task Validacao(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            var clientePorCPf = new GetClientePorCpfQuery();
            clientePorCPf.Cpf = request.Cpf;
            //var result = await _getClientePorCpfQueryHandler.Handle(clientePorCPf, cancellationToken);

            //if (result is not null)
            //    request.AddNotification("Cpf", "Cpf já existente");

            if (!request.IsValid)
            {
                string errorMessage = string.Join(", ", request.Notifications.ToList().Select(x => x.Message));
                throw new Exception(errorMessage);
            }
        }
    }
}
