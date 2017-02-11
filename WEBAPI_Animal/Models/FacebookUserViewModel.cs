using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_Animal.Models
{
    public class FacebookUserViewModel
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public object Username { get; internal set; }
        public object FirstName { get; internal set; }
        public object ID { get; internal set; }
        public object LastName { get; internal set; }
        public object Email { get; internal set; }
    }
}