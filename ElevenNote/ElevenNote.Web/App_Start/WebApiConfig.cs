using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace ElevenNote.Web
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            GlobalConfiguration
                .Configure(
                    x =>
                    {
                        x.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
                        x.MapHttpAttributeRoutes();
                    });
        }
    }
}