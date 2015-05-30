using System.Collections.Generic;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using System;

namespace AnalisadorContabil.Componente
{
    public class Sql : IComponente
    {
        private readonly Tabela _tabela;
        private readonly String _sql;
        private readonly IFonteDeDados _fonteDeDados;

        public Sql(Tabela tabela, IDictionary<String, object> variaveisSistema, IFonteDeDados fonteDeDados)
        {
            _tabela = tabela;
            _sql = VariaveisSistema.AtribuiValorVariaveis(tabela.Get("sql").ToString(), variaveisSistema);
            _fonteDeDados = fonteDeDados;
        }

        public String Id()
        {
            return _tabela.Codigo;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Consulta(), _tabela.Retorno);
        }

        private object Consulta()
        {
            return _fonteDeDados.GetDados(_sql);
        }
    }
}