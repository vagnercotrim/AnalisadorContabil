using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Validador.Regras
{
    public class MaiorQue : IRegraValidacao
    {
        private readonly decimal _valor;
        private readonly decimal _limite;
        private readonly IList<Notificacao> _notificacoes;

        public MaiorQue(decimal valor, decimal limite)
        {
            _valor = valor;
            _limite = limite;
            _notificacoes = new List<Notificacao>();
        }

        public void Validar()
        {
            if (!(_valor > _limite))
                _notificacoes.Add(new Notificacao(String.Format("O valor {0} não é maior que {1}.", _valor, _limite), Tipo.Alerta));
        }

        public IList<Notificacao> Notificacoes()
        {
            return _notificacoes;
        }
    }
}
