using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverReaction.Models
{
    public class UrlValidationEvent
    {
        public string Challenge { get; set; }

        public UrlValidationEvent(string challenge)
        {
            this.Challenge = challenge;
        }
    }
}
