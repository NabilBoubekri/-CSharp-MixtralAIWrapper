using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APINvidiaIA
{
    public class MessagesData
    {
        public MessagesData(string? content, string? role)
        {
            this.content = content;
            this.role = role;
        }

        public string? content { get; set; }
        public string? role { get; set; }
    }
}
