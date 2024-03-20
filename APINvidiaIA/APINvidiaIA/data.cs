using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APINvidiaIA
{
    public class data
    {
        public data(MessagesData[] messages, float? temperature, float? top_p, int? max_tokens, int? seed, bool? stream)
        {
            this.messages = messages;
            this.temperature = temperature;
            this.top_p = top_p;
            this.max_tokens = max_tokens;
            this.seed = seed;
            this.stream = stream;
        }

        public MessagesData[] messages { get; set; }
        public float? temperature { get; set; }
        public float? top_p { get; set; }
        public int? max_tokens { get; set; }
        public int? seed { get; set; }
        public bool? stream { get; set; }
    }
}
