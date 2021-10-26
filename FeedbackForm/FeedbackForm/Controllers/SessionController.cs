using FeedbackBL.Logics;
using FeedbackDAL.Data;
using FeedbackDAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackFormPL.Controllers
{
    public class SessionController : Controller
    {
        private readonly SessionBL _sessionBL;
        private readonly FeedbackContext _db;

        public SessionController(SessionBL sessionBL, FeedbackContext db)
        {
            this._sessionBL = sessionBL;
            this._db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Session> sessionList = await _sessionBL.GetAllSessions();

            return View(sessionList);
        }

        public IActionResult Create()
        {
            //IEnumerable < SelectListItem> listConductors = await _sessionBL.GetConductor();
            //IEnumerable<SelectListItem> listSpeakers = await _sessionBL.GetSpeaker();

            //ViewBag.conductors = listConductors;
            //ViewBag.speakers = listSpeakers;

            IEnumerable<SelectListItem> listConductors = _db.Users.Select(x =>
              new SelectListItem
              {
                  Text = x.Name,
                  Value = x.Id.ToString()
              });

            ViewBag.conductors = listConductors;
            ViewBag.speakers = listConductors;

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
