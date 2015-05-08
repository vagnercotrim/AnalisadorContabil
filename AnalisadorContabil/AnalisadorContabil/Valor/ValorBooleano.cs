using System;

namespace AnalisadorContabil.Valor
{
    public class ValorBooleano : IValor
    {
        private readonly bool _valor;

        public ValorBooleano(object valor)
        {
            try
            {
                Boolean valorDecimal = Boolean.Parse(valor.ToString());
                _valor = valorDecimal;
            }
            catch (Exception)
            {
                _valor = false;
            }
        }

        public ValorBooleano(bool valor)
        {
            _valor = valor;
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return _valor ? "verdadeiro" : "falso";
        }
    }
}
