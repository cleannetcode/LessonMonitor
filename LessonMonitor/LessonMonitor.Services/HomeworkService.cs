using LessonMonitor.Core.Interfaces;
using LessonMonitor.Core.Models;
using System.Linq;

namespace LessonMonitor.Services
{
    public class HomeworkService: IHomeworkService
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IRandomizerService _randomizerService;

        public HomeworkService(IHomeworkRepository homeworkRepository, IRandomizerService randomizerService)
        {
            _homeworkRepository = homeworkRepository;
            _randomizerService = randomizerService;
        }

        public void CreateRandomHomework(out string name)
        {
            name = _randomizerService.GetRandomString(15);

            var descriptionsWords = Enumerable
                .Range(1, 3)
                .Select(x => _randomizerService.GetRandomString(10));
            var description = string.Join(" ", descriptionsWords);
            var homework = new Homework() { Name = name, Description = description };

            _homeworkRepository.AddHomework(homework);
        }
    }
}
