namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Question : BaseEntity
    {
        public string Description { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
