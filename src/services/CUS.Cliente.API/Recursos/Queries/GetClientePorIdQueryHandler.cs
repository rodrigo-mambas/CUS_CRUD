using CUS.Cliente.API.Context;
using CUS.Cliente.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CUS.Cliente.API.Recursos.Queries
{
    public class GetClientePorIdQueryHandler : IRequestHandler<GetClientePorIdQuery, CUS.Cliente.API.Models.Cliente>
    {
        private readonly AppDbContext _context;

        public GetClientePorIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CUS.Cliente.API.Models.Cliente> Handle(GetClientePorIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
