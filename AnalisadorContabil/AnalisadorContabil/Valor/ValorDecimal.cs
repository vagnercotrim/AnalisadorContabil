﻿using System;

namespace AnalisadorContabil.Valor
{
    public class ValorDecimal : IValor
    {
        private readonly Decimal _valor;
        private readonly String _formatador;

        public ValorDecimal(object valor, String formatador)
        {
            _formatador = formatador;
            _valor = Decimal.Parse(valor.ToString());
        }

        public object Objeto()
        {
            return _valor;
        }

        public String Exibir()
        {
            return string.Format(new System.Globalization.CultureInfo("pt-BR"), _formatador, _valor);
        }
    }
}
