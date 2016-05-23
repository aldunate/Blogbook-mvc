using System;
using System.Collections.Generic;
using Blogbook.Api.Core.Articles;
using Blogbook.Infrastructure.ApiMongoData;
using NUnit.Framework;

namespace Blogbook.Api.Core.Tests.Services
{
    [TestFixture]
    public class ArticlesServiceTest
    {
        private IArticlesService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new ArticlesService();
        }

        [TearDown]
        public void TearDown()
        {
            _service.Dispose();
        }

        [Test]
        public void MainTest()
        {
            var audit = new AuditTerm
            {
                By = "aldunate",
                On = DateTime.UtcNow
            };

            var article = new ArticleEntity
            {
                Title = "Prueba",
                ContentUrl = "url/ejemplo",
                ImageUrl = "asdasdas",
                Tags = new List<string> {"1", "2", "3"},
                Categories = new List<string> {"a", "b"},
            };

            article = _service.Insert(article, audit);

            Assert.NotNull(article.Audit);
            Assert.AreEqual(audit.By, article.Audit.Created.By);
            Assert.AreEqual(audit.On, article.Audit.Created.On);
            Assert.AreNotEqual("", article.Id);

        }
    }
}