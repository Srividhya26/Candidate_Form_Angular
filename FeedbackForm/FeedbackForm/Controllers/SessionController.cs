using FeedbackBL.Logics;
using FeedbackDAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackFormPL.Controllers
{
    public class SessionController : Controller
    {
        public SessionBL _sessionBL;

        public SessionController(SessionBL sessionBL)
        {
            this._sessionBL = sessionBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<Users> listConductors = await _sessionBL.GetConductor();
            IEnumerable<Users> listSpeakers = await _sessionBL.GetSpeaker();

            ViewBag.conductors = listConductors;
            ViewBag.speakers = listSpeakers;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Session session)
        {
            if (ModelState.IsValid)
            {
                _sessionBL.AddSession(session);

                return RedirectToAction("Index");
            }

            return View(session);
        }
    }
}
