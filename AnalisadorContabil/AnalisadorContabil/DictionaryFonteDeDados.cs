using System;
using System.Collections.Generic;

namespace AnalisadorContabil
{
    class DictionaryFonteDeDados : IFonteDeDados
    {
        IDictionary<String, object> dados = new Dictionary<String, object>();

        public DictionaryFonteDeDados()
        {
            dados.Add("C15-0010", "(25 * 3) / 15");
        }

        public object GetDados(String id)
        {
            object valor;
            dados.TryGetValue(id, out valor);

            return valor;
        }
    }
}