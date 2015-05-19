using System.Linq;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace AnalisadorContabil.Testes.ApiRest
{
    [TestFixture]
    public class ApiRestTest
    {

        [Test]
        public void CarregaApi()
        {
            const string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                string[] values = response.Content.ReadAsAsync<string[]>().Result;

                Assert.AreEqual(values.Count(), 2);
            }
        }
    }
}
