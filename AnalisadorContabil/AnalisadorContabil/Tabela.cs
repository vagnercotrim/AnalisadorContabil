using System;
using System.Collections.Generic;
using System.Linq;

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

        public Tabela(String codigo, String descricao, String parametros, object valor)
        {
            Codigo = codigo;
            Descricao = descricao;
            Parametros = parametros;
            Valor = valor;
        }

        public IDictionary<String, String> ToDictionary()
        {
            IList<String> strings = Parametros.Split(';').ToList();
            IDictionary<String, String> dictionary = new Dictionary<String, String>();

            foreach (var s in strings)
            {
                dictionary.Add(ToKeyValuePair(s));
            }

            return dictionary;
        }

        public KeyValuePair<String, String> ToKeyValuePair(String value)
        {
            String[] values = value.Split(':');

            return new KeyValuePair<String, String>(values[0], values[1]);
        }

    }
}
