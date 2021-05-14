using LessonMonitor.API.Data.Interfaces;
using LessonMonitor.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.API.Data.Repositoris
{
    public class LessonRepository : ILessonRepository
    {
        private readonly IList<Lesson> lessonMockRepository;
        public LessonRepository()
        {
            lessonMockRepository = new List<Lesson>
            {
                new Lesson
                {
                    Id = Guid.Parse("acf79545-d872-44b5-9347-988e8f4bbb6b"),
                    Title = "Lesson1",
                    Description = "Lesson1",
                },
                new Lesson
                {
                    Id = Guid.Parse("7c4d3453-1f6f-4ef0-bb59-29d43944ebdc"),
                    Title = "Lesson2",
                    Description = "Lesson2",
                },
                new Lesson
                {
                    Id = Guid.Parse("8f6d5b62-b35b-4c43-bda8-2485f77a1d33"),
                    Title = "Lesson3",
                    Description = "Lesson3",
                },
                new Lesson
                {
                    Id = Guid.Parse("d44b6515-4591-4988-a845-39759813b346"),
                    Title = "Lesson4",
                    Description = "Lesson4",
                }
            };
        }
        
        public Lesson GetLessonById(Guid id)
        {
            return lessonMockRepository.FirstOrDefault(l => l.Id.Equals(id));
        }

        public IEnumerable<Lesson> GetLessons()
        {
            return lessonMockRepository.ToList();
        }
    }
}
