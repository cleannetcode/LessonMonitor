using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonMonitor.Roadmaps;
using System.Text.RegularExpressions;
using System.Reflection;

namespace LessonMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoadmapController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Roadmap> Get([FromQuery] Roadmap roadmap)
        {
            // Использовать для того, чтобы туда передать person часть
            //CheckModelPerson(person);
            CheckModelRoadMap(roadmap);

            return Ok(roadmap);
        }

        private void CheckModelRoadMap(Roadmap roadmap)
        {
            // Получаем данные о roadmap
            var roadmapModel = roadmap.GetType();

            // Список, где хранятся DateTime свойства
            List<DateTime?> dateTimeRoadmap = new List<DateTime?>();
            List<CustomAttributeData> customAttributes = new List<CustomAttributeData>();

            foreach (var property in roadmapModel.GetProperties())
            {
                foreach (var customAttribute in property.GetCustomAttributesData())
                {
                    // Проверить Person
                    if (customAttribute.AttributeType.Name == "PersonNameAttribute")
                    {
                        // Отправить в метод обработки этого атрибута
                        var value = property.GetValue(roadmap);
                        CheckModelPerson(customAttribute, (Person)value);
                    }

                    // Проверить Task
                    if (customAttribute.AttributeType.Name == "TaskAttribute")
                    {
                        // Отправить в метод обработки этого атрибута
                        var value = property.GetValue(roadmap) is null ? String.Empty : property.GetValue(roadmap);
                        CheckModelTask(customAttribute, value.ToString());
                    }

                    // Проверить DateTime
                    if (customAttribute.AttributeType.Name == "DateTimeAttribute")
                    {
                        var value = property.GetValue(roadmap);
                        
                        dateTimeRoadmap.Add(Convert.ToDateTime(value));
                        customAttributes.Add(customAttribute);

                        if (dateTimeRoadmap.Count > 1 && customAttributes.Count > 1)
                        {
                            CheckModelDateTime(customAttributes, dateTimeRoadmap);
                        }
                    }
                }
            }
        }
        private void CheckModelPerson(CustomAttributeData customAttribute, Person value)
        {
            var valuePerson = value._name.ToString();

            // Проверить, пустое ли имя
            if (String.IsNullOrEmpty(valuePerson))
            {
                throw new Exception("Вы ввели пустое имя!");
            }

            // Для проверки на наличие числа
            Regex regexNumbers = new Regex(@"\d+");
            MatchCollection matchNumbers = regexNumbers.Matches(valuePerson);

            if (matchNumbers.Count > 0)
            {
                throw new Exception("Цифр в именах быть не должно!");
            }

            // для проверки, что состоит из русских букв
            Regex regexRussianLetters = new Regex(@"[A-z]+");
            MatchCollection matchRussianLetters = regexRussianLetters.Matches(valuePerson.ToString());

            if (matchRussianLetters.Count > 0)
            {
                throw new Exception("Имя должно состоять только из русских букв!");
            }
        }
        private void CheckModelTask(CustomAttributeData customAttribute, string value)
        {
            // Проверить, пустая ли задача
            if (String.IsNullOrEmpty(value.ToString()))
            {
                throw new Exception("Вы не задали никакой задачи!");
            }
        }
        private void CheckModelDateTime(List<CustomAttributeData> customAttributes, List<DateTime?> value)
        {
            // Проверить, пуста ли дата начала
            if (value[0] == default(DateTime))
            {
                throw new Exception("Вы не ввели дату начала ");
            }

            // если дата окончания добавлена, проверить, она больше даты начала
            if (value[1] != default(DateTime) && value[1] < value[0])
            {
                throw new Exception("Ваша дата окончания меньше даты начала!");
            }
        }
    }
}
