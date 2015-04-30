using System;
using AnalisadorContabil.Componente;
using AnalisadorContabil.FonteDeDados;

namespace AnalisadorContabil.Factory
{
    public class SqlFactory
    {
        private readonly IFonteDeDados _fonte;

        public SqlFactory(IFonteDeDados fonte)
        {
            _fonte = fonte;
        }

        public Sql Criar(String id)
        {
            Tabela tabela = _fonte.GetDados(id);

            return new Sql(id, tabela.Valor);
        }

    }
}
