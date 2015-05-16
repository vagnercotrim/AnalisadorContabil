using AnalisadorContabil.Dominio;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Testes.Loader
{
    public class TabelaLoader
    {
        private IDictionary<String, Tabela> _dados;

        public TabelaLoader()
        {
            _dados = new Dictionary<String, Tabela>();

            Tabela tabela1 = new Tabela("C15N0010", null, "formula", "dictionary", new Parametro("formula", "(25 * 3)"));
            _dados.Add("C15N0010", tabela1);

            Tabela tabela2 = new Tabela("C15N0011", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] / 15"));
            _dados.Add("C15N0011", tabela2);

            Tabela tabela3 = new Tabela("C15N0013", null, "formula", "dictionary", new Parametro("formula", "[C15N0011] * 3"));
            _dados.Add("C15N0013", tabela3);

            Tabela tabela4 = new Tabela("C15N0014", null, "formula", "dictionary", new Parametro("formula", "5 * 5"));
            _dados.Add("C15N0014", tabela4);

            Tabela tabela5 = new Tabela("C15N0015", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] + [C15N0014]"));
            _dados.Add("C15N0015", tabela5);

            Tabela tabela6 = new Tabela("C15N0016", null, "formula", "dictionary", new Parametro("formula", "[C15N0010] + [C15N0013]"));
            _dados.Add("C15N0016", tabela6);

            Tabela tabela7 = new Tabela("C15N0027", null, "sql", "dictionary",
                new List<Parametro>
                {
                    new Parametro("tabela", "tabela"),
                    new Parametro("campo", "campo"),
                    new Parametro("condicao", "condicao"),
                    new Parametro("valor", "'02.01.03'")
                });
            _dados.Add("C15N0027", tabela7);

            Tabela tabela8 = new Tabela("C15N0028", null, "formula", "dictionary", new Parametro("formula", "[C15N0027] - 23000"));
            _dados.Add("C15N0028", tabela8);
        }

        public TabelaDAO CriaTabelaDaoMock()
        {
            return new TabelaDAO(_dados);
        }
    }
}
