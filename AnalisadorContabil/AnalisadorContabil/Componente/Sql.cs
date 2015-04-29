using System;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Componente
{
    public class Sql : IComponente
    {
        private readonly String _id;
        private readonly object _valor;

        public Sql(String id, object valor)
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
            return new ValorDecimal((Decimal)_valor);
        }

    }
}