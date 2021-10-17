using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Models.Attributes
{
    public class RoadMapValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var roadMap = value as RoadMap;

            if (roadMap.StartDate < roadMap.EndDate)
                return true;
            else
            {
                ErrorMessage = "Дата начала(StartDate) должна быть меньше даты конца(EndDate)";
                return false;
            }
        }
    }
}
