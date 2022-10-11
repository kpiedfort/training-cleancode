using System;
using UnitTestSample.Domain;
using UnitTestSample.Repository;

namespace UnitTestSample // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            // Setup test data
            Flow flow = GenerateFlow();

            //Calculate confirmation
            var calculator = new ConfirmationCalculator();
            calculator.ProcessConfirmations(flow);

            // Print confirmations
            FlowVersion confirmation = flow.FlowVersions.First(x => x.FlowVersionType == FlowVersionType.Confirmation);

            foreach (HourlyFlowVersion hourlyFlowVersion in confirmation.HourlyFlowVersions)
            {
                Console.WriteLine($"For hour {hourlyFlowVersion.HourNumber} the confirmed value is {hourlyFlowVersion.HourlyValue} and the widow flag is set to {hourlyFlowVersion.IsWidow}");
            }
            Console.ReadKey();
        }

        private static Flow GenerateFlow()
        {
            Flow flow = new Flow()
            {
                ShipperId = 1,
                GasDay = DateTime.Now
            };

            FlowVersion nomination = new FlowVersion
            {
                FlowVersionType = FlowVersionType.Nomination,
                HourlyFlowVersions = new List<HourlyFlowVersion>()
                {
                    new HourlyFlowVersion
                    {
                        HourNumber = 1,
                        HourlyValue = 100
                    },
                    new HourlyFlowVersion
                    {
                        HourNumber = 2,
                        HourlyValue = 100
                    },
                    new HourlyFlowVersion
                    {
                        HourNumber = 3,
                        HourlyValue = 100
                    },
                    new HourlyFlowVersion
                    {
                        HourNumber = 4,
                        HourlyValue = 100
                    },
                }
            };
            flow.FlowVersions = new List<FlowVersion>() {nomination};
            return flow;
        }
    }
}