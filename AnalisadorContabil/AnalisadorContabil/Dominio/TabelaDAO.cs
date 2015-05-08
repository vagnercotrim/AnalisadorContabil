using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Dominio
{
    public class TabelaDAO
    {
        private readonly IDictionary<string, Tabela> _dados;

        public TabelaDAO(IDictionary<String, Tabela> dados)
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
