using System.Web.Http;

namespace AnalisadorContabil.Testes.ApiRest
{
    public class MetaController : ApiController
    {
        public decimal Get()
        {
            return 150.00M;
        }
    }
}
