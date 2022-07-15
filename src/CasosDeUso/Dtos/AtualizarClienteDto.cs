using System.ComponentModel.DataAnnotations;

namespace CasosDeUso.Dtos
{
    public class AtualizarClienteDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Cep { get; set; }
    }
}
