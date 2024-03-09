using CUS.Cliente.API.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CUS.Cliente.API.Recursos.Commands
{
    public class ClienteDeleteCommandHandler : IRequestHandler<ClienteDeleteCommand, CUS.Cliente.API.Models.Cliente>
    {
        private readonly AppDbContext _context;

        public ClienteDeleteCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CUS.Cliente.API.Models.Cliente> Handle(ClienteDeleteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _context.Clientes.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            if (cliente is null)
                throw new Exception("Cliente não encontrado na base de dados.");
            
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
