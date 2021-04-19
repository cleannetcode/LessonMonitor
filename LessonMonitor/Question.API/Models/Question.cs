using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question.API.Models
{
    public class Question
    {
        public Guid Id { get; private set; }
        public string Theme { get; set; }
        public string Answer { get; set; }

        public Question()
        {
            Id = Guid.NewGuid();
        }
    }
}
