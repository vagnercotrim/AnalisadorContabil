using System;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Factory
{
    public class ValorFactory
    {

        public static IValor Cria(object valor, String retorno)
        {
            if (valor is int)
                return new ValorDecimal(valor, retorno);

            if (valor is double)
                return new ValorDouble(valor);

            if (valor is decimal)
                return new ValorDecimal(valor, retorno);

            if (valor is bool)
                return new ValorBooleano(valor);

            if (valor is string)
                return new ValorTexto(valor);

            if (valor is DateTime)
                return new ValorData(valor);

            return new ValorNulo();
        }

    }
}
