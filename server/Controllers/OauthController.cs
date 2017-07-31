using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverReaction.Controllers
{
    [Route("api/oauth")]
    public class OauthController : Controller
    {
        private DatabaseContext db;
        private ILogger log;

        public OauthController(DatabaseContext db, ILogger<OauthController> logger)
        {
            this.db = db;
            log = logger;
        }

        [HttpGet]
        public async Task Get()
        {
            var query = Request.QueryString.Value;
            db.EventLogs.Add(new Models.SlackEventLog() { Text = query, Timestamp = DateTime.UtcNow });
            await db.SaveChangesAsync();
        }
    }
}
