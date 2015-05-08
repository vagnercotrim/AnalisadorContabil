using System;

namespace AnalisadorContabil.Valor
{
    public class ValorDecimal : IValor
    {
        private Decimal? _valor;

        public ValorDecimal(object valor)
        {
            try
            {
                Decimal valorDecimal = Decimal.Parse(valor.ToString());
                _valor = valorDecimal;
            }
            catch (Exception)
            {
                _valor = null;
            }
        }

        public ValorDecimal(Decimal valor)
        {
            _valor = valor;
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
