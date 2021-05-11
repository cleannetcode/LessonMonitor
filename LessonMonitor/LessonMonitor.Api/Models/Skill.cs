using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.Api.Models
{
    [Description("Навыки и умения.")]
    public class Skill
    {
        public int Id { get; set; }
        [Description("Ссылка на родительский элемент.")]
        public int ParentId { get; set; }
        [Description("Наименование навыка или умения.")]
        public string SkillName { get; set; }
    }
}
