using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Domain
{
    internal class Flow
    {
        public int ShipperId { get; set; }
        public DateTime GasDay { get; set; }
        public IList<FlowVersion> FlowVersions { get; set; }
    }
}
