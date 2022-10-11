using UnitTestSample.Domain;

namespace UnitTestSample.Repository;

internal interface ICapacityConstraintRepository
{
    IList<CapacityConstraints> FindCapacityConstraints();
}