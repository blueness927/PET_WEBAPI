using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_Animal.Models
{
    [MetadataType(typeof(animalData_PicMD))]
    public partial class animalData_Pic
    {
        public class animalData_PicMD
        {
            public int animalPicID { get; set; }
            public Nullable<int> animalPic_animalID { get; set; }
            public string animalPicAddress { get; set; }

            [JsonIgnore]
            public animalData animalData { get; set; }
        }

    }
}