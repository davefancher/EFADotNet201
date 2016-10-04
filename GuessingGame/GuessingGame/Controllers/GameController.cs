using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuessingGame.Models;
using GuessingGame.Services;

namespace GuessingGame.Controllers
{
    public class GameController : Controller
    {
        private readonly IRandomNumberGenerator _rng;

        public GameController(IRandomNumberGenerator rng)
        {
            _rng = rng;
        }

        public ActionResult Index()
        {
            Session["Answer"] = _rng.GetNext(1, 10);

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