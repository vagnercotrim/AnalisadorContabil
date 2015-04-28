using System;
using NCalc;

namespace AnalisadorContabil
{
    public class Formula : IComponente
    {
        private readonly String _id;
        private readonly String _formula;
        private Expression _expression;

        public Formula(String id, String formula)
        {
            _id = id;
            _formula = formula;
        }

        public String Id()
        {
            return _id;
        }

        public object GetValor()
        {
            return Calcular();
        }

        private object Calcular()
        {
            _expression = new Expression(_formula);

            return _expression.Evaluate();
        }
    }
}