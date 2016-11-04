using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using OverReaction.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OverReaction.Controllers
{
    /// <summary>
    /// Slack Emoji取得API
    /// </summary>
    [Route("api/[controller]")]
    public class EmojiController : Controller
    {
        private readonly string token;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmojiController(IOptions<AppSetting> options)
        {
            token = options.Value.XoxpToken;
        }

        /// <summary>
        /// 使える絵文字の一覧を取得します。
        /// </summary>
        /// <returns>絵文字一覧</returns>
        [HttpGet]
        public async Task<object> Get()
        {
            var customEmoji = await new HttpClient().GetStringAsync($"https://slack.com/api/emoji.list?token={token}");
            dynamic emoji = JsonConvert.DeserializeObject(customEmoji);
            var emojiUrl = JsonConvert.DeserializeObject<Dictionary<string, string>>(emoji.emoji.ToString());
            
            return emojiUrl;
        }
    }
}
