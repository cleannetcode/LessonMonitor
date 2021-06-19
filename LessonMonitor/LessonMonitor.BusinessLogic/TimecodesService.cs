using LessonMonitor.Core;
using LessonMonitor.Core.Exceptions;
using LessonMonitor.Core.Repository;
using LessonMonitor.Core.Service;
using System;
using System.Collections.Generic;

namespace LessonMonitor.BusinessLogic
{
    public class TimecodesService : ITimecodesService
    {
        public const string TIMECODE_IS_INVALID = "Timecode is invalid!";
        private readonly ITimecodesRepository timecodesRepository;
        public TimecodesService(ITimecodesRepository timecodesRepository)
        {
            this.timecodesRepository = timecodesRepository;
        }
        public bool Add(Timecode timecode)
        {
            if (timecode is null)
            {
                throw new ArgumentNullException(nameof(timecode));
            }

            var isInvalid = String.IsNullOrWhiteSpace(timecode.timecode.ToString())
                || String.IsNullOrWhiteSpace(timecode.Title)
                || timecode.MemberId <= 0
                || timecode.LessonId <= 0;

            if (isInvalid)
            {
                throw new TimecodeException(TIMECODE_IS_INVALID);
            }

            timecodesRepository.Add(timecode);
            return true;
        }

        public bool Delete(int timecodeId)
        {
            if(timecodeId <= 0)
            {
                throw new TimecodeException(TIMECODE_IS_INVALID);
            }
            timecodesRepository.Delete(timecodeId);
            return true;
        }

        public List<Timecode> Get()
        {
            throw new NotImplementedException();
        }

        public bool Upgrade(Timecode timecode)
        {
            if (timecode is null)
            {
                throw new ArgumentNullException(nameof(timecode));
            }

            var isInvalid = String.IsNullOrWhiteSpace(timecode.timecode.ToString())
                || String.IsNullOrWhiteSpace(timecode.Title)
                || timecode.MemberId <= 0
                || timecode.LessonId <= 0;

            if (isInvalid)
            {
                throw new TimecodeException(TIMECODE_IS_INVALID);
            }

            timecodesRepository.Upgrade(timecode);
            return true;
        }
    }
}
