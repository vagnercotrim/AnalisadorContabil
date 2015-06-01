using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnalisadorContabil.Dominio
{
    public class Parametro
    {
        public String Nome { get; set; }
        public object Valor { get; set; }

        public Parametro(String nome, object valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public static IList<String> ReferenciasComponente(String formula)
        {
            MatchCollection matchCollection = Regex.Matches(formula, @"(\[([a-zA-Z0-9_-]+)\])+");

            return (from object match in matchCollection select match.ToString().Replace("[","").Replace("]","")).ToList();
        }

        public bool PossuiReferenciaComponente()
        {
            return ReferenciasComponente(Valor.ToString()).Count > 0;
        }
    }
}
