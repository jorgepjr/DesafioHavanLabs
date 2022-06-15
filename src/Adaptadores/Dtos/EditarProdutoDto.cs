using System.ComponentModel.DataAnnotations;

namespace Adaptadores.Dtos
{
    public class EditarProdutoDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int ProdutoId { get;  set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get;  set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public decimal Preco { get;  set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int Estoque { get;  set; }
    }
}
