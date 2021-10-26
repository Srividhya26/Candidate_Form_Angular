using Dapper;
using FeedbackDAL.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FeedbackDAL.Access
{
    public class SessionDAL
    {
        private readonly IConfiguration _configuration;

        public SessionDAL(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void AddSession(Session session)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Sp_CreateSession";

            DynamicParameters parameter = new();

            parameter.Add("Name", session.SessionName);
            parameter.Add("ConductorId", session.ConductorId);
            parameter.Add("SpeakerId", session.SpeakerId);
            parameter.Add("Duration", session.Duration);
            parameter.Add("Date", session.Date);
            

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameter);
        }

        public async Task<IEnumerable<SelectListItem>> GetSpeaker()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Sp_GetAllSpeakers";

            var listOfSpeaker = await Task.FromResult(dbConnection.Query<SelectListItem>(sp, commandType: CommandType.StoredProcedure).ToList());

            return listOfSpeaker;
        }

        public async Task<IEnumerable<SelectListItem>> GetConductor()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Sp_GetAllConductors";

            var listOfConductor = await Task.FromResult(dbConnection.Query<SelectListItem>(sp, commandType: CommandType.StoredProcedure).ToList());

            return listOfConductor;
        }

        public async Task<IEnumerable<Session>> GetAllSession()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Sp_GetAllSessions";

            var listOfSessions = await Task.FromResult(dbConnection.Query<Session>(sp, commandType: CommandType.StoredProcedure).ToList());

            return listOfSessions;
        }
    }
}
