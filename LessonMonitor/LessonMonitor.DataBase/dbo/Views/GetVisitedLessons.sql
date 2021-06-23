
CREATE VIEW [dbo].[GetVisitedLessons]
AS
SELECT dbo.Lessons.Id, dbo.Lessons.Title, dbo.Users.Name AS UserName, dbo.UsersLessons.CreatedDate AS VisitedDate
FROM   dbo.Users INNER JOIN
             dbo.UsersLessons ON dbo.Users.Id = dbo.UsersLessons.UserId INNER JOIN
             dbo.Lessons ON dbo.UsersLessons.LessonId = dbo.Lessons.Id