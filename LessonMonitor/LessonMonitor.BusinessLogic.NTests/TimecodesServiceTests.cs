using LessonMonitor.Core.Exeptions;
using LessonMonitor.Core.Repository;
using LessonMonitor.Core;
using NUnit.Framework;
using System;
using Moq;
using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.Service;
using LessonMonitor.Core.Exceptions;

namespace LessonMonitor.BusinessLogic.NTests
{
    class TimecodesServiceTests
    {
        private Mock<ITimecodesRepository> timecodesRepositoryMock;
        private TimecodesService service; 

        [SetUp]
        public void SetUp()
        {
            timecodesRepositoryMock = new Mock<ITimecodesRepository>();
            service = new TimecodesService(timecodesRepositoryMock.Object);
        }

        [Test]
        public void Add_TimecodesIsValid_ShouldAdddedTimecode()
        {
            //arange
            var fixture = new Fixture();
            var timecode = fixture.Build<Timecode>()
                .Create();

            //act
            var result = service.Add(timecode);

            //assert
            result.Should().BeTrue();
            timecodesRepositoryMock.Verify(x => x.Add(timecode), Times.Once);
        }

        [Test]
        public void Add_TimecodesInValid_ShouldThrowTimecodeException()
        {
            //arange
            var fixture = new Fixture();
            var timecode = fixture.Build<Timecode>()
                .With(x => x.LessonId, -10)
                .Without(x => x.MemberId)
                .Create();

            //act
            var result = false;
            var exception = Assert.Throws<TimecodeException>(() => result = service.Add(timecode));

            //assert
            result.Should().BeFalse();
            timecodesRepositoryMock.Verify(x => x.Add(timecode), Times.Never);
        }

        [Test]
        public void Add_TimecodeIsNull_ShouldThrowArgumentNullException()
        {
            //arange
            Timecode timecode = null;

            //act
            var result = false;
            var exception = Assert.Throws<ArgumentNullException>(() => result = service.Add(timecode));

            //assert
            result.Should().BeFalse();
            timecodesRepositoryMock.Verify(x => x.Add(timecode), Times.Never);
        }

        [Test]
        [TestCase(19)]
        [TestCase(1)]
        public void Delete_TimecodeIsValid_ShouldDeletedTimecode(int timecodeId)
        {
            //arange
            //act
            var result = service.Delete(timecodeId);

            //assert
            result.Should().BeTrue();
            timecodesRepositoryMock.Verify(x => x.Delete(timecodeId), Times.Once);
        }

        [Test]
        [TestCase(-19)]
        [TestCase(0)]
        public void Delete_TimecodeInvalid_ShouldthrowTimecodeException(int timecodeId)
        {
            //arange
            //act
            var result = false;
            var exception = Assert.Throws<TimecodeException>(() => result = service.Delete(timecodeId));

            //assert
            exception.Should().NotBeNull()
                .And
                .Match<TimecodeException>(x => x.Message == TimecodesService.TIMECODE_IS_INVALID);

            result.Should().BeFalse();
            timecodesRepositoryMock.Verify(x => x.Delete(timecodeId), Times.Never);
        }

        [Test]
        public void Upgrade_TimecodesIsValid_ShouldUpgradeTimecode()
        {
            //arange
            var fixture = new Fixture();
            var timecode = fixture.Build<Timecode>()
                .Create();

            //act
            var result = service.Upgrade(timecode);

            //assert
            result.Should().BeTrue();
            timecodesRepositoryMock.Verify(x => x.Upgrade(timecode), Times.Once);
        }

        [Test]
        public void Upgrade_TimecodesInvalid_ShouldThrowTimecodeException()
        {
            //arange
            var fixture = new Fixture();
            var timecode = fixture.Build<Timecode>()
                .With(x => x.LessonId, -10)
                .Without(x => x.MemberId)
                .Create();

            //act
            var result = false;
            var exception = Assert.Throws<TimecodeException>(() => result = service.Upgrade(timecode));

            //assert
            result.Should().BeFalse();
            timecodesRepositoryMock.Verify(x => x.Upgrade(timecode), Times.Never);
        }

        [Test]
        public void Upgrade_TimecodeIsNull_ShouldThrowArgumentNullException()
        {
            //arange
            Timecode timecode = null;

            //act
            var result = false;
            var exception = Assert.Throws<ArgumentNullException>(() => result = service.Upgrade(timecode));

            //assert
            result.Should().BeFalse();
            timecodesRepositoryMock.Verify(x => x.Upgrade(timecode), Times.Never);
        }
    }
}
