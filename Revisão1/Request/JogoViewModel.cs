using Revisão1.Models.CustomValidations.ExemploAPI.Models.CustonValidations;

namespace Revisão1.Request
{
    public class JogoViewModel
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        [CpfValidationAttribute]
        public string Cpf { get; set; }
    }
}
