using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HPlusSport.API.Controllers
{
    public class TemperatureController : ApiController
    {
        public int Get()
        {
            var temperature = new Random().Next(30, 90);
            return temperature;
        }
    }
}
