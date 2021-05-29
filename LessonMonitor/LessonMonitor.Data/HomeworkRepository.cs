using LessonMonitor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using LessonMonitor.Core.Models;

namespace LessonMonitor.Data
{
    public class HomeworkRepository: IHomeworkRepository
    {
        private static readonly List<Homework> _homeworks = new List<Homework>()
        {
            new Homework() { Name = "Homework/aspnet/1", Description = "Создать веб апи проект, запустить и попробовать отладить weather controller; создать один контроллер по образу и подобию Weather controller. Контроллеры на выбор" },
            new Homework() { Name = "Homework/sql/1", Description = "Скачать и установить все необходимые инструменты и сервисы; Создать проект для работы с БД; Смоделировать БД, для моделирования следует выбрать пять сущностей из списка; Создать БД с помощью visual studio" }
        };

        public Homework GetHomeworkByName(string name) => _homeworks.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        public void AddHomework(Homework homework) => _homeworks.Add(homework);

    }
}
