using AnalisadorContabil.Dominio;
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
        private readonly Tabela _tabela;
        private Expression _expression;
        
        public Formula(Tabela tabela, IEnumerable<KeyValuePair<string, IValor>> variaveis)
        {
            _tabela = tabela;
            SetExpression(tabela.Get("formula").ToString());
            SetVariaveis(variaveis);
        }

        private void SetExpression(string formula)
        {
            _expression = new Expression(formula);
            _expression.EvaluateFunction += NCalcExtension.Functions;
        }

        public String Id()
        {
            return _tabela.Codigo;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Calcular(), _tabela.Retorno);
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