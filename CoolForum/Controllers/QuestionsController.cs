using CoolForum.Data;
using CoolForum.Models;
using CoolForum.Persisters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CoolForum.Controllers
{
    public class QuestionsController : ApiController
    {
        private ForumContext entities = new ForumContext();

        [HttpGet]
        public IEnumerable<QuestionBasicViewModel> GetQuestionsByPage(int page)
        {
            var questions = entities.Questions
                .Include("Author")
                .OrderByDescending(p => p.PostTime)
                .Skip((page - 1) * 10)
                .Select(q => new QuestionBasicViewModel()
                {
                    Title = q.Title,
                    Author = q.Author.UserName,
                    PostTime = q.PostTime,
                    Category = q.Category,
                })
                .Take(10)
                .ToList();

            return questions;
        }

        public QuestionFullViewModel GetQuestionById(int id)
        {
            var question = entities.Questions.Find(id);
            var vm = new QuestionFullViewModel()
            {
                Id = question.Id,
                Title = question.Title,
                Author = question.Author.UserName,
                Category = question.Category,
                Content = question.Content,
                PostTime = question.PostTime,
                Answers = question.Answers
            };

            return vm;
        }

        [HttpPost]
        public HttpResponseMessage PostQuestion(string sessionKey, [FromBody]Question questionModel)
        {
            var user = UserDataPersister.LoginUser(sessionKey);
            Question question = new Question()
            {
                Title = questionModel.Title,
                PostTime = DateTime.Now,
                Content = questionModel.Content,
                Category = questionModel.Category
            };

            entities.Users.Attach(user);
            user.Questions.Add(question);
            entities.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, "Question created.");
        }

        protected override void Dispose(bool disposing)
        {
            entities.Dispose();
            base.Dispose(disposing);
        }
    }
}
