using CoolForum.Data;
using CoolForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoolForum.Controllers
{
    public class QuestionsController : ApiController
    {
        private ForumContext entities = new ForumContext();

        public ICollection<Question> GetQuestions(int page)
        {
            var questions = entities.Questions
                .OrderByDescending(p => p.PostTime)
                .Skip((page - 1) * 10)
                .Take(10)
                .ToList();

            return questions;
        }

        public HttpResponseMessage PostQuestion(Question question)
        {
            question.PostTime = DateTime.Now;
            entities.Questions.Add(question);
            entities.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, "Question created.");
        }

        [HttpGet]
        [ActionName("test")]
        public string Test()
        {
            return "hahaaa";
        }

        protected override void Dispose(bool disposing)
        {
            entities.Dispose();
            base.Dispose(disposing);
        }
    }
}
