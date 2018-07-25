using Framework.Tools;
using System;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        public string Result(Object Response)
        {
            return JsonUtil.ObjectToJson(Response);
        }
    }
}