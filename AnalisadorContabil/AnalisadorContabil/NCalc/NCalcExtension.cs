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
                decimal param1 = Decimal.Parse(functionArgs.Parameters[0].Evaluate().ToString());
                decimal param2 = Decimal.Parse(functionArgs.Parameters[1].Evaluate().ToString());

                functionArgs.Result = param1 * 100 / param2;
            }
        }
    }
}
