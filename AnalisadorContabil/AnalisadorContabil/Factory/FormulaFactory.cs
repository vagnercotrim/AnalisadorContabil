using System;
using System.Collections.Generic;
using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;

namespace AnalisadorContabil.Factory
{
    public class FormulaFactory
    {
        public static IComponente Cria(Tabela tabela, IDictionary<String, object> variaveis)
        {
            String formula = tabela.Get("formula").ToString();

            return new Formula(tabela.Codigo, formula, variaveis);
        }
    }
}