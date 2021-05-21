using System;
namespace NamespaceForRead
{
    public class Class1 : Interface1
    {
        private int myVar;
        public int Id { get; set; }
        public  string Name { get; set; }

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public Class1()
        {

        }
        public int Get1()
        {
            return 1;
        }

        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
