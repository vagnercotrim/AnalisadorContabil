using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes.Integracao
{
    public class InMemoryDatabaseTest : IDisposable
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;
        protected ISession Session { get; set; }

        [SetUp]
        public void Initialize()
        {
            _sessionFactory = CreateSessionFactory();

            Session = _sessionFactory.OpenSession();

            SchemaExport export = new SchemaExport(_configuration);
            export.Execute(true, true, false, Session.Connection, null);
        }

        [TearDown]
        public void Dispose()
        {
            Session.Dispose();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                           .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ImovelMap>())
                           .ExposeConfiguration(cfg => _configuration = cfg)
                           .BuildSessionFactory();
        }
    }
}