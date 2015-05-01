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
            String json = "{\"Nome\":\"formula\",\"Valor\":\"(2 + 3) * 5\"}";

            Parametro parametro = JsonConvert.DeserializeObject<Parametro>(json);

            Assert.AreEqual(parametro.Nome, "formula");
        }
    }
}
