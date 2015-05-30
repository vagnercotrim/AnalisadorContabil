using System;
using System.Collections.Generic;
using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.FonteDeDados;

namespace AnalisadorContabil.Factory
{
    public class XmlFactory
    {
        public static IComponente Cria(Tabela tabela, IDictionary<String, object> variaveisSistema, IFonteDeDados fonte)
        {
            String arquivo = tabela.Get("arquivo").ToString();
            String consulta = tabela.Get("consulta").ToString();

            return new Xml(tabela.Codigo, arquivo, consulta, tabela.Retorno, fonte);
        }
    }
}
