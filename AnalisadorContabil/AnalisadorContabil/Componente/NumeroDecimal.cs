using System;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Componente
{
    public class NumeroDecimal : IComponente
    {
        private readonly String _id;
        private readonly decimal _valor;
        
        public NumeroDecimal(String id, Decimal valor)
        {
            _id = id;
            _valor = valor;
        }

        public String Id()
        {
            return _id;
        }

        public IValor GetValor()
        {
            return new ValorDecimal(_valor);
        }
    }
}
