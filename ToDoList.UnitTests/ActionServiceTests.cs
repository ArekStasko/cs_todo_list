using NUnit.Framework;
using ToDoList;
using ToDoList.Storage;

namespace ToDoList.UnitTests
{
    [TestFixture]
    class ActionServiceTests
    {
        private EditionServices _actionService;
        private MainStorage _mainStorage;

        [SetUp]
        public void SetUp()
        {
            _mainStorage = new MainStorage();
            _actionService = new EditionServices(_mainStorage.items, _mainStorage.categories);

        }
        /*
        [Test] 
        public void AddCategory_WhenInsertCategory_ShouldAddCategory()
        {
            _actionService.AddCategory("CategoryName");

            Assert.That(_mainStorage.categories[0].CategoryName == "CategoryName");
        }
        */

    }
}
