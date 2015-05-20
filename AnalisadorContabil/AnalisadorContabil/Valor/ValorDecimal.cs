using System;

namespace AnalisadorContabil.Valor
{
    public class ValorDecimal : IValor
    {
        private Decimal? _valor;

        public ValorDecimal(object valor)
        {
            _valor = Decimal.Parse(valor.ToString());
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return _valor == null ? "" : _valor.Value.ToString("n2");
        }
    }
}
