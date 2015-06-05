using System;

namespace AnalisadorContabil.Valor
{
    public class ValorData : IValor
    {
        private readonly string _formatador;
        private readonly DateTime _valor;

        public ValorData(object valor, String formatador)
        {
            _formatador = formatador;
            _valor = DateTime.Parse(valor.ToString());
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return string.Format(new System.Globalization.CultureInfo("pt-BR"), _formatador, _valor);
        }
    }
}
