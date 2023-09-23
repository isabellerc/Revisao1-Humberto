using Revisão1.Models.CustomValidations.ExemploAPI.Models.CustonValidations;

namespace Revisão1.Models.Request
{
    public class TesteViewModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string Cpf { get; set; }
    }
}
