﻿using System;
using System.Collections.Generic;
using AnalisadorContabil.Dominio;

namespace AnalisadorContabil.FonteDeDados
{
    public class DictionaryFonteDeDados : IFonteDeDados
    {
        private readonly IDictionary<String, object> _dados;

        public DictionaryFonteDeDados(IDictionary<String, object> dados)
        {
            _dados = dados;
        }

        public object GetDados(String id)
        {
            try
            {
                object valor;
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