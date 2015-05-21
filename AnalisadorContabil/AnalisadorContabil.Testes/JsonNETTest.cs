using System.Collections.Generic;
using AnalisadorContabil.Dominio;
using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace AnalisadorContabil.Testes
{
    [TestFixture]
    public class JsonNetTest
    {
        [Test]
        public void Serializa_um_parametro_com_string()
        {
            Parametro parametro = new Parametro("formula", "(2 + 3) * 5");

            String json = JsonConvert.SerializeObject(parametro);

            Assert.AreEqual(json, "{\"Nome\":\"formula\",\"Valor\":\"(2 + 3) * 5\"}");
        }

        [Test]
        public void Deserializa_um_parametro_com_string()
        {
            const string json = "{\"Nome\":\"formula\",\"Valor\":\"(2 + 3) * 5\"}";

            Parametro parametro = JsonConvert.DeserializeObject<Parametro>(json);

            Assert.AreEqual(parametro.Nome, "formula");
        }

        [Test]
        public void Serializa_dois_parametro_com_string()
        {
            IList<Parametro> parametros = new List<Parametro>();
            Parametro parametro1 = new Parametro("resultado", 23.23);
            Parametro parametro2 = new Parametro("tiporetorno", "decimal");
            parametros.Add(parametro1);
            parametros.Add(parametro2);

            String json = JsonConvert.SerializeObject(parametros);

            Assert.AreEqual(json, "[{\"Nome\":\"resultado\",\"Valor\":23.23},{\"Nome\":\"tiporetorno\",\"Valor\":\"decimal\"}]");
        }

        [Test]
        public void Deserializa_dois_parametro_com_string()
        {
            const string json = "[{\"Nome\":\"resultado\",\"Valor\":23.23},{\"Nome\":\"tiporetorno\",\"Valor\":\"decimal\"}]";

            IList<Parametro> parametros = JsonConvert.DeserializeObject<List<Parametro>>(json);

            Assert.AreEqual(parametros.Count, 2);
        }

        [Test]
        public void Deve_converter_um_obeto_da_classe_tabela_em_json()
        {
            Tabela tabela = new Tabela("C15N0027", null, "sql", null, "numerico",
                new List<Parametro>
                {
                    new Parametro("tabela", "tabela"),
                    new Parametro("campo", "campo"),
                    new Parametro("condicao", "condicao"),
                    new Parametro("valor", "'02.01.03'")
                });

            String json = JsonConvert.SerializeObject(tabela);

            Assert.That(json.Length, Is.GreaterThan(50));
        }
    }
}
