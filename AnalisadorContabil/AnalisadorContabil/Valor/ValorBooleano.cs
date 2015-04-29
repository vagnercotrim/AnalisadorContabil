using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorContabil.Valor
{
    public class ValorBooleano : IValor
    {
        private bool _valor;

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

        public String Exibir()
        {
            return _valor ? "verdadeiro" : "falso";
        }
    }
}
