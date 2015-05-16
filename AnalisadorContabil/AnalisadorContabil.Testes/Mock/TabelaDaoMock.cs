using System;
using System.Collections.Generic;
using AnalisadorContabil.Dominio;

namespace AnalisadorContabil.Testes.Mock
{
    public class TabelaDaoMock : ITabelaDao
    {
        private readonly IDictionary<string, Tabela> _dados;

        public TabelaDaoMock(IDictionary<String, Tabela> dados)
        {
            _dados = dados;
        }

        public Tabela Get(String codigo)
        {
            try
            {
                Tabela valor;
                _dados.TryGetValue(codigo, out valor);

                return valor;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
