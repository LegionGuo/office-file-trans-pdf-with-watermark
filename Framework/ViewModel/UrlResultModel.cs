using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Framework.ViewModel
{
    public class UrlResultModel
    {
        public string Url { get; set; }

        public bool HasError { get; set; }

        public string ErrorMessage { get; set; }
    }
}