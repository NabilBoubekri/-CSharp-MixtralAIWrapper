using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APINvidiaIA
{
    public class ResultChoices
    {
        public int? index { get; set; }
        public ResultDelta? delta { get; set; }
        public string? stop { get; set; }
    }
}
