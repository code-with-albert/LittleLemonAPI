using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        public bool? Available { get; set; } = null;
        public bool? Discounted { get; set; } = null;
        public int Page { get; set; } = 1;
    }
}