using System;
using System.Web.Http;

namespace AnalisadorContabil.Testes.ApiRest
{
    public class DataController : ApiController
    {
        public DateTime Get()
        {
            return new DateTime(2015, 5 , 15);
        }
    }
}
