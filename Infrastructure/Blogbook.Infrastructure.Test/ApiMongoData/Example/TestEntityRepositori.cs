using Blogbook.Infrastructure.ApiMongoData;

namespace Blogbook.Infrastructure.Test.ApiMongoData.Example
{
    public class TestEntityRepositori : MongoRepository<TestEntity>, ITestEntityRepositori
    {
        public TestEntityRepositori(
            string database,
            string collectionName) :
                base(database, collectionName)
        {
        }
    }
}