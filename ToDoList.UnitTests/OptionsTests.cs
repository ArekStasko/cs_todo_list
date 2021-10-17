using NUnit.Framework;

namespace ToDoList.UnitTests
{

    [TestFixture]
    public class OptionsTests
    {
        private Options _options;

        [SetUp]
        public void SetUp()
        {
            _options = new Options();
        }

        [Test]
        public void GetOptions_WhenCalled_ReturnSelectionOptions()
        {
            // Act
            var result = _options.initializeOptions();

            // Assert
            Assert.That(result != null);
        }
    }
}
