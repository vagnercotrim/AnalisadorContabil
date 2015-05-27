using System.Collections.Generic;
using System.Linq;

namespace AnalisadorContabil.Validador
{
    public class Resultado
    {
        private readonly IList<Notificacao> _notificacoes;

        public Resultado()
        {
            _notificacoes = new List<Notificacao>();
        }

        public IList<Notificacao> Notificacoes
        {
            get { return _notificacoes; }
        }

        public void AdicionaNotificacao(IList<Notificacao> notificacoes)
        {
            foreach (var notificacao in notificacoes)
                _notificacoes.Add(notificacao);
        }

        public bool Valido
        {
            get { return !_notificacoes.Any(); }
        }
    }
}
