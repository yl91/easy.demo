using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Model;
using NUnit.Framework;

namespace Easy.Test.RepositoryTest
{
    public class SupplierRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);

            Assert.IsTrue(supplier.Id > 0);

            var result = RepositoryRegistry.Supplier.FindBy(supplier.Id);

            SupplierAssert(supplier, result);
        }

        [Test]
        public void Add2Test()
        {
            var supplier = new Supplier();
            RepositoryRegistry.Supplier.Add(supplier);

            var result = RepositoryRegistry.Supplier.FindBy(supplier.Id);

            Assert.AreEqual(supplier.Id, result.Id);
        }

        [Test]
        public void UpdateTest()
        {
            Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);

            supplier.Name = "新名字";
            supplier.Tel = "123";
            supplier.BusinessTime = new BusinessTime(new Time(0, 0), new Time(24, 0));

            RepositoryRegistry.Supplier.Update(supplier);

            var actual = RepositoryRegistry.Supplier.FindBy(supplier.Id);

            SupplierAssert(supplier, actual);
        }


        [Test]
        public void RemoveTest()
        {
            Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);

            RepositoryRegistry.Supplier.Remove(supplier);

            var actual = RepositoryRegistry.Supplier.FindBy(supplier.Id);

            Assert.IsNull(actual);
        }


        [Test]
        public void FindByIdsTest()
        {
            Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);
            Supplier supplier1 = Create();
            RepositoryRegistry.Supplier.Add(supplier1);

            var ids = new int[2] { supplier.Id, supplier1.Id };

            var result = RepositoryRegistry.Supplier.FindByIds(ids);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void SelectTest()
        {
            Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);
            Supplier supplier1 = Create();
            RepositoryRegistry.Supplier.Add(supplier1);

            int totalRows = 0;
            var result = RepositoryRegistry.Supplier.Select(1, 1, out totalRows);

            Assert.AreEqual(2, totalRows);
            Assert.AreEqual(1, result.Count());
        }

        [TearDown]
        public void Clear()
        {
            RepositoryRegistry.Supplier.RemoveAll();
        }

        void SupplierAssert(Supplier expected, Supplier actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Tel, actual.Tel);
            Assert.AreEqual(expected.Address, actual.Address);
            Assert.AreEqual(expected.BusinessStatus, actual.BusinessStatus);
            Assert.AreEqual(expected.BusinessTime.Start, actual.BusinessTime.Start);
            Assert.AreEqual(expected.BusinessTime.End, actual.BusinessTime.End);
            Assert.AreEqual(expected.Coordinates.GetHashCode(), actual.Coordinates.GetHashCode());
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
            Assert.AreEqual(expected.DeliveryTime.Length, expected.DeliveryTime.Length);
        }

        public static Supplier Create()
        {
            var coordinates = new Coordinates("133.15888", "4565566.8879879");

            var deliverytime = new DeliveryTime[2] { 
                new DeliveryTime(new Time(12,0),new Time(14,0)),
                new DeliveryTime(new Time(17,0),new Time(19,0))
            };

            var businessTime = new BusinessTime(new Time(10, 0), new Time(22, 0));

            return Create(businessTime, coordinates, deliverytime);
        }

        public static Supplier Create(BusinessTime businessTime = null, Coordinates coordinates = null, DeliveryTime[] deliverytime = null)
        {
            var supplier = new Supplier()
            {
                Name = "好美味餐厅",
                Address = "北京朝阳区三间房",
                Tel = "18500191543",
                BusinessTime = businessTime,
                Coordinates = coordinates,
                DeliveryTime = deliverytime,
            };

            return supplier;
        }
    }
}
