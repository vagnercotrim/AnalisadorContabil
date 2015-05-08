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

        private IDictionary<String, object> ResolveParametros(IEnumerable<Parametro> tabelaParametros)
        {
            IDictionary<String, object> variaveis = new Dictionary<String, object>();
            
            foreach (var tabelaParametro in tabelaParametros)
            {
                if (tabelaParametro.ContemParametro())
                {
                    IList<String> parametros = Parametro.FromString(tabelaParametro.Valor.ToString());

                    foreach (var parametro in parametros)
                    {
                        IValor valor = ResolveComponente(parametro);

                        variaveis.Add(parametro, valor.Objeto());
                    }
                }
            }

            return variaveis;
        }

        private IValor ResolveComponente(string parametro)
        {
            Tabela tabelaString = Dados(parametro);

            IComponente componente2 = Cria(tabelaString.Codigo);

            IValor valor = componente2.GetValor();
            return valor;
        }

        public IComponente Cria(String codigo)
        {
            Tabela tabela = Dados(codigo);

            IList<Parametro> tabelaParametros = tabela.ParametrosToList();

            IDictionary<String, object> variaveis = ResolveParametros(tabelaParametros);

            if (tabela.Tipo == "formula")
                return FormulaFactory(tabela, variaveis);

            if (tabela.Tipo == "sql")
            {
                IFonteDeDados fonte;
                _fontes.TryGetValue(tabela.Fonte, out fonte);
                
                return SqlFactory(tabela, variaveis).AdicionaFonte(fonte);
            }

            return null;
        }

        private IComponente FormulaFactory(Tabela tabela, IDictionary<String, object> variaveis)
        {
            String formula = tabela.Get("formula").ToString();

            return new Formula(tabela.Codigo, formula, variaveis);
        }

        private IComponente SqlFactory(Tabela tabela, IDictionary<String, object> variaveis)
        {
            String sql;

            if (tabela.Get("sql") == null)
            {
                String nomecampo = tabela.Get("campo").ToString();
                String nometabela = tabela.Get("tabela").ToString();
                String campocondicao = tabela.Get("condicao").ToString();
                String campovalor = tabela.Get("valor").ToString();

                sql = String.Format("select {0} from {1} where {2} = {3}", nomecampo, nometabela, campocondicao, campovalor);
            }
            else
            {
                sql = tabela.Get("sql").ToString();
            }

            return new Sql(tabela.Codigo, sql, variaveis);
        }

        private Tabela Dados(String codigo)
        {
            return _tabelaDao.Get(codigo);
        }
    }
}
