using LessonMonitor.API.Services.Attributes;
using System;

namespace LessonMonitor.API.Models
{
    [Description("Base model class")]
    public class ModelBase
    {
        [Description("ID")]
        public Guid Id { get; set; }

        [Description("Дата создания")]
        public DateTime CreateDate { get; set; }

        [Description("ФИО создавшего")]
        public string CreateAt { get; set; }

        [Description("Дата модификации")]
        public DateTime UpdateDate { get; set; }

        [Description("Имя изменившего")]
        public string UpdateAt { get; set; }
    }
}
