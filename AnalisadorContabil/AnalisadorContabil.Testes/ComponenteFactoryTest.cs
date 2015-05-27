using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.Testes.Loader;
using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class ComponenteFactoryTest
    {
        private ITabelaDao _dao;
        ComponenteFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _dao = new TabelaLoader().CriaTabelaDaoMock();

            _factory = new ComponenteFactory(_dao);
        }

        [Test]
        public void Deve_criar_um_componente()
        {
            IComponente formula = _factory.Cria("C15N0010");

            Assert.AreEqual(formula.GetValor().Objeto(), 75.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_parametro()
        {
            IComponente formula = _factory.Cria("C15N0011");

            Assert.AreEqual(formula.GetValor().Objeto(), 5.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_parametros()
        {
            IComponente formula = _factory.Cria("C15N0013");

            Assert.AreEqual(formula.GetValor().Objeto(), 15.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_dois_parametros()
        {
            IComponente formula = _factory.Cria("C15N0015");

            Assert.AreEqual(formula.GetValor().Objeto(), 100.00);
        }

        [Test]
        public void Deve_criar_um_componente_com_dois_parametros_outra_formula()
        {
            IComponente formula = _factory.Cria("C15N0016");

            Assert.AreEqual(formula.GetValor().Objeto(), 90.00);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Deve_retornar_uma_exception_tentanto_criar_um_componente_que_nao_existe()
        {
            _factory.Cria("C00N9999");
        }
    }
}
