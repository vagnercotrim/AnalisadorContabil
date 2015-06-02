using System;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;

namespace AnalisadorContabil.Componente
{
    public class Xml : IComponente
    {
        private readonly string _arquivo;
        private readonly string _consulta;
        private readonly Tabela _tabela;
        private readonly IFonteDeDados _fonteDeDados;

        public Xml(Tabela tabela, IFonteDeDados fonteDeDados)
        {
            _tabela = tabela;

            _arquivo = tabela.Get("arquivo").ToString();
            _consulta = tabela.Get("consulta").ToString();
            _fonteDeDados = fonteDeDados;
        }

        public String Id()
        {
            return _tabela.Codigo;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Consulta(), _tabela.Retorno);
        }

        private object Consulta()
        {
            return _fonteDeDados.GetDados(new { arquivo = _arquivo, consulta = _consulta });
        }
    }
}
