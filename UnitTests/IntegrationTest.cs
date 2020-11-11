// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using apartment_app;
using Microsoft.EntityFrameworkCore;
using apartment_app.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class IntegrationTest
    {
        private DbContextOptions<PropertiesContext> options;
        private Landlord test;
        private PropertyApplication pA;
        Property newProp;

        /// <summary>
        /// Set up method
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.test = new Landlord();
            this.options = new DbContextOptionsBuilder<PropertiesContext>().UseInMemoryDatabase(databaseName: "Integration Properties Test").Options;
            this.newProp = new Property { ID = 10, AddressLine1 = "hello", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hien", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 };
            this.pA = new PropertyApplication { Applicant = this.test, ApprovedBy = "hien", IsApproved = true, Property = this.newProp };
        }

        /// <summary>
        /// teardown method
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            this.test = null;
            this.options = null;
            this.newProp = null;
            this.pA = null;
        }

        /// <summary>
        /// Integration test method step 1.
        /// </summary>
        [Test]
        public async Task testIntegrationStep1()
        {
            using (var context = new PropertiesContext(this.options))
            {
                await test.AddProperty(this.newProp, context);
                context.Entry<Property>(this.newProp).State = EntityState.Detached;

                Assert.AreEqual(true, context.Property.Any(e => e.ID == 10 && e.AddressLine1.Equals("hello")));
            }
        }

        /// <summary>
        /// Integration test method step 2
        /// </summary>
        [Test]
        public async Task testIntegrationStep2()
        {
            using (var context = new PropertiesContext(this.options))
            {
                await test.AddProperty(this.newProp, context);
                context.Entry<Property>(this.newProp).State = EntityState.Detached;

                Property newProperty = new Property { ID = 10, AddressLine1 = "helloWorld", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hien", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 };
                await test.ManageProperties(newProperty, context);
                context.Entry<Property>(newProperty).State = EntityState.Detached;

                Assert.AreEqual(true, context.Property.Any(e => e.ID == 10 && e.AddressLine1.Equals("helloWorld")));
            }
        }

        /// <summary>
        /// Integration test method step 3 (full implementation)
        /// </summary>
        [Test]
        public async Task testIntegrationStep3()
        {
            using (var context = new PropertiesContext(this.options))
            {
                await test.AddProperty(this.newProp, context);
                context.Entry<Property>(this.newProp).State = EntityState.Detached;

                Property newProperty = new Property { ID = 10, AddressLine1 = "helloWorld", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hien", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 };
                await test.ManageProperties(newProperty, context);
                context.Entry<Property>(newProperty).State = EntityState.Detached;

                await test.DeleteProperty(newProperty, context);
                context.Entry<Property>(newProperty).State = EntityState.Detached;
                await context.SaveChangesAsync();

                Assert.AreEqual(false, context.Property.Any(e => e.ID == 10));
            }
        }

    }

}
