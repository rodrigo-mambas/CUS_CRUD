using CUS.Cliente.API.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CUS.Cliente.API.Recursos.Queries
{
    public class GetTodosClientesQueryHandler : IRequestHandler<GetTodosClientesQuery, IEnumerable<CUS.Cliente.API.Models.Cliente>>
    {
        private readonly AppDbContext _context;

        public GetTodosClientesQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CUS.Cliente.API.Models.Cliente>> Handle(GetTodosClientesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
