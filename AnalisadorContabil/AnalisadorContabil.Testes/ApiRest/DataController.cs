using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
