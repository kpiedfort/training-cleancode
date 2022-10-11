using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestSample.Domain;

namespace UnitTestSample.Repository
{
    internal class WidowRepository : IWidowRepository
    {
        public IList<Widow> FindWidows()
        {
            return new List<Widow>()
            {
                new Widow(){ShipperId=1, HourNumber=2},
            };
        }
    }
}
