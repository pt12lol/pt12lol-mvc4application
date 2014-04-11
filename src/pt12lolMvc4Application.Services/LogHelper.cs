using System.Collections.Specialized;
using System.Text;
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

        public string FormatLog(HttpResponse response)
        {
            return string.Format("HTTP Response: {0}", response.Status);
        }
    }
}
