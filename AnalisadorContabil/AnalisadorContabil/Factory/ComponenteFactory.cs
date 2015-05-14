using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using System;
using System.Collections.Generic;

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
                return FormulaFactory.Cria(tabela, variaveis);

            if (tabela.Tipo == "sql")
            {
                IFonteDeDados fonte;
                _fontes.TryGetValue(tabela.Fonte, out fonte);

                return SqlFactory.Cria(tabela, variaveis, fonte);
            }

            return null;
        }

        private Tabela Dados(String codigo)
        {
            return _tabelaDao.Get(codigo);
        }
    }
}
