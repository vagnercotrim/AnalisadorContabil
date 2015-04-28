using System;

namespace AnalisadorContabil
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

        public object GetValor()
        {
            return _valor;
        }
    }
}
