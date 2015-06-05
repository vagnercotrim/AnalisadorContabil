using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.Testes.Mock;
using AnalisadorContabil.Valor;
using AnalisadorContabil.Xml;
using NUnit.Framework;
using System;

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
            String caminhoArquivo = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            _tabelaDao = new TabelaDaoMock();

            _factory = new ComponenteFactory(_tabelaDao);
            _factory.AdicionaFonte("xml", new XmlFonteDeDados(caminhoArquivo));

            _factory.AdicionaVariavelSistema("empresa", 1);
            _factory.AdicionaVariavelSistema("ano", 2015);
            _factory.AdicionaVariavelSistema("periodo", 1);
        }

        [Test]
        public void Deve_processar_um_componente_xml_e_retornar_o_valor_25000_25()
        {
            IComponente consulta = _factory.Cria("C15N0041");

            IValor valor = consulta.GetValor();

            Assert.AreEqual(valor.Objeto(), 2500.25M);
        }

        [Test]
        public void Deve_processar_um_componente_xml_e_retornar_o_id()
        {
            IComponente consulta = _factory.Cria("C15N0041");

            Assert.AreEqual(consulta.Id(), "C15N0041");
        }
    }
}
