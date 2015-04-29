using System;

namespace AnalisadorContabil.Componente
{
    public class Sql : IComponente
    {
        private readonly String _id;
        private readonly object _valor;

        public Sql(String id, Decimal valor)
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