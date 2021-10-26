using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackDAL.Access
{
    public class FeedbackDAL
    {
        private readonly IConfiguration _configuration;

        public FeedbackDAL(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
    }
}
