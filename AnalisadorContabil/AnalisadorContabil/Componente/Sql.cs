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

            if (_valor is int)
                return new ValorDecimal(_valor);

            if (_valor is double)
                return new ValorDecimal(_valor);

            if (_valor is decimal)
                return new ValorDecimal(_valor);

            if (_valor is bool)
                return new ValorBooleano(_valor);

            return null;
        }

    }
}