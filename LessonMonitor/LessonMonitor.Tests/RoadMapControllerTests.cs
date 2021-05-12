using LessonMonitor.Api;
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
            var skillRepository = new InMemorySkillRepository();
            var controller = new RoadMapController(skillRepository);

            // act
            var result = controller.GetModel();

            // assert
            Assert.IsNotNull(result);
        }
    }
}