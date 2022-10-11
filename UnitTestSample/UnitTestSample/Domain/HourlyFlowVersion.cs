using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Domain
{
    internal class HourlyFlowVersion
    {
        public int HourNumber { get; set; }
        public decimal HourlyValue { get; set; }
        public bool IsWidow { get; set; }
    }
}
