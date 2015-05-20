using System;

namespace AnalisadorContabil.Valor
{
    public class ValorData : IValor
    {
        private DateTime? _valor;

        public ValorData(object valor)
        {
            _valor = DateTime.Parse(valor.ToString());
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
