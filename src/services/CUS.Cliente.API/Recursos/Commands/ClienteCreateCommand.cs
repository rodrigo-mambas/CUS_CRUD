using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Contracts;
using Flunt.Notifications;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CUS.Cliente.API.Recursos.Commands
{
    public class ClienteCreateCommand : BaseCommand
    {

        public string Nome { get; set; }
        public string Cpf { get; set; }

        public override void Validate()
        {
            AddNotifications(new ClienteCreateContract(this));
        }


        //public DateTime DataNascimento { get; set; }


    }
}
