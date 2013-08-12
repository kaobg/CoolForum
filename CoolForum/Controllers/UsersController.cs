using CoolForum.Models;
using CoolForum.Persisters;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CoolForum.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserMembershipModel user)
        {
            try
            {
                UserDataPersister.CreateUser(user.UserName, user.AuthCode);
                var sessionKey = UserDataPersister.LoginUser(user.UserName, user.AuthCode);
                var loggedUser = new UserLoggedModel()
                {
                    SessionKey = sessionKey
                };

                return Request.CreateResponse(HttpStatusCode.OK, loggedUser);
            }
            catch (HttpException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser(UserMembershipModel user)
        {
            try
            {
                var sessionKey = UserDataPersister.LoginUser(user.UserName, user.AuthCode);
                var loggedUser = new UserLoggedModel()
                {
                    SessionKey = sessionKey
                };

                return Request.CreateResponse(HttpStatusCode.OK, loggedUser);
            }
            catch (HttpException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e.Message);
            }
        }

        [HttpGet]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            try
            {
                UserDataPersister.LogoutUser(sessionKey);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (HttpException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e.Message);
            }
        }
    }
}
