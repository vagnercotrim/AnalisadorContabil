using System;
using AnalisadorContabil.Componente;
using AnalisadorContabil.FonteDeDados;

namespace AnalisadorContabil.Factory
{
    public class FormulaFactory
    {
        private readonly IFonteDeDados _fonte;

        public FormulaFactory(IFonteDeDados fonte)
        {
            _fonte = fonte;
        }

        public Formula Criar(String id)
        {
            Tabela tabela = _fonte.GetDados(id);
            String formula = tabela.Get("formula").Replace(@"'", "");

            return new Formula(id, formula);
        }

    }
}
