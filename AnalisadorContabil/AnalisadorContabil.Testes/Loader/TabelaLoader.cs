using AnalisadorContabil.Dominio;
using AnalisadorContabil.Testes.Mock;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Testes.Loader
{
    public class TabelaLoader
    {
        private readonly IDictionary<String, Tabela> _dados;

        public TabelaLoader()
        {
            _dados = new Dictionary<String, Tabela>
            {
                { "C15N0050", new Tabela("C15N0050", null, "sql",       "sqlite",     "monetario",    new List<Parametro> { new Parametro("sql", "SELECT ValorReceita FROM Conta WHERE Numero = '01.02.03.01' and Empresa = {empresa} and Ano = {ano} and Periodo = {periodo}")})},
                { "C15N0051", new Tabela("C15N0051", null, "sql",       "sqlite",     "monetario",    new Parametro("sql", "SELECT ValorDespesa FROM Conta WHERE Numero = '01.02.03.01' and Empresa = {empresa} and Ano = {ano} and Periodo = {periodo}"))},
                { "C15N0052", new Tabela("C15N0052", null, "sql",       "sqlite",     "monetario",    new Parametro("sql", "SELECT ValorDespesa FROM Conta WHERE Numero = '99.99.99.99' and Empresa = {empresa} and Ano = {ano} and Periodo = {periodo}"))},
                { "C15N0060", new Tabela("C15N0060", null, "formula",   null,         "monetario",    new Parametro("formula", "[C15N0050] - [C15N0051]"))},
                { "C15N0061", new Tabela("C15N0061", null, "formula",   null,         "texto",        new Parametro("formula", "[C15N0060] > 0 ? 'lucro' : 'prejuizo'"))},
                { "C15N0062", new Tabela("C15N0062", null, "formula",   null,         "porcentagem",  new Parametro("formula", "porcentagem([C15N0050], 150.00)"))},
                { "C15N0101", new Tabela("C15N0101", null, "rest",      "api",        "texto",        new Parametro("recurso", "api/values/1")) },
                { "C15N0102", new Tabela("C15N0102", null, "rest",      "api",        "data",         new Parametro("recurso", "api/data")) },
                { "C15N0103", new Tabela("C15N0103", null, "rest",      "api",        "monetario",    new Parametro("recurso", "api/meta")) },
                { "C15N0010", new Tabela("C15N0010", null, "formula",   null,         "numerico",     new Parametro("formula", "(25 * 3)")) },
                { "C15N0011", new Tabela("C15N0011", null, "formula",   null,         "numerico",     new Parametro("formula", "[C15N0010] / 15")) },
                { "C15N0013", new Tabela("C15N0013", null, "formula",   null,         "numerico",     new Parametro("formula", "[C15N0011] * 3")) },
                { "C15N0014", new Tabela("C15N0014", null, "formula",   null,         "numerico",     new Parametro("formula", "5 * 5")) },
                { "C15N0015", new Tabela("C15N0015", null, "formula",   null,         "numerico",     new Parametro("formula", "[C15N0010] + [C15N0014]")) },
                { "C15N0016", new Tabela("C15N0016", null, "formula",   null,         "numerico",     new Parametro("formula", "[C15N0010] + [C15N0013]")) },
                { "C15N0028", new Tabela("C15N0028", null, "formula",   null,         "numerico",     new Parametro("formula", "[C15N0027] - 23000")) },
                { "C15N0029", new Tabela("C15N0029", null, "formula",   null,         "booleano",     new Parametro("formula", "[C15N0050] > [C15N0103]")) },
                { "C15N0030", new Tabela("C15N0030", null, "formula",   null,         "booleano",     new Parametro("formula", "nulo([C15N0052])")) },
                { "C15N0031", new Tabela("C15N0031", null, "formula",   null,         "booleano",     new Parametro("formula", "nulo([C15N0050])")) },

                { "C15N0041", new Tabela("C15N0041", null, "xml",       "xml",        "decimal",      new List<Parametro>{ new Parametro("arquivo", "resumodomes.xml"), new Parametro("consulta", "gostocomenergia")})}
            };
        }

        public ITabelaDao CriaTabelaDaoMock()
        {
            return new TabelaDaoMock(_dados);
        }
    }
}
