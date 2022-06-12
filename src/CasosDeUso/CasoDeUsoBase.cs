using System.Collections.Generic;
using System.Net;

namespace CasosDeUso
{
    public abstract class CasoDeUsoBase
    {
        public Dictionary<string, string> Erros { get; set; } = new Dictionary<string, string>();
    }
}
