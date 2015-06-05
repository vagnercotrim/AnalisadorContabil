using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class FormulaTest
    {

        [Test]
        public void Rerifica_o_ID_do_componente_formula()
        {
            Tabela tabela = new Tabela("C14-006", null, "formula", null, "{0:0.00}", new Parametro("formula", "25 * 3"));

            IComponente componente = new Formula(tabela, null);

            Assert.That(componente.Id(), Is.EqualTo("C14-006"));
        }

        [Test]
        public void Deve_criar_um_componente_formula_e_retornar_75()
        {
            Tabela tabela = new Tabela("C14-006", null, "formula", null, "{0:0.00}", new Parametro("formula", "25 * 3"));

            IComponente componente = new Formula(tabela, null);

            var valor = componente.GetValor();

            Assert.That(valor.Exibir(), Is.EqualTo("75,00"));
        }

        [Test]
        public void Deve_criar_um_componente_formula_com_operador_condicional_e_retornar_verdadeiro()
        {
            Tabela tabela = new Tabela("C14-006", null, "formula", null, "booleano", new Parametro("formula", "25 > 3"));

            IComponente componente = new Formula(tabela, null);

            var valor = componente.GetValor();

            Assert.That(valor.Exibir(), Is.EqualTo("verdadeiro"));
        }

        [Test]
        public void Deve_criar_um_componente_formula_com_operador_condicional_e_retornar_falso()
        {
            Tabela tabela = new Tabela("C14-006", null, "formula", null, "booleano", new Parametro("formula", "20 < 10"));

            IComponente componente = new Formula(tabela, null);

            var valor = componente.GetValor();

            Assert.That(valor.Exibir(), Is.EqualTo("falso"));
        }

        [Test]
        public void Deve_criar_um_componente_formula_com_operador_ternario_e_retornar_5()
        {
            Tabela tabela = new Tabela("C14-006", null, "formula", null, "{0:0.00}", new Parametro("formula", "25 > 3 ? 5 : 6"));

            IComponente componente = new Formula(tabela, null);

            var valor = componente.GetValor();

            Assert.That(valor.Exibir(), Is.EqualTo("5,00"));
        }
    }
}
