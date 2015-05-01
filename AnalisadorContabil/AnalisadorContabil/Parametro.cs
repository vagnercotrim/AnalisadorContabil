using System;

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
    }
}
