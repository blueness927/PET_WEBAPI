//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBAPI_Animal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class map
    {
        public int mapID { get; set; }
        public string mapType { get; set; }
        public string mapName { get; set; }
        public string maplatitude { get; set; }
        public string maplongitude { get; set; }
        public string mapTitle { get; set; }
        public string mapContent { get; set; }
        public string mapAddressCity { get; set; }
        public string mapAddressTown { get; set; }
        public string mapAddressDetail { get; set; }
        public string mapPic { get; set; }
    }
}