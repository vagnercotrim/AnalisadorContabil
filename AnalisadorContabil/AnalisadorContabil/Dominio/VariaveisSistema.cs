using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnalisadorContabil.Dominio
{
    public class VariaveisSistema
    {
        public static String AtribuiValorVariaveis(String texto, IDictionary<String, object> variaveisSistema)
        {
            IEnumerable<string> variaveisList = FromString(texto);

            foreach (var variable in variaveisList)
            {
                object valor;
                variaveisSistema.TryGetValue(SemChaves(variable), out valor);

                if (valor != null) 
                    texto = texto.Replace(variable, valor.ToString());
            }

            return texto;
        }

        private static IEnumerable<string> FromString(String texto)
        {
            MatchCollection matchCollection = Regex.Matches(texto, @"(\{([a-zA-Z]\w+)\})+");

            return (from object match in matchCollection select match.ToString()).ToList();
        }

        private static String SemChaves(String texto)
        {
            return texto.Replace("{", "").Replace("}", "");
        }
    }
}
