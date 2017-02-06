using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_Animal.Models
{
    [MetadataType(typeof(followMD))]
    public partial class follow
    {
        public class followMD
        {
            public int followID { get; set; }
            public string follow_userId { get; set; }
            public Nullable<int> follow_animalID { get; set; }

            [JsonIgnore]
            public virtual AspNetUsers AspNetUsers { get; set; }
        }
      
    }
    
}