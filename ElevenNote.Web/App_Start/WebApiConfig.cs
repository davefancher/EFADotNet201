using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ElevenNote.Web
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configure(x => x.MapHttpAttributeRoutes());
        }
    }
}