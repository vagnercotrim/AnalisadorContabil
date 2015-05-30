using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using System.Collections.Generic;

namespace AnalisadorContabil.Componente
{
    public class Rest : IComponente
    {
        private readonly string _recurso;
        private readonly Tabela _tabela;
        private readonly IFonteDeDados _fonteDeDados;

        public Rest(Tabela tabela, IDictionary<string, object> variaveisSistema, IFonteDeDados fonteDeDados)
        {
            _tabela = tabela;

            _recurso = VariaveisSistema.AtribuiValorVariaveis(tabela.Get("recurso").ToString(), variaveisSistema);
            _fonteDeDados = fonteDeDados;
        }

        public string Id()
        {
            return _tabela.Codigo;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Consulta(), _tabela.Retorno);
        }

        private object Consulta()
        {
            return _fonteDeDados.GetDados(_recurso);
        }
    }
}
