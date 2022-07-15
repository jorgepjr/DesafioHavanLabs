using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CasosDeUso.Dtos
{
    public class PreVendaDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Documento do cliente")]
        public string DocumentoDoCliente { get; set; }

        public List<ItemPreVendaDto> Itens { get; set; } = new List<ItemPreVendaDto>();
    }
}
