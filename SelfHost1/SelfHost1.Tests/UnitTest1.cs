using System;
using NUnit.Framework;
using SelfHost1.ServiceInterface;
using SelfHost1.ServiceModel;
using ServiceStack.Testing;
using ServiceStack;

namespace SelfHost1.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(ShipperService).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void TestMethod1()
        {
            var service = appHost.Container.Resolve<ShipperService>();

            var response = (ShipperGetResponse)service.Any(new ShipperGetRequest { Id = 1 });

            Assert.NotNull(response.Name);
        }
    }
}
