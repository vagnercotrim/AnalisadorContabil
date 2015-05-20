using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using System;

namespace AnalisadorContabil.Componente
{
    public class Sql : IComponente
    {
        private readonly String _id;
        private readonly String _sql;
        private readonly string _retorno;
        private readonly IFonteDeDados _fonteDeDados;
        
        public Sql(String id, String sql, String retorno, IFonteDeDados fonteDeDados)
        {
            _id = id;
            _sql = sql;
            _retorno = retorno;
            _fonteDeDados = fonteDeDados;
        }

        public String Id()
        {
            return _id;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Consulta(), _retorno);
        }

        private object Consulta()
        {
            return _fonteDeDados.GetDados(_sql);
        }
    }
}