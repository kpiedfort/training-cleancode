using UnitTestSample.Domain;

namespace UnitTestSample.Repository;

internal interface IWidowRepository
{
    IList<Widow> FindWidows();
}