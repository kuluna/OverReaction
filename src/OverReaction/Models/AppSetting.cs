using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverReaction.Models
{
    /// <summary>
    /// appsetting.json
    /// </summary>
    public class AppSetting
    {
        /// <summary>
        /// Slack Outgoing WebHooks Token
        /// </summary>
        public string WebhookToken { get; set; }
        /// <summary>
        /// Slack API Access Token
        /// </summary>
        public string XoxpToken { get; set; }
    }
}
