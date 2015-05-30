using System;
using System.Collections.Generic;
using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.FonteDeDados;

namespace AnalisadorContabil.Factory
{
    public class SqlFactory
    {

        public static IComponente Cria(Tabela tabela, IDictionary<String, object> variaveisSistema, IFonteDeDados fonte)
        {
            String sql = tabela.Get("sql").ToString();

            return new Sql(tabela.Codigo, sql, tabela.Retorno, variaveisSistema, fonte);
        }
    }
}