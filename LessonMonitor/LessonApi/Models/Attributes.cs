namespace LessonApi.Models
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MaxLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
        public MaxLengthAttribute(int MaxValue)
        {
            MaxLength = MaxValue;
        }
        public MaxLengthAttribute(string MaxValue)
        {
                MaxLength = int.Parse(MaxValue);           
        }
    }
}
