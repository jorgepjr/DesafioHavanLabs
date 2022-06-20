using System.Collections.Generic;
using System.Linq;

namespace CasosDeUso
{
    public abstract class CasoDeUsoBase
    {
        public Dictionary<string, string> Erros { get; set; } = new Dictionary<string, string>();

        public bool PossuiErro => Erros.Any();

        public string MensagemDoErro => Erros.FirstOrDefault().Value;
    }
}
