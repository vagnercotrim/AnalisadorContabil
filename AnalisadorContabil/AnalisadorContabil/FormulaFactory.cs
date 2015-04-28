using System;

namespace AnalisadorContabil
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
            object valor = _fonte.GetDados(id);

            return new Formula(id, (String)valor);
        }

    }
}
