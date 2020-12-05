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
                Assert.AreEqual(true, context.Property.Any(e => e.ID == 110 && e.AddressLine1.Equals("hello")));
                Assert.AreEqual(false, context.Property.Any(e => e.ID == 110 && e.AddressLine1.Equals("k")));
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

        /// <summary>
        /// Test when user inputs more space available than the total space
        /// </summary>
        /// <returns>pass or fail</returns>
        [Test]
        public async Task TestAvailableToTotal()
        {
            using (var context = new PropertiesContext(this.options))
            {
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 2, AddressLine1 = "hello1232314", AddressLine2 = "World122341233", Description = "Cool", FileNames = null, Name = "hien1231123123", Owner = null, Rent = 100, SpacesAvailable = 999, TotalSpaces = 120 }, context));
            }
        }


        /// <summary>
        /// Test method to test the boundaries of the functions AddProperty()
        /// </summary>
        /// <returns>pass or fail</returns>
        [Test]
        public async Task TestBVAAddProperties()
        {
            using (var context = new PropertiesContext(this.options))
            {
                // BVA 1
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = -5, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 100, SpacesAvailable = 110, TotalSpaces = 120 }, context));

                // BVA 2
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = -2, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 7, SpacesAvailable = 8, TotalSpaces = 9 }, context));

                // BVA 3
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 10000005, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 30, SpacesAvailable = 40, TotalSpaces = 50 }, context));

                // BVA 4
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 10005555, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 90, SpacesAvailable = 85, TotalSpaces = 100 }, context));

                // BVA 5
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 20, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = -4, SpacesAvailable = 30, TotalSpaces = 50 }, context));

                // BVA 6
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 10, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = -1, SpacesAvailable = 7, TotalSpaces = 9 }, context));

                // BVA 7
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 11, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 10000050, SpacesAvailable = 13, TotalSpaces = 15 }, context));

                // BVA 8
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 18, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 19000000, SpacesAvailable = 19, TotalSpaces = 20 }, context));

                // BVA 9
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 55, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 56, SpacesAvailable = -10, TotalSpaces = 70 }, context));

                // BVA 10
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 30, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 90, SpacesAvailable = -6, TotalSpaces = 10 }, context));

                // BVA 11
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 3, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 99, SpacesAvailable = 10000090, TotalSpaces = 88 }, context));

                // BVA 12
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 30, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 80, SpacesAvailable = 17700000, TotalSpaces = 20 }, context));

                // BVA 13
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 11, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 12, SpacesAvailable = 13, TotalSpaces = -9 }, context));

                // BVA 14
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 21, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 22, SpacesAvailable = 23, TotalSpaces = -3 }, context));

                // BVA 15
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 77, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 78, SpacesAvailable = 79, TotalSpaces = 10000998 }, context));

                // BVA 16
                Assert.AreEqual(false, await this.test.AddProperty(new Property { ID = 111, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 112, SpacesAvailable = 113, TotalSpaces = 19876543 }, context));

                // BVA 17
                Assert.AreEqual(true, await this.test.AddProperty(new Property { ID = 0, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 680, SpacesAvailable = 25, TotalSpaces = 50 }, context));
            }
        }


        /// <summary>
        /// Test method to test the boundaries of the functions ManageProperty()
        /// </summary>
        /// <returns>pass or fail</returns>
        [Test]
        public async Task TestBVAManageProperties()
        {
            using (var context = new PropertiesContext(this.options))
            {
                // BVA 1
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = -5, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 100, SpacesAvailable = 110, TotalSpaces = 120 }, context));

                // BVA 2
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = -2, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 7, SpacesAvailable = 8, TotalSpaces = 9 }, context));

                // BVA 3
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 10000005, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 30, SpacesAvailable = 40, TotalSpaces = 50 }, context));

                // BVA 4
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 10005555, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 90, SpacesAvailable = 85, TotalSpaces = 100 }, context));

                // BVA 5
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 20, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = -4, SpacesAvailable = 30, TotalSpaces = 50 }, context));

                // BVA 6
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 10, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = -1, SpacesAvailable = 7, TotalSpaces = 9 }, context));

                // BVA 7
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 11, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 10000050, SpacesAvailable = 13, TotalSpaces = 15 }, context));

                // BVA 8
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 18, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 19000000, SpacesAvailable = 19, TotalSpaces = 20 }, context));

                // BVA 9
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 55, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 56, SpacesAvailable = -10, TotalSpaces = 70 }, context));

                // BVA 10
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 30, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 90, SpacesAvailable = -6, TotalSpaces = 10 }, context));

                // BVA 11
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 3, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 99, SpacesAvailable = 10000090, TotalSpaces = 88 }, context));

                // BVA 12
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 30, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 80, SpacesAvailable = 17700000, TotalSpaces = 20 }, context));

                // BVA 13
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 11, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 12, SpacesAvailable = 13, TotalSpaces = -9 }, context));

                // BVA 14
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 21, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 22, SpacesAvailable = 23, TotalSpaces = -3 }, context));

                // BVA 15
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 77, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 78, SpacesAvailable = 79, TotalSpaces = 10000998 }, context));

                // BVA 16
                Assert.AreEqual(false, await this.test.ManageProperties(new Property { ID = 111, AddressLine1 = "hello1234", AddressLine2 = "World122343", Description = "Cool", FileNames = null, Name = "hien123123", Owner = null, Rent = 112, SpacesAvailable = 113, TotalSpaces = 19876543 }, context));
            }
        }
    }
}
