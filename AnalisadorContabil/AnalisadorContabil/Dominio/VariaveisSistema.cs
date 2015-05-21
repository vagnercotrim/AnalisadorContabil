using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnalisadorContabil.Dominio
{
    public class VariaveisSistema
    {
        public static String AtribuiValorVariaveis(String sql, IDictionary<String, object> variaveisSistema)
        {
            IEnumerable<string> variaveisList = FromString(sql);

            foreach (var variable in variaveisList)
            {
                object valor;
                variaveisSistema.TryGetValue(SemChaves(variable), out valor);

                if (valor != null) 
                    sql = sql.Replace(variable, valor.ToString());
            }

            return sql;
        }

        private static IEnumerable<string> FromString(String formula)
        {
            MatchCollection matchCollection = Regex.Matches(formula, @"(\{([a-zA-Z]\w+)\})+");

            return (from object match in matchCollection select match.ToString()).ToList();
        }

        private static String SemChaves(String texto)
        {
            return texto.Replace("{", "").Replace("}", "");
        }
    }
}
