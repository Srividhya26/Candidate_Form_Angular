using FeedbackDAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackFormPL.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFeedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFeedback(Feedback feedback)
        {
            return View(feedback);
        }
    }
}
