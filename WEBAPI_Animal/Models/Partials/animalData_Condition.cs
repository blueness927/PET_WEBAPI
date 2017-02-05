using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_Animal.Models
{
    [MetadataType(typeof(animalData_ConditionMD))]
    public partial class animalData_Condition
    {
        public class animalData_ConditionMD
        {
            public int conditionID { get; set; }
            public Nullable<int> condition_animalID { get; set; }
            public string conditionAge { get; set; }
            public string conditionEconomy { get; set; }
            public string conditionHome { get; set; }
            public string conditionFamily { get; set; }
            public string conditionReply { get; set; }
            public string conditionPaper { get; set; }
            public string conditionFee { get; set; }
            public string conditionOther { get; set; }

            [JsonIgnore]
            public  animalData animalData { get; set; }
        }
    }
}