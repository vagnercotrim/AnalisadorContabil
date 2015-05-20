using System;

namespace AnalisadorContabil.Valor
{
    public class ValorDouble : IValor
    {
        private Double? _valor;

        public ValorDouble(object valor)
        {
            _valor = Double.Parse(valor.ToString());
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
