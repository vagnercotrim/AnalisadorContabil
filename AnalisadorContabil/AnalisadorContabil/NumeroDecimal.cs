using System;

namespace AnalisadorContabil
{
    public class NumeroDecimal : IComponente
    {
        private readonly decimal _valor;
        
        public NumeroDecimal(Decimal valor)
        {
            _valor = valor;
        }

        public object GetValor()
        {
            return _valor;
        }
    }
}
