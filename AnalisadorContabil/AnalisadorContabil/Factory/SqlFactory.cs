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

            sql = VariaveisSistema.AtribuiValorVariaveis(sql, variaveisSistema);

            return new Sql(tabela.Codigo, sql, fonte);
        }
    }
}