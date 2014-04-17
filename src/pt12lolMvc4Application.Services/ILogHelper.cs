using System.Web;

namespace pt12lolMvc4Application.Services
{
    public interface ILogHelper
    {
        string FormatLog(HttpRequest request);
        string FormatLog(HttpResponse response);
    }
}
