using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CUS.Cliente.API.Models
{
    [ExcludeFromCodeCoverage]
    public class Cliente
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string Nome { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }
        //public DateTime DataNascimento { get; set; }
    }
}
