using System;
using System.ComponentModel.DataAnnotations;

namespace OverReaction.Models
{
    public class SlackTeam
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(1)]
        public string AccessToken { get; set; }
        /// <summary>
        /// Slack team ID
        /// </summary>
        [Required, MinLength(1)]
        public string TeamId { get; set; }
    }
}
