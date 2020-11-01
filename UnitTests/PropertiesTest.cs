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

namespace UnitTests
{
    [TestFixture]
    public class PropertiesTest
    {
        private DbContextOptions<PropertiesContext> options;
        private Landlord test;

        /// <summary>
        /// setup method
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<PropertiesContext>().UseInMemoryDatabase(databaseName: "Properties Test").Options;
            this.test = new Landlord();
        }

        /// <summary>
        /// teardown method
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            this.options = null;
            this.test = null;
        }

        /// <summary>
        /// Test method that tests the add property interaction of the db
        /// </summary>
        /// <returns>pass or fail</returns>
        [Test]
        public async Task TestAddProperties()
        {
           using(var context = new PropertiesContext(this.options))
           {
                // add property to database, will return true if added
                Assert.AreEqual(true, await this.test.AddProperty(new Property { ID = 10, AddressLine1 = "hello", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hien", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 }, context));

                // add another property to the database
                Assert.AreEqual(true, await this.test.AddProperty(new Property { ID = 110, AddressLine1 = "k", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hiena", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 }, context));

                // add property to database, will return false because property already added
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 10, AddressLine1 = "hello", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hien", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 }, context));
            }
        }

        /// <summary>
        /// Test method that tests the edit property interaction of the db
        /// </summary>
        /// <returns>pass or fail</returns>
        [Test]
        public async Task TestEditProperties()
        {
            using (var context = new PropertiesContext(this.options))
            {
                // edit property, will return true if property exists and edited
                Assert.AreEqual(true, await this.test.ManageProperties(new Property { ID = 110, AddressLine1 = "hello", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hien", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 }, context));
                
                // catch exception of no entry to edit
                try
                {
                    await this.test.ManageProperties(new Property { ID = 15, AddressLine1 = "hello", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hien", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 }, context);
                    Assert.Fail();
                }
                catch
                {
                    Assert.Pass();
                }           
            }
        }

        /// <summary>
        /// Test method that tests the delete property interaction of the db
        /// </summary>
        /// <returns>pass or fail</returns>
        [Test]
        public async Task TestDeleteProperties()
        {
            using (var context = new PropertiesContext(this.options))
            { 
                // delete the property
                Assert.AreEqual(true, await test.DeleteProperty(new Property { ID = 10, AddressLine1 = "hello", AddressLine2 = "World", Description = "Cool", FileNames = null, Name = "hien", Owner = null, Rent = 100, SpacesAvailable = 2, TotalSpaces = 6 }, context));

                // check property is deleted
                Assert.AreEqual(false, context.Property.Any(e => e.ID == 10));
            }
        }
    }
}
