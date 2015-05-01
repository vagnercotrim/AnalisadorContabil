using System;

namespace AnalisadorContabil.Valor
{
    public class ValorDouble : IValor
    {
      private Double? _valor;

        public ValorDouble(object valor)
        {
            try
            {
                Double valorDecimal = Double.Parse(valor.ToString());
                _valor = valorDecimal;
            }
            catch (Exception)
            {
                _valor = null;
            }
        }

        public ValorDouble(Double valor)
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
