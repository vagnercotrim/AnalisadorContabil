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
        public String Tipo { get; set; }
        public object Valor { get; set; }
        
        public Tabela(String codigo, String descricao, String tipo, String parametros, object valor = null)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tipo = tipo;
            Parametros = parametros;
            Valor = valor;
        }

        public String Get(String key)
        {
            String value;
            ToDictionary().TryGetValue(key, out value);

            return value;
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

        private KeyValuePair<String, String> ToKeyValuePair(String value)
        {
            String[] values = value.Split(':');

            return new KeyValuePair<String, String>(values[0], values[1]);
        }

    }
}
