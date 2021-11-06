using System;

namespace LessonMonitor.Core
{
    public interface IQuestionsService
    {
        void Create(Question question);
        Question[] Get();
    }
}