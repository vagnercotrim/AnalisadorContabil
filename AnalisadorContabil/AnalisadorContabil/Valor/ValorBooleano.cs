using System;

namespace AnalisadorContabil.Valor
{
    public class ValorBooleano : IValor
    {
        private readonly bool _valor;

        public ValorBooleano(object valor)
        {
            _valor = Boolean.Parse(valor.ToString());
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return _valor ? "verdadeiro" : "falso";
        }
    }
}
