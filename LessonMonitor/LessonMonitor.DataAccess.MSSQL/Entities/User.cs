namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Member Member { get; set; }
    }
}
