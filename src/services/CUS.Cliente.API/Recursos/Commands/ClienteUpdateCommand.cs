using CUS.Cliente.API.Recursos.Contracts;
using MediatR;

namespace CUS.Cliente.API.Recursos.Commands
{
    public class ClienteUpdateCommand : BaseCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public override void Validate()
        {
            AddNotifications(new ClienteUpdateContract(this));
        }
    }
}
