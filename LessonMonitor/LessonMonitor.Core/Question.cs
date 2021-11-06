namespace LessonMonitor.Core
{
    public class Question
    {
        private string title { get; set; }
        public string text { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                if (value == null)
                {
                    title = text.Substring(0, 30);
                }

            }
        }
    }
}