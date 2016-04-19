using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizzBuzzMvc.Controllers
{
    public class FizzBuzzController : Controller
    {
        public string ToFizzBuzz(int value)
        {
            var isDivisibleByFive = value % 5 == 0;
            var isDivisibleByThree = value % 3 == 0;

            if (isDivisibleByFive && isDivisibleByThree) return "FizzBuzz";
            if (isDivisibleByFive) return "Buzz";
            if (isDivisibleByThree) return "Fizz";

            return value.ToString();
        }

        public ActionResult Index()
        {
            var model = Enumerable.Range(1, 100).Select(ToFizzBuzz);
            return View(model);
        }
    }
}
