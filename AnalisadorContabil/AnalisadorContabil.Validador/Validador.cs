using System.Collections.Generic;
using System.Linq;

namespace AnalisadorContabil.Validador
{
    public class Validador
    {
        private readonly IList<IRegraValidacao> _regras;

        public Validador(IList<IRegraValidacao> regras)
        {
            _regras = regras;
        }

        public IEnumerable<Notificacao> Validar()
        {
            return _regras.SelectMany(regra => regra.Validar());
        }
    }
}
