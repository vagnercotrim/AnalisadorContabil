using System;
using System.Collections.Generic;
using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Factory
{
    public class FormulaFactory
    {
        public static IComponente Cria(Tabela tabela, IDictionary<String, IValor> variaveis)
        {
            return new Formula(tabela, variaveis);
        }
    }
}