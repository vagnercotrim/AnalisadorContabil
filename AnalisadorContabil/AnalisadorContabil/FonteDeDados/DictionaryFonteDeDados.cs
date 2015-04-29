using System;
using System.Collections.Generic;

namespace AnalisadorContabil.FonteDeDados
{
    public class DictionaryFonteDeDados : IFonteDeDados
    {
        private readonly IDictionary<String, Tabela> _dados;

        public DictionaryFonteDeDados(IDictionary<String, Tabela> dados)
        {
            _dados = dados;
        }

        public object GetDados(String id)
        {
            Tabela valor;
            _dados.TryGetValue(id, out valor);

            return valor.Valor;
        }
    }
}