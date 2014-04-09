using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace pt12lolMvc4Application.Services.Interfaces
{
    public interface ILogHelper
    {
        string FormatLog(HttpRequest request);
    }
}
