using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_Animal.Models;

namespace WEBAPI_Animal.Controllers
{
    public class BaseController : ApiController
    {
        public petstationEntities db = new petstationEntities();
    }
}
