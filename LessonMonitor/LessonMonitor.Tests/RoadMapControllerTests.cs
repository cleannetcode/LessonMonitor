using LessonMonitor.Api.Controllers;
using NUnit.Framework;

namespace LessonMonitor.RoadMapControllerTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetModel_TestForDebug()
        {
            // arrange
            var controller = new RoadMapController();

            // act
            var result = controller.GetModel();

            // assert
            Assert.IsNotNull(result);
        }
    }
}