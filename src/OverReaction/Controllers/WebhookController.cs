using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OverReaction.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace OverReaction.Controllers
{
    /// <summary>
    /// Slack Webhookを受け付けるAPI
    /// </summary>
    [Route("api/[controller]")]
    public class WebhookController : Controller
    {
        private readonly string webhookToken;
        private readonly string xoxpToken;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WebhookController(IOptions<OverReactionSetting> options)
        {
            webhookToken = options.Value.WebhookToken;
            xoxpToken = options.Value.XoxpToken;
        }

        /// <summary>
        /// SlackからのPOSTを受け取ります。このAPIはSlack専用です。
        /// </summary>
        [HttpPost]
        public async Task Post()
        {
            var form = await Request.ReadFormAsync();
            if (form["token"].Equals(webhookToken))
            {
                using (var db = new ReactionContext())
                {
                    var text = form["text"].ToString();
                    foreach (var reaction in db.Reactions.Where(reaction => text.Contains(reaction.Word)))
                    {
                        var client = new HttpClient();
                        var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                        {
                            { "token", xoxpToken },
                            { "name", reaction.Emoji },
                            { "channel", form["channel_id"] },
                            { "timestamp", form["timestamp"] }
                        });
                        await client.PostAsync("https://slack.com/api/reactions.add", content);
                    }
                }
            }
        }
    }
}
