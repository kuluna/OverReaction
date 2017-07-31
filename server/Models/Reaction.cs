using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OverReaction.Models
{
    public class Reaction
    {
        [Key]
        public int Id { get; set; }
        public string TeamId { get; set; }
        public string Word { get; set; }
        public string Emoji { get; set; }
    }
}
