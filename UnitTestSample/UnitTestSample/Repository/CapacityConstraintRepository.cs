using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestSample.Domain;

namespace UnitTestSample.Repository
{
    internal class CapacityConstraintRepository : ICapacityConstraintRepository
    {
        public IList<CapacityConstraints> FindCapacityConstraints()
        {
            return new List<CapacityConstraints>()
            {
                new CapacityConstraints(){ShipperId=1, MaxCapacity=80, HourNumber =1},
                new CapacityConstraints(){ShipperId=1, MaxCapacity=80, HourNumber =4},
            };
        }
    }
}
