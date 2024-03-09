using CUS.Cliente.API.Recursos.Commands;
using Flunt.Validations;

namespace CUS.Cliente.API.Recursos.Contracts
{
    public class ClienteUpdateContract : Contract<ClienteUpdateCommand>
    {
        public ClienteUpdateContract(ClienteUpdateCommand request)
        {
            Requires()
                .IsNotNullOrEmpty(request.Nome, "Nome", "Nome em branco")
                .Matches(request.Nome, "^[a-zA-Z]+$", "Nome", "Nome invalido")
                .Matches(request.Cpf, @"^\d{11}$", "Cpf", "Cpf invalido");

            if (!Validacao(request))
            {
                AddNotification("Cpf", "Cpf incorreto");            
            }      
        }
        static bool Validacao(ClienteUpdateCommand request)
        {
            int[] multiplicadoresPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            request.Cpf = request.Cpf.Trim().Replace(".", "").Replace("-", "");
            if (request.Cpf.Length != 11)
            {
                return false;
            }

            string cpfSemDigitos = request.Cpf.Substring(0, 9);
            string cpfComDigitos = cpfSemDigitos;

            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfSemDigitos[i].ToString()) * multiplicadoresPrimeiroDigito[i];
            }

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;

            cpfComDigitos += primeiroDigito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfComDigitos[i].ToString()) * multiplicadoresSegundoDigito[i];
            }

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;

            cpfComDigitos += segundoDigito;

            return request.Cpf == cpfComDigitos;
        }
    }
}
