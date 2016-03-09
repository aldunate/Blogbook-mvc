using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Blogbook.Infrastructure.Test.ApiMongoData.Example
{
    [TestFixture]
    public class MongoDataTest
    {
        private ITestEntityRepositori _repo;

        [SetUp]
        public void SetUp()
        {
            _repo = new TestEntityRepositori("BlogbookMvcInfraestructureTest", "RepoTest");
            _repo.DropCollection();
        }

        [TearDown]
        public void TearDown()
        {
            _repo.DropCollection();
        }

        [Test]
        public void InsertFindAndRemove()
        {
            var ent = new TestEntity
            {
                Description = "Test Description",
                TimeStamp = DateTime.Now,
                SubEntities = new List<TestSubEntity>
                {
                    new TestSubEntity
                    {
                        Id = "NoAnObjectId",
                        IntegerNumber = 1
                    },
                    new TestSubEntity
                    {
                        Id = "NoAnObjectId",
                        IntegerNumber = 2
                    }
                }
            };

            _repo.InsertOne(ent);
            var firstId = ent.Id;
            var foundEntityById = _repo.FindOne(firstId);
            Assert.IsNotNull(foundEntityById);
            Assert.AreEqual(2,foundEntityById.SubEntities.Count);

            ent.Id = null;
            _repo.InsertOne(ent);
            var foundEntityByIdSecond = _repo.FindOne(ent.Id);
            Assert.IsNotNull(foundEntityByIdSecond);
            Assert.AreEqual(ent.Id, foundEntityByIdSecond.Id);
            _repo.DeleteOne(ent.Id.ToString());

            var foundEntityByDescription = _repo.FindOne(x => x.Description == ent.Description);
            Assert.IsNotNull(foundEntityByDescription);
            Assert.AreEqual(ent.Description, foundEntityByDescription.Description);

            var k = _repo.DeleteOne(firstId.ToString());
            Assert.AreEqual(1, k);

            var foundEntityByIdDeleted = _repo.FindOne(firstId);
            Assert.IsNull(foundEntityByIdDeleted);
        }
    }}