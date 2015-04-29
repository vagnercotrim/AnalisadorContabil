using System;

namespace AnalisadorContabil
{
    public class Tabela
    {
        public String Codigo { get; set; }
        public String Descricao { get; set; }
        public String Parametros { get; set; }
        public object Valor { get; set; }

        public Tabela(String codigo, object valor)
        {
            Codigo = codigo;
            Valor = valor;
        }
    }
}
