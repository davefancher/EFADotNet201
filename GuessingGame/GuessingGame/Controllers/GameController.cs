using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuessingGame.Models;

namespace GuessingGame.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            Session["Answer"] = new Random().Next(1, 10);

            return View();
        }

        private bool GuessWasCorrect(int guess) =>
            guess == (int)Session["Answer"];

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GameViewModel vm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Win = GuessWasCorrect(vm.Guess);
            }

            return View(vm);
        }
    }
}