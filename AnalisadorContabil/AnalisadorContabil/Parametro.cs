using System;
using System.Collections.Generic;

namespace AnalisadorContabil
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

        public static IList<String> FromString(String formula)
        {
            return formula.Split('[', ']');
        }
    }
}
