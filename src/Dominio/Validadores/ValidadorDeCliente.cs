using FluentValidation;

namespace Dominio.Validadores
{
    public class ValidadorDeCliente : AbstractValidator<Cliente>
    {
        public ValidadorDeCliente()
        {
            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("Informe a documentação")
                .Length(11, 11).WithMessage("Documento inválido");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("Informe o CEP!")
                .Length(9, 9).WithMessage("CEP inválido");
        }

        public static ValidadorDeCliente Builder => new ValidadorDeCliente();
    }
}
