﻿using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Factory
{
    public class ComponenteFactory
    {
        private readonly ITabelaDao _tabelaDao;
        private readonly IDictionary<String, IFonteDeDados> _fontes = new Dictionary<String, IFonteDeDados>();
        private readonly IDictionary<String, object> _variaveisSistema = new Dictionary<String, object>();

        public ComponenteFactory(ITabelaDao tabelaDao)
        {
            _tabelaDao = tabelaDao;
        }

        public void AdicionaVariavelSistema(String nome, object valor)
        {
            _variaveisSistema.Add(nome, valor);
        }

        public void AdicionaFonte(String nome, IFonteDeDados fonte)
        {
            _fontes.Add(nome, fonte);
        }

        private IDictionary<String, IValor> ResolveParametros(IEnumerable<Parametro> tabelaParametros)
        {
            IDictionary<String, IValor> variaveis = new Dictionary<String, IValor>();

            foreach (var tabelaParametro in tabelaParametros)
            {
                if (tabelaParametro.PossuiReferenciaComponente())
                {
                    IList<String> parametros = RegexHelper.ReferenciasComponente(tabelaParametro.Valor.ToString());

                    foreach (var parametro in parametros)
                    {
                        IValor valor = ResolveComponente(parametro);

                        variaveis.Add(parametro, valor);
                    }
                }
            }

            return variaveis;
        }

        private IValor ResolveComponente(string parametro)
        {
            Tabela tabelaString = _tabelaDao.Get(parametro);

            IComponente componente2 = Cria(tabelaString.Codigo);

            IValor valor = componente2.GetValor();
            return valor;
        }

        public IComponente Cria(String codigo)
        {
            Tabela tabela = _tabelaDao.Get(codigo);

            IList<Parametro> tabelaParametros = tabela.Parametros;

            IDictionary<String, IValor> variaveisComponente = ResolveParametros(tabelaParametros);

            if (tabela.Tipo == "formula")
                return FormulaFactory.Cria(tabela, variaveisComponente);

            if (tabela.Tipo == "sql")
                return SqlFactory.Cria(tabela, _variaveisSistema, Fonte(tabela));

            if (tabela.Tipo == "rest")
                return RestFactory.Cria(tabela, _variaveisSistema, Fonte(tabela));
            
            if (tabela.Tipo == "xml")
                return XmlFactory.Cria(tabela, _variaveisSistema, Fonte(tabela));

            return null;
        }

        private IFonteDeDados Fonte(Tabela tabela)
        {
            IFonteDeDados fonte;
            _fontes.TryGetValue(tabela.Fonte, out fonte);

            return fonte;
        }
    }
}
