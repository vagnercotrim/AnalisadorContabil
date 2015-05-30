using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.Testes.Loader;
using AnalisadorContabil.Testes.Mock;
using AnalisadorContabil.Valor;
using AnalisadorContabil.Xml;
using NUnit.Framework;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class XmlTest
    {
        private ITabelaDao _tabelaDao;
        private ComponenteFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _tabelaDao = new TabelaDaoMock(new TabelaLoader().Dados);

            _factory = new ComponenteFactory(_tabelaDao);
            _factory.AdicionaFonte("xml", new XmlFonteDeDados(@"c:\remessacontabil\2015"));

            _factory.AdicionaVariavelSistema("empresa", 1);
            _factory.AdicionaVariavelSistema("ano", 2015);
            _factory.AdicionaVariavelSistema("periodo", 1);
        }

        [Test]
        public void Deve_processar_um_componente_xml_e_retornar_um_valor_decimal()
        {
            IComponente consulta = _factory.Cria("C15N0041");

            IValor valor = consulta.GetValor();

            Assert.AreEqual(valor.Objeto(), 12345.67M);
        }

    }
}
