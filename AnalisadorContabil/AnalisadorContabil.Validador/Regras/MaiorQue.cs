using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Validador.Regras
{
    public class MaiorQue : IRegraValidacao
    {
        private readonly decimal _valor;
        private readonly decimal _limite;

        public MaiorQue(decimal valor, decimal limite)
        {
            _valor = valor;
            _limite = limite;
        }

        public IList<Notificacao> Validar()
        {
            IList<Notificacao> notificacoes = new List<Notificacao>();

            if (!(_valor > _limite))
                 notificacoes.Add(new Notificacao(String.Format("O valor {0} não é maior que {1}.", _valor, _limite), Tipo.Alerta));

            return notificacoes;
        }
    }
}
