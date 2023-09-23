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
        [Range(18, 110, ErrorMessage = "A idade mínima deve ser 18 anos.")]
        public int Idade { get; set; }

        [CpfValidation]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60.")]


        public int primeiroNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60.")]

        public int segundoNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60.")]



        public int terceiroNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60.")]


        public int quartoNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60.")]



        public int quintoNro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60.")]

        public int sextoNro { get; set; }
        public string dataJogo { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validar se os números não são iguais
            if (!NumerosValidos())
            {
                yield return new ValidationResult("Os números não podem ser iguais.");
            }

        }

        public bool NumerosValidos()
        {
            return primeiroNro != segundoNro &&
                   primeiroNro != terceiroNro &&
                   primeiroNro != quartoNro &&
                   primeiroNro != quintoNro &&
                   primeiroNro != sextoNro &&
                   segundoNro != terceiroNro &&
                   segundoNro != quartoNro &&
                   segundoNro != quintoNro &&
                   segundoNro != sextoNro &&
                   terceiroNro != quartoNro &&
                   terceiroNro != quintoNro &&
                   terceiroNro != sextoNro &&
                   quartoNro != quintoNro &&
                   quartoNro != sextoNro &&
                   quintoNro != sextoNro;
        }
    }
}

        
  
