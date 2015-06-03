using NCalc;
using System;

namespace AnalisadorContabil.NCalc
{
    public class ExpressionFactory
    {
        public static Expression Create(String formula)
        {
            Expression expression = new Expression(formula);
            expression.EvaluateFunction += NCalcExtension.Functions;

            return expression;
        }
    }
}
