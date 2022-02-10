namespace HomeworkApi.Attributes
{
    public class DescriptionAttribute: Attribute
    {
        public string Description { get;}
        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
