using AnalisadorContabil.Factory;
using AnalisadorContabil.FonteDeDados;
using AnalisadorContabil.Valor;
using System;

namespace AnalisadorContabil.Componente
{
    public class Rest : IComponente
    {
        private readonly String _id;
        private readonly string _recurso;
        private readonly IFonteDeDados _fonteDeDados;

        public Rest(String id, String recurso, IFonteDeDados fonteDeDados)
        {
            _id = id;
            _recurso = recurso;
            _fonteDeDados = fonteDeDados;
        }

        public string Id()
        {
            return _id;
        }

        public IValor GetValor()
        {
            return ValorFactory.Cria(Consulta());
        }

        private object Consulta()
        {
            return _fonteDeDados.GetDados(_recurso);
        }
    }
}
