using System;

namespace AnalisadorContabil.Valor
{
    public class ValorDouble : IValor
    {
        private Double _valor;
        private String _formatador;

        public ValorDouble(object valor, String formatador)
        {
            _formatador = formatador;
            _valor = Double.Parse(valor.ToString());
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
