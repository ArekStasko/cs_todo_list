using NUnit.Framework;
using ToDoList;

namespace ToDoList.UnitTests
{
    [TestFixture]
    class ActionServiceTests
    {
        private ActionService _actionService;

        [SetUp]
        public void SetUp()
        {
            _actionService = new ActionService();
        }
        
    }
}
