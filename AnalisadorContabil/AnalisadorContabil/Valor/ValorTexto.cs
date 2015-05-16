using System;

namespace AnalisadorContabil.Valor
{
    public class ValorTexto : IValor
    {
        private readonly String _valor;

        public ValorTexto(object valor)
        {
                _valor = valor.ToString();
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return _valor ?? "";
        }
    }
}