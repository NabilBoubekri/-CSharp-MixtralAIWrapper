using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APINvidiaIA
{
    public class ContentResult
    {
        public string? id { get; set; }
        public ResultChoices[] choices { get; set; }
    }
}
