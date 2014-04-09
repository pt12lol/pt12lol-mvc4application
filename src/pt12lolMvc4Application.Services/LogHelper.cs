using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using pt12lolMvc4Application.Services.Interfaces;

namespace pt12lolMvc4Application.Services
{
    public class LogHelper : ILogHelper
    {
        public string FormatLog(HttpRequest request)
        {
            string url = request.Url.ToString();
            string client = string.Format("{0} ({1})", request.UserHostAddress, request.UserHostName);
            string httpMethod = request.HttpMethod;
            string result = string.Format("HTTP Request\n" +
                "Requested URL: {0}\n" +
                "Client: {1}\n" +
                "HTTP method: {2}",
                url, client, httpMethod);
            if (httpMethod.Equals("POST"))
            {
                StringBuilder received = new StringBuilder("\n{ \n");
                NameValueCollection form = request.Form;
                foreach (string key in form.Keys)
                {
                    received.Append(string.Format("\t{0}: \"{1}\",\n", key, form[key]));
                }
                received.Append("\n}");
                return result + received;
            }
            return result;
        }
    }
}
