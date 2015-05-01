using System;
using System.Collections.Generic;
using AnalisadorContabil.Valor;
using NCalc;

namespace AnalisadorContabil.Componente
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

        public IValor GetValor()
        {
            object resultado = Calcular();

            if (resultado is int)
                return new ValorDecimal(resultado);

            if (resultado is double)
                return new ValorDouble(resultado);

            if (resultado is decimal)
                return new ValorDecimal(resultado);

            if (resultado is bool)
                return new ValorBooleano(resultado);

            return null;
        }

        private object Calcular()
        {
            _expression = new Expression(_formula);

            if (_formula.Contains("["))
                _expression.Parameters["C14-017"] = new Formula("C14-017", "2.00 + 3.00").GetValor().Objeto();

            return _expression.Evaluate();
        }
    }
}