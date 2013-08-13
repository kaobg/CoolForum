using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CoolForum
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "QuestionsPagingApi",
                routeTemplate: "api/questions/page/{page}",
                defaults: new { controller = "questions", action = "GetQuestionsByPage" }
            );

            config.Routes.MapHttpRoute(
                name: "Answers Api",
                routeTemplate: "api/questions/{questionId}/{action}/{sessionKey}",
                defaults: new { controller = "questions", sessionKey = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "QuestionsApi",
                routeTemplate: "api/questions/{action}/{sessionKey}",
                defaults: new { controller = "questions" }
            );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{action}/",
                defaults: new { controller = "users" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
