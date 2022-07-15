using CasosDeUso;

namespace WebApi.Extensions
{
    public static class ErroExtensions
    {
        public static string MensagemDeErro<T>(this T casoDeUso)
        {
            var casoDeUsoBase = casoDeUso as CasoDeUsoBase;

            return casoDeUsoBase.MensagemDoErro;
        }

        public static bool PossuiErro<T>(this T casoDeUso)
        {
            var casoDeUsoBase = casoDeUso as CasoDeUsoBase;

            return casoDeUsoBase.PossuiErro;
        }
    }
}
