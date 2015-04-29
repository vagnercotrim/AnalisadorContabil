using System;

namespace AnalisadorContabil
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
            Decimal valor = (Decimal)_fonte.GetDados(id);

            return new Sql(id, valor);
        }

    }
}
