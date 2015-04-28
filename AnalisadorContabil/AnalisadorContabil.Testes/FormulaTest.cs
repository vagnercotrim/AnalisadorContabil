using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class FormulaTest
    {

        [Test]
        public void Deve_criar_um_componente_formula_e_retornar_75()
        {
            IComponente componente = new Formula("C14-006", "25 * 3");

            var valor = componente.GetValor();

            Assert.That(valor, Is.EqualTo(75));
        }

        [Test]
        public void Deve_criar_um_componente_formula_com_operador_condicional_e_retornar_verdadeiro()
        {
            IComponente componente = new Formula("C14-006", "25 > 3");

            var valor = componente.GetValor();

            Assert.That(valor, Is.EqualTo(true));
        }

        [Test]
        public void Deve_criar_um_componente_formula_com_operador_ternario_e_retornar_5()
        {
            IComponente componente = new Formula("C14-006", "25 > 3 ? 5 : 6");

            var valor = componente.GetValor();

            Assert.That(valor, Is.EqualTo(5));
        }

    }
}
