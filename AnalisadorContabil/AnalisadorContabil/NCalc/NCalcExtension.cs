using System;
using NCalc;

namespace AnalisadorContabil.NCalc
{
    public class NCalcExtension
    {
        public static void Functions(string name, FunctionArgs functionArgs)
        {
            if (name == "porcentagem")
            {
                decimal param1 = ConvertoToDecimal(functionArgs.Parameters[0]);
                decimal param2 = ConvertoToDecimal(functionArgs.Parameters[1]);

                functionArgs.Result = Porcentagem(param1, param2);
            }
        }

        private static decimal ConvertoToDecimal(Expression expression)
        {
            return Decimal.Parse(expression.Evaluate().ToString());
        }

        private static decimal Porcentagem(decimal calculo, decimal total)
        {
            return calculo * 100 / total;
        }
    }
}
