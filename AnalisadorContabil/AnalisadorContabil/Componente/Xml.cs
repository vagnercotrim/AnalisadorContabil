using System;
using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Componente
{
    public class Xml : IComponente
    {
        private readonly string _id;
        private readonly string _arquivo;
        private readonly string _consulta;
        private readonly string _retorno;
        private readonly IFonteDeDados _fonteDeDados;

        public Xml(String id, String arquivo, String consulta, String retorno, IFonteDeDados fonteDeDados)
        {
            _id = id;
            _arquivo = arquivo;
            _consulta = consulta;
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
            return _fonteDeDados.GetDados(_arquivo + ":" + _consulta);
        }
    }
}
