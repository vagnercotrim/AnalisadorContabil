using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.FonteDeDados;
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

        public IComponente Cria(String codigo)
        {
            Tabela tabela = Dados(codigo);
            IFonteDeDados fonte;
            _fontes.TryGetValue(tabela.Fonte, out fonte);

            IComponente componente = null;

            IList<Parametro> tabelaParametros = tabela.ParametrosToList();

            foreach (var tabelaParametro in tabelaParametros)
            {
                if (tabelaParametro.ContemParametro())
                {
                    IList<String> parametros = Parametro.FromString(tabelaParametro.Valor.ToString());

                    foreach (var parametro in parametros)
                    {
                        Tabela tabelaString = Dados(parametro);
                        
                        String codigoTabela = tabelaString.Codigo;
                    }
                }
            }

            if (tabela.Tipo == "formula")
                componente = FormulaFactory(tabela);

            return componente;
        }

        private IComponente FormulaFactory(Tabela tabela)
        {
            String formula = tabela.Get("formula").ToString();

            return new Formula(tabela.Codigo, formula);
        }

        public Tabela Dados(String codigo)
        {
            return _tabelaDao.Get(codigo);
        }
    }
}
