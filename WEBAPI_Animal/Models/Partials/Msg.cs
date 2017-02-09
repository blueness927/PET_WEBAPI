using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_Animal.Models
{
    [MetadataType(typeof(MsgMD))]
    public partial class Msg
    {
        public class MsgMD
        {
            public int msgID { get; set; }
            public string msgTime { get; set; }
            public string msgFrom_userID { get; set; }
            public string msgTo_userID { get; set; }
            public string msgType { get; set; }
            public string msgFromURL { get; set; }
            public string msgContent { get; set; }
            public string msgRead { get; set; }

            [JsonIgnore]
            public virtual AspNetUsers AspNetUsers { get; set; }
        }
    }
}