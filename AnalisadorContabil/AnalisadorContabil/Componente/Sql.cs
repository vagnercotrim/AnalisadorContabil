using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using System;
using System.Collections.Generic;

namespace AnalisadorContabil.Componente
{
    public class Sql : IComponente
    {
        private readonly String _id;
        private readonly string _sql;
        private readonly IFonteDeDados _fonteDeDados;
        
        public Sql(String id, String sql, IFonteDeDados fonteDeDados)
        {
            _id = id;
            _sql = sql;
            _fonteDeDados = fonteDeDados;
        }

        public String Id()
        {
            return _id;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Consulta());
        }

        private object Consulta()
        {
            return _fonteDeDados.GetDados(_sql);
        }
    }
}