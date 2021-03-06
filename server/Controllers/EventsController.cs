﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OverReaction.Models;
using OverReaction.Models.Request;
using Newtonsoft.Json.Linq;

namespace OverReaction.Controllers
{
    [Route("api/events")]
    public class EventsController : Controller
    {
        private DatabaseContext db;
        private ILogger log;

        public EventsController(DatabaseContext db, ILogger<EventsController> logger)
        {
            this.db = db;
            log = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]JObject request)
        {
            var req = request.ToObject<EventRequest>();

            // Events API handshake challenge
            if (req.Type.Equals("url_verification"))
            {
                return Ok(new UrlValidationEvent(req.Challenge));
            }

            if (req.IsNewPost())
            {
                db.EventLogs.Add(new SlackEventLog() { Text = request.ToString(), Timestamp = DateTime.UtcNow });
                await db.SaveChangesAsync();
            }

            return NoContent();
        }

        [HttpGet("logs")]
        public async Task<IList<SlackEventLog>> GetLogs()
        {
            return await db.EventLogs.OrderBy(e => e.Id).ToListAsync();
        }
    }
}
