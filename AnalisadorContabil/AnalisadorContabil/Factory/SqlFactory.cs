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
            String tiporetorno = tabela.Get("tiporetorno").ToString().Replace(@"'", "");

            object valor = null;

            if (tiporetorno == "decimal")
                valor = Decimal.Parse(tabela.Get("resultado").ToString());
            else
                valor = tabela.Get("resultado");

            return new Sql(id, valor);
        }

    }
}
