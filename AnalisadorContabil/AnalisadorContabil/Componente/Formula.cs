using AnalisadorContabil.Factory;
using AnalisadorContabil.Valor;
using NCalc;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Componente
{
    public class Formula : IComponente
    {
        private readonly String _id;
        private readonly String _formula;
        private readonly IDictionary<string, object> _variaveis;
        private Expression _expression;

        public Formula(String id, String formula, IDictionary<String, object> variaveis = null)
        {
            _id = id;
            _formula = formula;
            _variaveis = variaveis;
        }

        public String Id()
        {
            return _id;
        }

        public IValor GetValor()
        {
            object resultado = Calcular();

            return ValorFactory.Cria(resultado);
        }

        private object Calcular()
        {
            _expression = new Expression(_formula);

            if (_variaveis != null)
                foreach (KeyValuePair<string, object> keyValuePair in _variaveis)
                    _expression.Parameters[keyValuePair.Key] = keyValuePair.Value;

            return _expression.Evaluate();
        }
    }
}