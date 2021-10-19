using NUnit.Framework;
using ToDoList;
using ToDoList.Storage;

namespace ToDoList.UnitTests
{
    [TestFixture]
    class ActionServiceTests
    {
        private ActionService _actionService;
        private MainStorage _mainStorage;

        [SetUp]
        public void SetUp()
        {
            _actionService = new ActionService();
            _mainStorage = new MainStorage();
        }

        [Test] IgnoreException
        public void AddCategory_WhenInsertCategory_ShouldAddCategory()
        {
            _actionService.AddCategory("CategoryName");

            Assert.That(_mainStorage.categories[0].CategoryName == "CategoryName");
        }
        
    }
}
