using System;
using System.Collections.Generic;

namespace WEBAPI_Animal.Models
{
    // AccountController 動作所傳回的模型。
    /// <summary>
    /// 
    /// </summary>
    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }

}
