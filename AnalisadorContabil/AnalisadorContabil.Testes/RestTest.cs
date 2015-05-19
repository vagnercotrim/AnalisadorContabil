using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.NHibernate;
using AnalisadorContabil.Rest;
using AnalisadorContabil.Testes.ApiRest;
using AnalisadorContabil.Testes.Integracao;
using AnalisadorContabil.Testes.Loader;
using AnalisadorContabil.Valor;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes
{
    public class RestTest : InMemoryDatabaseTest
    {
        private ITabelaDao _tabelaDao;
        private IConsultaSql _consultaSql;
        private ComponenteFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _tabelaDao = new TabelaLoader().CriaTabelaDaoMock();

            ContaLoader contaLoader = new ContaLoader(Session);
            contaLoader.CriaContas();

            _consultaSql = new ConsultaSql(Session);
            _factory = new ComponenteFactory(_tabelaDao);
            _factory.AdicionaFonte("sqlite", new NHibernateFonteDeDados(_consultaSql));
            _factory.AdicionaFonte("api", new RestSharpFonteDeDados("http://localhost:9000/"));

            _factory.AdicionaVariavelSistema("empresa", 1);
            _factory.AdicionaVariavelSistema("ano", 2015);
            _factory.AdicionaVariavelSistema("periodo", 1);
        }

        [Test]
        public void Deve_consultar_uma_api_de_testes_e_retornar_value()
        {
            const string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                IComponente consulta = _factory.Cria("C15N0101");

                IValor valor = consulta.GetValor();

                Assert.AreEqual(valor.Objeto(), "value");
            }
        }

        [Test]
        public void Deve_consultar_uma_api_de_testes_e_retornar_uma_data()
        {
            const string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                IComponente consulta = _factory.Cria("C15N0102");

                IValor valor = consulta.GetValor();

                Assert.AreEqual(valor.Objeto(), new DateTime(2015, 5, 15));
            }
        }
    }
}
