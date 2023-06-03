using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Dto1
    {
        public string Code { get; set; } = "Dto1";
        public int Number { get; set; } = 1;
        public string Is { get; set; } = "true";
    }
    internal class Dto2
    {
        public string Name { get; set; } = "Dto2";
        public int Count { get; set; } = 2;
        public bool Is { get; set; } = false;
    }
}
