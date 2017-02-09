using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_Animal.Models.Partials
{
    [MetadataType(typeof(searchMD))]
    public partial class search
    {
        public class searchMD
        {
            public int SearchID { get; set; }
            public string Search_userID { get; set; }
            public Nullable<int> SearchType_animalTypeID { get; set; }
            public Nullable<int> SearchAge { get; set; }
            public string SearchColor { get; set; }

            [JsonIgnore]
            public virtual AspNetUsers AspNetUsers { get; set; }
        }
      
    }
   
}