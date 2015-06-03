using System;

namespace AnalisadorContabil.Valor
{
    public class ValorDecimal : IValor
    {
        private Decimal? _valor;
        private String _formatador;

        public ValorDecimal(object valor, String formatador)
        {
            _formatador = formatador;
            _valor = Decimal.Parse(valor.ToString());
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return _valor == null ? "" : string.Format(_formatador, _valor);
        }
    }
}
