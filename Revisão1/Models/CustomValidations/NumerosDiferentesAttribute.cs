//using Revisão1.Models.Request;
//using System.ComponentModel.DataAnnotations;

//namespace Revisão1.Models.CustomValidations
//{
//    public class NumerosDiferentesAttribute : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var jogo = (NovoJogoViewModel)validationContext.ObjectInstance;
//            var numeros = new List<int> { jogo.primeiroNro, jogo.segundoNro, jogo.terceiroNro, jogo.quartoNro, jogo.quintoNro, jogo.sextoNro };

//            if (numeros.Distinct().Count() != 6)
//            {
//                return new ValidationResult("Os números não podem ser repetidos.", new[] { "primeiroNro", "segundoNro", "terceiroNro", "quartoNro", "quintoNro", "sextoNro" });
//            }

//            return ValidationResult.Success;
//        }
//    }
       
//}
