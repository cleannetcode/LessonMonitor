namespace LessonMonitor.Core
{
    public class Question
    {
        private string title { get; set; }
        public string Text { get; set; }
        public User User { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                if (value == null)
                {
                    title = "Empty";
                }
                else
                {
                    title = value;
                }

            }
        }

        public Question(string questionText)
        {
            Text = questionText;
            Title = questionText;
        }

        public Question()
        {
            Title = Text;
            User = new User
            {
                Name = "Alesha",
                Age = 12,
            };
        }

    }
}