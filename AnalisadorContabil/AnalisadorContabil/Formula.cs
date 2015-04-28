using System;

namespace AnalisadorContabil
{
    public class Formula : IComponente
    {
        private readonly String _id;
        private readonly String _formula;

        public Formula(String id, String formula)
        {
            _id = id;
            _formula = formula;
        }

        public String Id()
        {
            return _id;
        }

        public object GetValor()
        {
            return Calcular();
        }

        private object Calcular()
        {
            return 75.00M;
        }
    }
}