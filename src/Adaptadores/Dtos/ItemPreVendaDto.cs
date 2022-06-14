using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adaptadores.Dtos
{
    public class ItemPreVendaDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Codigo do Produto")]
        public string CodigoDoProduto { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int Quantidade { get; set; }
    }
}
