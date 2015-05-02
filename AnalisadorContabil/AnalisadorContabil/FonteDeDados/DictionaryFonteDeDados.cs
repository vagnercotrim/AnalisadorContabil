using System;
using System.Collections.Generic;
using AnalisadorContabil.Dominio;

namespace AnalisadorContabil.FonteDeDados
{
    public class DictionaryFonteDeDados : IFonteDeDados
    {
        private readonly IDictionary<String, Tabela> _dados;

        public DictionaryFonteDeDados(IDictionary<String, Tabela> dados)
        {
            _dados = dados;
        }

        public Tabela GetDados(String id)
        {
            try
            {
                Tabela valor;
                _dados.TryGetValue(id, out valor);

                return valor;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}