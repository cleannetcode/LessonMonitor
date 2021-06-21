using System;
using System.Data.SqlClient;
using System.Text;

namespace LessonMonitor.LWorkConnectionDB
{
    class Program
    {
        private const string CONNECTION_STRING = @"Data Source=ASHTON\ASHTON;Initial Catalog=LessonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            PrindMembers();
            Console.WriteLine("===================");
            PrindMembers(2);
            Console.WriteLine("===================");
            PrindMembersLike("Evgenii");
            Console.WriteLine("===================");

            CreateLesson(new Lesson
            {
                Title = "SQL",
                Description = "Подключаемся к mssql с помощью ado.net",
                StartDate = DateTime.Now,
                CreatedDate = DateTime.Now
            });

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static void CreateLesson(Lesson lesson)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                var command = new SqlCommand(@"
                            INSERT INTO Lessons(Title, Description, StartDate, CreatedDate)
                            VALUES (@Title, @Description, @StartDate, @CreatedDate);
                            SET @LessonId = scope_identity();
                            ",
                connection);

                command.Parameters.AddWithValue("@Title", lesson.Title);
                command.Parameters.AddWithValue("@Description", lesson.Description);
                command.Parameters.AddWithValue("@StartDate", lesson.StartDate);
                command.Parameters.AddWithValue("@CreatedDate", lesson.CreatedDate);

                var resultParameter = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Output,
                    SqlDbType = System.Data.SqlDbType.Int,
                    ParameterName = "@LessonId"
                };

                command.Parameters.Add(resultParameter);

                command.ExecuteNonQuery();

                Console.WriteLine(command.Parameters["@LessonId"].Value);
            }
        }

        private static void PrindMembersLike(string username)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                var command = new SqlCommand(@"
                            SELECT Id, Name, Nicknames, Email, CreateDate FROM Members
                            WHERE Name LIKE @Name",
                connection);

                var parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = username,
                    SqlDbType = System.Data.SqlDbType.NVarChar
                };

                command.Parameters.Add(parameter);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var nickNames = reader.GetString(2);
                        var email = reader.GetString(3);
                        var createDate = reader.GetDateTime(4);

                        Console.WriteLine($"Id: {id}, Name: {name}, Nick: {nickNames}, Email: {email}, Date: {createDate}");
                    }
                }
            }

        }

        private static void PrindMembers(int take)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                var command = new SqlCommand(@"
                            SELECT Id, Name, Nicknames, Email, CreateDate FROM Members
                            ORDER BY Id
                            OFFSET 5 ROWS
                            FETCH NEXT @limit ROWS ONLY",
                connection);

                var parameter = new SqlParameter
                {
                    ParameterName = "@limit",
                    Value = take,
                    SqlDbType = System.Data.SqlDbType.Int
                };

                command.Parameters.Add(parameter);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var nickNames = reader.GetString(2);
                        var email = reader.GetString(3);
                        var createDate = reader.GetDateTime(4);

                        Console.WriteLine($"Id: {id}, Name: {name}, Nick: {nickNames}, Email: {email}, Date: {createDate}");
                    }
                }
            }

        }

        private static void PrindMembers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                var command = new SqlCommand("Select top 100 * From Members", connection);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var nickNames = reader.GetString(2);
                        var email = reader.GetString(3);
                        var createDate = reader.GetDateTime(4);

                        Console.WriteLine($"Id: {id}, Name: {name}, Nick: {nickNames}, Email: {email}, Date: {createDate}");
                    }
                }
            }
        }
    }

    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
