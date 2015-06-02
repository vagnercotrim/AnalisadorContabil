using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnalisadorContabil
{
    public class RegexHelper
    {
        public static IList<String> ReferenciasComponente(String texto)
        {
            MatchCollection matchCollection = Regex.Matches(texto, @"(\[([a-zA-Z0-9_-]+)\])+");

            return (from object match in matchCollection select match.ToString().Replace("[", "").Replace("]", "")).ToList();
        }

    }
}
