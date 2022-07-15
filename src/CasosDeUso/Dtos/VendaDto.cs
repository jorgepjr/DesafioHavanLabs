using System.Collections.Generic;

namespace CasosDeUso.Dtos
{
    public class VendaDto
    {
        public string Cliente { get; set; }
        public List<ItemVendaDto> Itens { get; set; }
        public decimal Total { get; set; }
    }
}
