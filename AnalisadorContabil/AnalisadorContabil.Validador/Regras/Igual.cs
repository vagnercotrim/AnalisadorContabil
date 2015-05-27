using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Validador.Regras
{
    public class Igual : IRegraValidacao
    {
        private readonly decimal _valor;
        private readonly decimal _limite;

        public Igual(decimal valor, decimal limite)
        {
            _valor = valor;
            _limite = limite;
        }

        public IEnumerable<Notificacao> Validar()
        {
            if (_valor != _limite)
                yield return new Notificacao(String.Format("O valor {0} não é igual a {1}.", _valor, _limite), Tipo.Alerta);
        }
    }
}
