using Flunt.Notifications;
using MediatR;

namespace CUS.Cliente.API.Recursos.Commands
{
    public abstract class BaseCommand : Notifiable<Notification>, IRequest<CUS.Cliente.API.Models.Cliente>
    {
        public abstract void Validate();

    }
}
