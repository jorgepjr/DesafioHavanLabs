using System.ComponentModel.DataAnnotations;

namespace CasosDeUso.Dtos
{
    public class ProdutoDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int Quantidade { get; set; }
    }
}
