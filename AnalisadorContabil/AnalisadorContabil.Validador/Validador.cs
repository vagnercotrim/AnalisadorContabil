using System.Collections.Generic;

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
            foreach (var regra in _regras)
            {
                regra.Validar();

                foreach (var notificacao in regra.Notificacoes())
                    yield return notificacao;
            }
        }
    }
}
