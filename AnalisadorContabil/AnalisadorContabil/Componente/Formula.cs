using AnalisadorContabil.Factory;
using AnalisadorContabil.NCalc;
using AnalisadorContabil.Valor;
using NCalc;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Componente
{
    public class Formula : IComponente
    {
        private readonly String _id;
        private Expression _expression;

        public Formula(String id, String formula, IEnumerable<KeyValuePair<string, IValor>> variaveis)
        {
            _id = id;
            SetExpression(formula);
            SetVariaveis(variaveis);
        }

        private void SetExpression(string formula)
        {
            _expression = new Expression(formula);
            _expression.EvaluateFunction += NCalcExtension.Functions;
        }

        public String Id()
        {
            return _id;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Calcular());
        }

        private object Calcular()
        {

            return _expression.Evaluate();
        }

        private void SetVariaveis(IEnumerable<KeyValuePair<string, IValor>> variaveis)
        {
            if (variaveis != null)
                foreach (KeyValuePair<string, IValor> keyValuePair in variaveis)
                    _expression.Parameters[keyValuePair.Key] = keyValuePair.Value.Objeto();
        }
    }
}