using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Infrastructure.Test.ApiMongoData.Example
{
    public interface ITestEntityRepositori : IMongoRepository<TestEntity>
    {
        
    }
}