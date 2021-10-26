using FeedbackDAL.Access;
using FeedbackDAL.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackBL.Logics
{
    public class SessionBL
    {
        public SessionDAL _sessiondal;

        public SessionBL(SessionDAL sessionDAL)
        {
            this._sessiondal = sessionDAL;
        }

        public void AddSession(Session session)
        {
            _sessiondal.AddSession(session);
        }

        public async Task<IEnumerable<SelectListItem>> GetSpeaker()
        {
            return await _sessiondal.GetSpeaker();
        }

        public async Task<IEnumerable<SelectListItem>> GetConductor()
        {
            return await _sessiondal.GetConductor();
        }

        public async Task<IEnumerable<Session>> GetAllSessions()
        {
            return await _sessiondal.GetAllSession();
        }
    }
}
