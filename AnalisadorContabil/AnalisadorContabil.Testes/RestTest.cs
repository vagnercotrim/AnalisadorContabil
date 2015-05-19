﻿using AnalisadorContabil.Componente;
using AnalisadorContabil.Dominio;
using AnalisadorContabil.Factory;
using AnalisadorContabil.NHibernate;
using AnalisadorContabil.Testes.Integracao;
using AnalisadorContabil.Testes.Loader;
using NUnit.Framework;

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
            _factory.AdicionaFonte("api", new NHibernateFonteDeDados(_consultaSql));

            _factory.AdicionaVariavelSistema("empresa", 1);
            _factory.AdicionaVariavelSistema("ano", 2015);
            _factory.AdicionaVariavelSistema("periodo", 1);
        }

        [Test]
        public void Deve_criar_um_componente_do_tipo_rest()
        {
            IComponente consulta = _factory.Cria("C15N0101");

            Assert.IsTrue(consulta is Rest);
        }
    }
}