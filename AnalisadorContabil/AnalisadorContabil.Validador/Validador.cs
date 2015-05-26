using System.Collections.Generic;

namespace AnalisadorContabil.Validador
{
    public class Validador
    {
        private readonly IList<IRegraValidacao> _regras;
        private readonly IList<Notificacao> _notifcacoes; 

        public Validador()
        {
            _regras = new List<IRegraValidacao>();
            _notifcacoes = new List<Notificacao>();
        }

        public void Validar()
        {
            foreach (var regra in _regras)
            {
                regra.Validar();

                foreach (var notificacao in regra.Notificacoes())
                {
                    _notifcacoes.Add(notificacao);
                }
            }
        }

        public void AdicionaRegra(IRegraValidacao regra)
        {
            _regras.Add(regra);
        }

        public IList<Notificacao> Notificacoes()
        {
            return _notifcacoes;
        }
    }
}
