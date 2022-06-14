using Dominio;
using System.Collections.Generic;

namespace Adaptadores.Dtos
{
    public class VendaDto
    {
        public string Cliente { get; set; }
        public List<ItemVendaDto> Itens { get; set; }
        public decimal Total { get; set; }
    }
}
