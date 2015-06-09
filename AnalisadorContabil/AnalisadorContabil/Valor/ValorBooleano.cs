using System;

namespace AnalisadorContabil.Valor
{
    public class ValorBooleano : IValor
    {
        private readonly string _formatador;
        private readonly bool _valor;

        public ValorBooleano(object valor, String formatador)
        {
            _formatador = formatador;
            _valor = Boolean.Parse(valor.ToString());
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return string.Format(_formatador, _valor.GetHashCode());
        }
    }
}
