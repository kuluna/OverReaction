using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OverReaction.Models
{
    public class SlackEventLog
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        [Required]
        public DateTimeOffset Timestamp { get; set; }
    }
}
