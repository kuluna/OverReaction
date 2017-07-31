
using System.ComponentModel.DataAnnotations;

namespace OverReaction.Models.Request
{
    public class EventRequest
    {
        /// <summary>
        /// Events API "url_validate" challenge
        /// </summary>
        public string Challenge { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        [Required]
        public string Token { get; set; }
        /// <summary>
        /// Slack team ID
        /// </summary>
        [Required]
        public string TeamId { get; set; }
        /// <summary>
        /// Event type
        /// </summary>
        [Required]
        public string Type { get; set; }
        /// <summary>
        /// Event subtype (may be null)
        /// </summary>
        public string Subtype { get; set; }
        /// <summary>
        /// Event body
        /// </summary>
        public MessageEvent Event { get; set; }

        /// <summary>
        /// New post
        /// </summary>
        /// <returns></returns>
        public bool IsNewPost() => string.IsNullOrEmpty(Subtype);
    }

    /// <summary>
    /// Slack message event
    /// </summary>
    public class MessageEvent
    {
        /// <summary>
        /// Message event type
        /// </summary>
        [Required]
        public string Type { get; set; }
        /// <summary>
        /// User ID
        /// </summary>
        [Required]
        public string User { get; set; }
        /// <summary>
        /// Message text
        /// </summary>
        [Required]
        public string Text { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [Required]
        public double Ts { get; set; }
    }
}
