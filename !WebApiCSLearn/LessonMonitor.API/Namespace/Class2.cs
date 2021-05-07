using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionAttributes.Namespace
{
    public class Class2
    {
        private int number = 322;
        private string text = "text";
        private readonly bool status;

        public int Number { get => number; }
        public string Text { get => text; }
        public bool Status { get => status; }

        public string Method(string text)
        {
            return text;
        }
        public int Method(int number)
        {
            return number;
        }
        public void ShowAllProperties()
        {
            Console.WriteLine($"{number}\t{text}\t{status}");
        }
    }
}
