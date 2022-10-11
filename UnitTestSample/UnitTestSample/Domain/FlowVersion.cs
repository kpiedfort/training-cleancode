using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Domain
{
    public enum FlowVersionType
    {
        // The request
        Nomination,

        // The confirmation of the request
        Confirmation
    }

    internal class FlowVersion
    {
        public FlowVersionType FlowVersionType { get; set; }
        public List<HourlyFlowVersion> HourlyFlowVersions { get; set; }
    }
}
