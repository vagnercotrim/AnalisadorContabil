using System.Collections.Generic;
using AnalisadorContabil.Valor;
using System;

namespace AnalisadorContabil.Componente
{
    public class Sql : IComponente
    {
        private readonly String _id;
        private readonly string _sql;
        private readonly IDictionary<string, object> _variaveis;

        public Sql(String id, String sql, IDictionary<String, object> variaveis = null)
        {
            _id = id;
            _sql = sql;
            _variaveis = variaveis;
        }

        public String Id()
        {
            return _id;
        }

        public IValor GetValor()
        {
            object resultado = Consulta();
            
            if (resultado is int)
                return new ValorDecimal(resultado);

            if (resultado is double)
                return new ValorDouble(resultado);

            if (resultado is decimal)
                return new ValorDecimal(resultado);

            if (resultado is bool)
                return new ValorBooleano(resultado);

            return null;
        }

        private object Consulta()
        {
            return null;
        }
    }
}