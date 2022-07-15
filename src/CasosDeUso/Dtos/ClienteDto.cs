using System.ComponentModel.DataAnnotations;

namespace CasosDeUso.Dtos
{
    public class ClienteDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Cep { get; set; }
    }
}
