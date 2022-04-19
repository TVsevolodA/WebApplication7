using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        AnswersContext db = new AnswersContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Questionnaire questionnaire)
        {
            if (string.IsNullOrEmpty(questionnaire.name))
            {
                ModelState.AddModelError(nameof(questionnaire.name), "Введите пожалуйста ваше имя!");
            }
            if (string.IsNullOrEmpty(questionnaire.email))
            {
                ModelState.AddModelError(nameof(questionnaire.email), "Введите пожалуйста ваш E-mail!");
            }
            if (string.IsNullOrEmpty(questionnaire.phone))
            {
                ModelState.AddModelError(nameof(questionnaire.phone), "Введите пожалуйста ваш контактный телефон!");
            }
            if (ModelState.IsValid)
            {
                db.Questionnaires.Add(questionnaire);
                db.SaveChanges();
                return Redirect("~/Home/Gratitude");
            }
            return View(questionnaire);
        }

        public ActionResult Gratitude()
        {
            return View();
        }

        public ActionResult AllAnswers()
        {
            return View(db.Questionnaires);
        }
    }
}