using System;

namespace AnalisadorContabil.Valor
{
    public class ValorNulo : IValor
    {
        public object Objeto()
        {
            return null;
        }

        public String Exibir()
        {
            return string.Empty;
        }
    }
}
