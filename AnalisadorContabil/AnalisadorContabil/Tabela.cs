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
        
        public Tabela(String codigo, String descricao, String tipo, String parametros)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tipo = tipo;
            Parametros = parametros;
        }

        public object Get(String key)
        {
            object value;
            ToDictionary().TryGetValue(key, out value);

            return value;
        }

        public IDictionary<String, object> ToDictionary()
        {
            IList<String> strings = Parametros.Split(';').ToList();
            IDictionary<String, object> dictionary = new Dictionary<String, object>();

            foreach (var s in strings)
            {
                dictionary.Add(ToKeyValuePair(s));
            }

            return dictionary;
        }

        private KeyValuePair<String, object> ToKeyValuePair(String value)
        {
            String[] values = value.Split(':');

            return new KeyValuePair<String, object>(values[0], values[1]);
        }

    }
}
