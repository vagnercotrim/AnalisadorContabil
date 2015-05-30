using System.Collections.Generic;

namespace AnalisadorContabil.Validador
{
    public class Validador
    {
        private readonly IList<IRegraValidacao> _regras;
        private readonly Resultado _resultado;

        public Validador(IList<IRegraValidacao> regras)
        {
            _regras = regras;
            _resultado = new Resultado();
        }

        public Resultado Validar()
        {
            foreach (IRegraValidacao regra in _regras)
            {
                IList<Notificacao> notificacoes = regra.Validar();

                _resultado.AdicionaNotificacao(notificacoes);
            }

            return _resultado;
        }
    }
}
