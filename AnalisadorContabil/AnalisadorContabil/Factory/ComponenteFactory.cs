using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.FonteDeDados;
using System;
using System.Collections.Generic;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Factory
{
    public class ComponenteFactory
    {
        private readonly TabelaDAO _tabelaDao;
        private readonly IDictionary<String, IFonteDeDados> _fontes = new Dictionary<String, IFonteDeDados>();

        public ComponenteFactory(TabelaDAO tabelaDao)
        {
            _tabelaDao = tabelaDao;
        }

        public void AdicionaFonte(String nome, IFonteDeDados fonte)
        {
            _fontes.Add(nome, fonte);
        }

        public IComponente Cria(String codigo)
        {
            Tabela tabela = Dados(codigo);

            IComponente componente = null;

            IList<Parametro> tabelaParametros = tabela.ParametrosToList();

            IDictionary<String, object> variaveis = new Dictionary<string, object>();

            foreach (var tabelaParametro in tabelaParametros)
            {
                if (tabelaParametro.ContemParametro())
                {
                    IList<String> parametros = Parametro.FromString(tabelaParametro.Valor.ToString());

                    foreach (var parametro in parametros)
                    {
                        Tabela tabelaString = Dados(parametro);

                        IComponente componente2 = Cria(tabelaString.Codigo);

                        IValor valor = componente2.GetValor();

                        variaveis.Add(parametro, valor.Objeto());
                    }
                }
            }

            if (tabela.Tipo == "formula")
                componente = FormulaFactory(tabela, variaveis);

            if (tabela.Tipo == "sql")
            {
                IFonteDeDados fonte;
                _fontes.TryGetValue(tabela.Fonte, out fonte);

                componente = SqlFactory(tabela, variaveis).AdicionaFonte(fonte);
            }
            return componente;
        }

        private IComponente FormulaFactory(Tabela tabela, IDictionary<String, object> variaveis)
        {
            String formula = tabela.Get("formula").ToString();

            return new Formula(tabela.Codigo, formula, variaveis);
        }

        private IComponente SqlFactory(Tabela tabela, IDictionary<String, object> variaveis)
        {
            String sql = tabela.Get("sql").ToString();

            return new Sql(tabela.Codigo, sql, variaveis);
        }

        public Tabela Dados(String codigo)
        {
            return _tabelaDao.Get(codigo);
        }
    }
}
