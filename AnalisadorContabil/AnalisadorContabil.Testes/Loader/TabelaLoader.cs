using AnalisadorContabil.Dominio;
using System;
using System.Collections.Generic;
using AnalisadorContabil.Testes.Mock;

namespace AnalisadorContabil.Testes.Loader
{
    public class TabelaLoader
    {
        private readonly IDictionary<String, Tabela> _dados;

        public TabelaLoader()
        {
            _dados = new Dictionary<String, Tabela>
            {
                { "C15N0010", new Tabela("C15N0010", null, "formula", "dictionary", new Parametro("formula", "(25 * 3)")) },
                { "C15N0011", new Tabela("C15N0011", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] / 15")) },
                { "C15N0013", new Tabela("C15N0013", null, "formula", "dictionary", new Parametro("formula", "[C15N0011] * 3")) },
                { "C15N0014", new Tabela("C15N0014", null, "formula", "dictionary", new Parametro("formula", "5 * 5")) },
                { "C15N0015", new Tabela("C15N0015", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] + [C15N0014]")) },
                { "C15N0016", new Tabela("C15N0016", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] + [C15N0013]")) },
                { "C15N0027", new Tabela("C15N0027", null, "sql",     "dictionary", new List<Parametro> { new Parametro("tabela", "tabela"), new Parametro("campo", "campo"), new Parametro("condicao", "condicao"), new Parametro("valor", "'02.01.03'") }) },
                { "C15N0028", new Tabela("C15N0028", null, "formula", "dictionary", new Parametro("formula", "[C15N0027] - 23000")) },
            };
        }

        public ITabelaDao CriaTabelaDaoMock()
        {
            return new TabelaDaoMock(_dados);
        }
    }
}
