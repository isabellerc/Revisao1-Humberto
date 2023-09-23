using Revisão1.Models.CustomValidations.ExemploAPI.Models.CustonValidations;
using System.ComponentModel.DataAnnotations;

namespace Revisão1.Models.Request
{
    public class NovoJogoViewModel

    {
        public int Codigo { get; set; }
       [Required(ErrorMessage = "O nome é obrigatório")]
       [MinLength(3, ErrorMessage = "O nome precisa de no mínimo 3 letras")]
       [MaxLength(255, ErrorMessage = "O nome pode ser no máximo 255 letras")]
        public string Nome { get; set; }

        public int Idade { get; set; }  

        [CpfValidation]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public int primeiroNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public int segundoNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public int terceiroNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public int quartoNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public int quintoNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public int sextoNro { get; set; }

        public string dataJogo { get; set; }


        //[Required(ErrorMessage = "Descrição é obrigatória")]
        //[MinLength(3, ErrorMessage = "A Descrição precisa de no mínimo 3 letras")]
        //public string Descricao { get; set; }

        //[Required(ErrorMessage = "Preço é obrigatório")]
        //[Range(0, double.MaxValue, ErrorMessage = "Preço deve ser maior ou igual a zero")]
        //public decimal Preco { get; set; }
        //[Required(ErrorMessage = "Estoque é obrigatório")]
        //[Range(0, double.MaxValue, ErrorMessage = "Estoque deve ser maior ou igual a zero")]
        //public decimal Estoque { get; set; }
        //[Required(ErrorMessage = "Ativo é obrigatório")]
        //public bool Ativo { get; set; }


    }

}
