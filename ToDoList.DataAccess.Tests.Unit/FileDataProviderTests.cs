using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Tests.Unit
{
    [TestFixture]
    public class FileDataProviderTests
    {
        [SetUp]
        public void BeforeEveryTest()
        {
            var dataProvider = new FileDataProvider();
            var allData = dataProvider.GetItems().ToList();
            foreach (var data in allData)
                dataProvider.RemoveItem(data);
        }
        
        [Test]
        public void AddItem_Should_Work()
        {
            var dataProvider = new FileDataProvider();
            var itemId = 1;
            var category = "TestCategory";
            var desc = "TestDescription";
            var itemName = "TestItemName";
            
            var newItem = new Item()
            {
                ItemId = itemId,
                ItemCategory = category,
                ItemDescription = desc,
                ItemName = itemName
            };

            dataProvider.AddItem(newItem);

            var itemsFromFile = dataProvider.GetItems().ToList();
            itemsFromFile.Should().ContainSingle(x => x.ItemId == itemId);
            var itemToAssert = itemsFromFile.Single(x => x.ItemId == itemId);
            itemToAssert.ItemCategory.Should().Be(category);
            itemToAssert.ItemDescription.Should().Be(desc);
            itemToAssert.ItemName.Should().Be(itemName);
        }
    }
}
