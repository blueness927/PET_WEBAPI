using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_Animal.Models
{
    [MetadataType(typeof (boardMD))]
    public partial class board
    {
        public class boardMD
        {
            public int boardID { get; set; }
            public string boardTime { get; set; }
            public string board_userID { get; set; }
            public Nullable<int> board_animalID { get; set; }
            public string boardContent { get; set; }

            [JsonIgnore]
            public virtual animalData animalData { get; set; }
            [JsonIgnore]
            public virtual AspNetUsers AspNetUsers { get; set; }
            [JsonIgnore]
            public virtual ICollection<board_reply> board_reply { get; set; }
        }
    }
}