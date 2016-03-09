using Castle.Windsor;
using NUnit.Framework;

namespace Blogbook.Infrastructure.Test.ApiIoc.Example
{
    [TestFixture]
    public class IocFromAssemblyTest
    {
        private IDependentClass _dependentClass;
        private IInjectedClass _injectedClass;
        private IWindsorContainer _container;

        [SetUp]
        public void SetUp()
        {
            _container = new WindsorContainer();
            _container.Install(new TestInstallerFromAssembly());
            _injectedClass = _container.Resolve<IInjectedClass>();
            _dependentClass = _container.Resolve<IDependentClass>();
        }

        [TearDown]
        public void TearDown()
        {
            _container.Dispose();
        }

        [Test]
        public void InstallerTest()
        {
            Assert.IsNotNull(_injectedClass);
            Assert.AreEqual("TheValue", _injectedClass.GetValue());

            Assert.IsNotNull(_dependentClass);
            Assert.AreEqual("TheValue", _dependentClass.GetValue());
        }
    }}