using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.FonteDeDados;
using System.Collections.Generic;

namespace AnalisadorContabil.Factory
{
    public class RestFactory
    {
        public static Rest Cria(Tabela tabela, IDictionary<string, object> variaveisSistema, IFonteDeDados fonte)
        {
            return new Rest(tabela, variaveisSistema, fonte);
        }
    }
}