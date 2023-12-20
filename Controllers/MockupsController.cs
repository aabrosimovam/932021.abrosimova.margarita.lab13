using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using _932021.abrosimova.margarita.lab11.Models;
namespace _932021.abrosimova.margarita.lab11.Controllers
{
    public class MockupsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quiz(QuestionPageModel question, string action)
        {
            if (!ModelState.IsValid) { ViewBag.Problem = question.Problem; return View(question); }
            IdentityMap.Get().Last().yanswer = question.yanswer;
            if (IdentityMap.Get().Last().Answer == Convert.ToInt32(question.yanswer)) IdentityMap.rights++;
           IdentityMap.alls++;
            if (action == "Finish") return RedirectToAction("QuizResult");
            QuestionPageModel act = new QuestionPageModel();
            ViewBag.Problem = act.Problem;
            IdentityMap.AddAction(act);
            return View(act);
        }
        [HttpGet]
        public IActionResult Quiz()
        {
            QuestionPageModel question = new QuestionPageModel();
            ViewBag.Problem = question.Problem;
            IdentityMap.AddAction(question);
            return View(question);
        }
        public IActionResult QuizResult()
        {
            return View(IdentityMap.Get());
        }       
        }
}