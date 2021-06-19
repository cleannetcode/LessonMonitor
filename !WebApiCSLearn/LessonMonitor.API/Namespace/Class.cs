using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionAttributes.Namespace
{
    public class Class
    {
        private int number = 322;
        private string text = "text";
        private readonly bool status;

        public int Number { get => number; }
        public string Text { get => text; }
        public bool Status { get => status; }

        public Class(int a, int b)
        {
            Console.WriteLine($"a = {a} & b = {b}");
        }
        public Class(int a, double b) : this(a, Convert.ToInt32(b))
        {
            Console.WriteLine($"a = {a} & b = {b}");
        }
        public Class(int a, string b) : this(a, 5.5)
        {
            Console.WriteLine($"a = {a} & b = {b}");
        }
        public int[] Fibona4i(int length)
        {
            if (length < 0)
                return null;

            if (length.Equals(0))
            {
                int[] arrIf1 = new int[1];
                arrIf1[0] = 0;
                return arrIf1;
            }

            if (length.Equals(1))
            {
                int[] arrIf2 = new int[3];
                arrIf2[0] = 0;
                arrIf2[1] = 1;
                arrIf2[2] = 1;
                return arrIf2;
            }

            int[] arr = new int[3];
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 1;

            for (int i = 2; i <= length; i++)
            {
                int[] tmp = arr;
                arr = new int[arr.Length + 1];

                for (int j = 0; j < tmp.Length; j++)
                {
                    arr[j] = tmp[j];
                }

                arr[tmp.Length] = tmp[^1] + tmp[^2];
            }
            return arr;
        }
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
