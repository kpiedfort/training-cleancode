using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestSample.Domain;
using UnitTestSample.Repository;

namespace UnitTestSample
{
    internal class ConfirmationCalculator
    {
        public void ProcessConfirmations(Flow flow)
        {
            FlowVersion nomination = flow.FlowVersions.FirstOrDefault(x => x.FlowVersionType == FlowVersionType.Nomination);
            if (nomination != null)
            {
                // Initialize the confirmation equal to the nomination
                FlowVersion confirmation = new FlowVersion
                {
                    FlowVersionType = FlowVersionType.Confirmation,
                    HourlyFlowVersions = new List<HourlyFlowVersion>()
                   
                };

                foreach (HourlyFlowVersion hourlyVersion in nomination.HourlyFlowVersions)
                {
                    confirmation.HourlyFlowVersions.Add(new HourlyFlowVersion()
                    {
                        HourNumber = hourlyVersion.HourNumber,
                        HourlyValue = hourlyVersion.HourlyValue
                    });
                }

                flow.FlowVersions.Add(confirmation);

                // Get capacity constraints and reduce if needed
                IList<CapacityConstraints> capacityConstraints = new CapacityConstraintRepository().FindCapacityConstraints();

                if (capacityConstraints.Any(x => x.ShipperId == flow.ShipperId))
                {
                    IList<CapacityConstraints> constraintsForShipper = capacityConstraints.Where(x => x.ShipperId == flow.ShipperId).ToList();
                    foreach (var capacityConstraint in constraintsForShipper)
                    {
                        HourlyFlowVersion hourlyFlowVersion = confirmation.HourlyFlowVersions.FirstOrDefault(x => x.HourNumber == capacityConstraint.HourNumber);
                        if (hourlyFlowVersion != null)
                        {
                            if (hourlyFlowVersion.HourlyValue > capacityConstraint.MaxCapacity)
                            {
                                hourlyFlowVersion.HourlyValue = capacityConstraint.MaxCapacity;
                            }
                        }
                    }
                }

                // Determine widows
                IList<Widow> widows = new WidowRepository().FindWidows();
                if (widows.Any(x => x.ShipperId == flow.ShipperId))
                {
                    IList<Widow> widowsForShipper = widows.Where(x => x.ShipperId == flow.ShipperId).ToList();
                    foreach (Widow widow in widowsForShipper)
                    {
                        HourlyFlowVersion hourlyFlowVersion = confirmation.HourlyFlowVersions.FirstOrDefault(x => x.HourNumber == widow.HourNumber);
                        if (hourlyFlowVersion != null)
                        {
                            hourlyFlowVersion.IsWidow = true;
                        }
                    }
                }
            }
        }
    }
}
