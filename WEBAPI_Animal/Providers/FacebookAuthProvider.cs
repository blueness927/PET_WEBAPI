using Microsoft.Owin.Security.Facebook;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using WEBAPI_Animal.Models;

namespace WEBAPI_Animal.Providers
{
    /// <summary>
    /// fb atuh provider
    /// </summary>
    public class FacebookAuthProvider : FacebookAuthenticationProvider
    {
        /// <summary>
        /// authenticated
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task Authenticated(FacebookAuthenticatedContext context)
        {
            context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
            return Task.FromResult<object>(null);
        }
        /// <summary>
        /// 判斷fb 驗證並回傳資料物件
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<ParsedExternalAccessToken> GetFbParsedToken(string accessToken)
        {
            ParsedExternalAccessToken parsedToken = null;
            //You can get it from here: https://developers.facebook.com/tools/accesstoken/
            //More about debug_tokn here: http://stackoverflow.com/questions/16641083/how-does-one-get-the-app-access-token-for-debug-token-inspection-on-facebook



            //app token=Appid|AppSecret
            var appToken = "208269922976554|20dbe805f01805bf6287d926999da83f";
            var verifyTokenEndPoint = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token={1}", accessToken, appToken);
            var client = new HttpClient();

            var uri = new Uri(verifyTokenEndPoint);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                parsedToken = new ParsedExternalAccessToken();
                parsedToken.app_id = jObj["data"]["app_id"];

                //判斷使用者是否有授權
                if (!string.Equals(Startup.facebookAuthOptions.AppId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                var fields = "id,name,email,picture{url,height,is_silhouette,width},first_name,last_name";
                var fbinfouri = new Uri(string.Format("https://graph.facebook.com/me?fields={0}&access token={1}", fields, accessToken));
                var fbresponse = await client.GetAsync(fbinfouri);
                if (fbresponse.IsSuccessStatusCode)
                {
                    var fbcontent = await fbresponse.Content.ReadAsStringAsync();
                    dynamic fbjobj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(fbcontent);
                    parsedToken.user_id = fbjobj["id"];
                    parsedToken.name = fbjobj["name"];
                    parsedToken.email = fbjobj["email"];
                    parsedToken.picture = "https://graph.facebook.com/v2.8/" + fbjobj["id"] + "/picture"; //fbjobj["picture"]["data"]["url"];
                    parsedToken.last_name = fbjobj["last_name"];
                    parsedToken.first_name = fbjobj["first_name"];
                }
            }
            return parsedToken;
        }

    }

}