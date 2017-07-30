using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverReaction.Models.Request
{
    public class EventRequest
    {
        public string Challenge { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public MessageEvent Event { get; set; }

        public bool IsNewPost() => string.IsNullOrEmpty(Subtype);
    }


    public class MessageEvent
    {
        public string Text { get; set; }
    }
}
