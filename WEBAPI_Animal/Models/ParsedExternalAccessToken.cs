using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_Animal.Models
{
    public class ParsedExternalAccessToken
    {
        /// <summary>
        /// fb id
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// appid
        /// </summary>
        public string app_id { get; set; }

        /// <summary>
        /// 使用者記錄在fb的email
        /// </summary>
        [Required]
        [EmailAddress]
        public string email { get; set; }
        /// <summary>
        /// FB first_name
        /// </summary>
        public string first_name { get; set; }
        /// <summary>
        /// FB last_name
        /// </summary>
        public string last_name { get; set; }
        /// <summary>
        /// fb fullname
        /// </summary>
        [Required]
        public string name { get; set; }

        public string picture { get; set; }
    }
}