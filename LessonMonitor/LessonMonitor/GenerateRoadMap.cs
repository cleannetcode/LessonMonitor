using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor
{
    public class GenerateRoadMap
    {
        private void SetEndToStartDate(List<RoadMap> roadMaps, Project proj, string task, DateTime dateStart, DateTime dateEnd)
        {
            roadMaps.Add(new RoadMap(proj, GetPerson(), task.ToString(), GetStatus(), dateStart: dateEnd, dateEnd: dateStart));
        }

        private void SetStartToEndDate(List<RoadMap> roadMaps, Project proj, string task, DateTime dateStart, DateTime dateEnd)
        {
            roadMaps.Add(new RoadMap(proj, GetPerson(), task.ToString(), GetStatus(), dateStart: dateStart, dateEnd: dateEnd));
        }

        public List<RoadMap> GetRoadsMap(Project proj)
        {
            List<RoadMap> roadMaps = new List<RoadMap>();

            var tasks = GetTask();

            for (int i = 0; i < 15; i++)
            {
                DateTime dateStart = GetDate();
                DateTime dateEnd = GetDate();

                if (dateStart.Year > dateEnd.Year)
                {
                    SetEndToStartDate(roadMaps, proj, tasks[i], dateStart, dateEnd);
                }
                else if (dateStart.Year == dateEnd.Year)
                {
                    if (dateStart.Month > dateEnd.Month)
                    {
                        if (dateStart.Day > dateEnd.Day)
                        {
                            SetEndToStartDate(roadMaps, proj, tasks[i], dateStart, dateEnd);
                            continue;
                        }

                        SetEndToStartDate(roadMaps, proj, tasks[i], dateStart, dateEnd);
                    }
                    else if (dateStart.Hour > dateEnd.Hour)
                    {
                        SetEndToStartDate(roadMaps, proj, tasks[i], dateStart, dateEnd);
                    }
                }
                else
                {
                    SetStartToEndDate(roadMaps, proj, tasks[i], dateStart, dateEnd);
                }
            }

            return roadMaps;
        }

        private Status GetStatus()
        {
            Random random = new Random();

            int decide = random.Next(0, 3);

            Status result = Status.NotStart;

            switch ((Status)decide)
            {
                case Status.NotStart:
                    result = Status.NotStart;
                    break;

                case Status.InProgress:
                    result = Status.InProgress;
                    break;

                case Status.Overdue:
                    result = Status.Overdue;
                    break;
            }

            return result;
        }

        private List<string> GetTask()
        {
            Random random = new Random();

            List<string> tasks = new List<string>();

            tasks.Add("Назначить дату стартового совещания");
            tasks.Add("Договориться о целях");
            tasks.Add("Подробные требования");
            tasks.Add("Требования к оборудованию");
            tasks.Add("Окончательный план ресурсов");
            tasks.Add("Кадры");
            tasks.Add("Технические требования");
            tasks.Add("Разработка БД");
            tasks.Add("Разработка API");
            tasks.Add("Пользовательский интерфейс клиента");
            tasks.Add("Тестирование");
            tasks.Add("Разработка завершена");
            tasks.Add("Конфигурация оборудования");
            tasks.Add("Тестирование системы");
            tasks.Add("Запуск системы");

            return tasks;
        }

        private Person GetPerson()
        {
            Random random = new Random();

            List<Person> persons = new List<Person>();

            persons.Add(new Person(firstName: "Алексей", lastName: "С."));
            persons.Add(new Person(firstName: "Константин", lastName: "Б."));
            persons.Add(new Person(firstName: "Катерина", lastName: "Б."));
            persons.Add(new Person(firstName: "Фёдор", lastName: "С."));
            persons.Add(new Person(firstName: "Надежда", lastName: "Г."));
            persons.Add(new Person(firstName: "Александр", lastName: "В."));
            persons.Add(new Person(firstName: "Константин", lastName: "К."));
            persons.Add(new Person(firstName: "Светлана", lastName: "А."));



            return persons[random.Next(0, persons.Count)];
        }

        private DateTime GetDate()
        {
            Random random = new Random();

            int year = 2020;
            int month = random.Next(5, 8);

            return new DateTime(year, month, random.Next(8, DateTime.DaysInMonth(year, month)));
        }
    }
}
