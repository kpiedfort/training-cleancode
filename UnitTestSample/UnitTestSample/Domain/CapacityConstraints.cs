using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Domain
{
    internal class CapacityConstraints
    {
        public int ShipperId { get; set; }
        public decimal MaxCapacity { get; set; }
        public int HourNumber { get; set; }
    }
}
