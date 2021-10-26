using FeedbackDAL.Access;
using FeedbackDAL.Model;
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

        public async Task<IEnumerable<Users>> GetSpeaker()
        {
            return await _sessiondal.GetSpeaker();
        }

        public async Task<IEnumerable<Users>> GetConductor()
        {
            return await _sessiondal.GetConductor();
        }
    }
}
