using System;
using System.Collections.Generic;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using NCalc;

namespace AnalisadorContabil.Componente
{
    public class Formula : IComponente
    {
        private readonly String _id;
        private readonly String _formula;
        private readonly IDictionary<string, object> _variaveis;
        private Expression _expression;
        private IFonteDeDados _fonteDeDados;

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

        public IComponente AdicionaFonte(IFonteDeDados fonte)
        {
            _fonteDeDados = fonte;

            return this;
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