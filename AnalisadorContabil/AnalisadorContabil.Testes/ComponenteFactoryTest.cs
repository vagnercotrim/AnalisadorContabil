using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.Testes.Loader;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class ComponenteFactoryTest
    {
        private ITabelaDao _dao;

        [SetUp]
        public void SetUp()
        {
            _dao = new TabelaLoader().CriaTabelaDaoMock();
        }

        [Test]
        public void Deve_criar_um_componente()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0010");

            Assert.AreEqual(formula.GetValor().Objeto(), 75.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_parametro()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0011");

            Assert.AreEqual(formula.GetValor().Objeto(), 5.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_parametros()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0013");

            Assert.AreEqual(formula.GetValor().Objeto(), 15.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_dois_parametros()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0015");

            Assert.AreEqual(formula.GetValor().Objeto(), 100.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_dois_parametros_outra_formula()
        {
            ComponenteFactory factory = new ComponenteFactory(_dao);

            IComponente formula = factory.Cria("C15N0016");

            Assert.AreEqual(formula.GetValor().Objeto(), 90.00);
        }
    }
}
