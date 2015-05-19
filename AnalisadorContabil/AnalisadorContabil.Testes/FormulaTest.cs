using AnalisadorContabil.Componente;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class FormulaTest
    {

        [Test]
        public void Rerifica_o_ID_do_componente_formula()
        {
            IComponente componente = new Formula("C14-006", "25 * 3", null);

            Assert.That(componente.Id(), Is.EqualTo("C14-006"));
        }

        [Test]
        public void Deve_criar_um_componente_formula_e_retornar_75()
        {
            IComponente componente = new Formula("C14-006", "25 * 3", null);

            var valor = componente.GetValor();

            Assert.That(valor.Exibir(), Is.EqualTo("75,00"));
        }

        [Test]
        public void Deve_criar_um_componente_formula_com_operador_condicional_e_retornar_verdadeiro()
        {
            IComponente componente = new Formula("C14-006", "25 > 3", null);

            var valor = componente.GetValor();

            Assert.That(valor.Exibir(), Is.EqualTo("verdadeiro"));
        }

        [Test]
        public void Deve_criar_um_componente_formula_com_operador_ternario_e_retornar_5()
        {
            IComponente componente = new Formula("C14-006", "25 > 3 ? 5 : 6", null);

            var valor = componente.GetValor();

            Assert.That(valor.Exibir(), Is.EqualTo("5,00"));
        }
    }
}
