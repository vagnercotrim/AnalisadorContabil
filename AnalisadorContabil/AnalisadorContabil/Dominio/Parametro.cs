using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool PossuiReferenciaComponente()
        {
            return RegexHelper.ReferenciasComponente(Valor.ToString()).Count > 0;
        }
    }
}
