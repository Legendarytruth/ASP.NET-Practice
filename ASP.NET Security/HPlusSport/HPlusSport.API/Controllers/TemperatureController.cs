using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HPlusSport.API.Controllers
{
    [EnableCors(origins: "https://localhost:44329", headers: "*", methods:"GET")]
    public class TemperatureController : ApiController
    {
        public int Get()
        {
            var temperature = new Random().Next(30, 90);
            return temperature;
        }
    }
}
