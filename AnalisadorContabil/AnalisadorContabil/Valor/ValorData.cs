using System;

namespace AnalisadorContabil.Valor
{
    public class ValorData : IValor
    {
        private DateTime? _valor;

        public ValorData(object valor)
        {
            try
            {
                DateTime valorDecimal = DateTime.Parse(valor.ToString());
                _valor = valorDecimal;
            }
            catch (Exception)
            {
                _valor = null;
            }
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return _valor == null ? "" : _valor.Value.ToShortDateString();
        }
    }
}
