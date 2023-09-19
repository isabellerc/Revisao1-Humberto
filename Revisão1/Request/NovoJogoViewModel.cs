using System.ComponentModel.DataAnnotations;

namespace Revisão1.Request
{
    public class NovoJogoViewModel
    {
        [Required(ErrorMessage = "Descrição é obrigatória")]
        [MinLength(3, ErrorMessage = "A Descrição precisa de no mínimo 3 letras")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Preço deve ser maior ou igual a zero")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Estoque é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Estoque deve ser maior ou igual a zero")]
        public decimal Estoque { get; set; }
        [Required(ErrorMessage = "Ativo é obrigatório")]
        public bool Ativo { get; set; }
    }
}
