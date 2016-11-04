using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverReaction.Models
{
    /// <summary>
    /// Emoji情報
    /// </summary>
    public class Emoji
    {
        /// <summary>
        /// 絵文字名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 絵文字の画像URL
        /// </summary>
        public string Url { get; set; }
    }
}
