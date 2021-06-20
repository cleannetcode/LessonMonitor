using System;
using System.Data.SqlClient;
using System.Text;

namespace AdoNET
{
	internal class Program
	{
		private const string connectionString = "Server=localhost;Database=LessonMonitorDb;Integrated Security=true;";

		private static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			CreateLesson(new Lesson
			{
				Title = "Подключаемся к mssql",
				Description = "Подключаемся к mssql с помощью ado.net",
				StartDate = new DateTime(2021, 06, 20, 18, 00, 00),
				CreatedDate = DateTime.Now
			});
			//PrintMembersLike("-1; DROP DATABASE LessonMonitor");
			//PrintMembers(20);

			Console.WriteLine("Press any key");
			Console.ReadKey();
		}

		private static void CreateLesson(Lesson lesson)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@"
					INSERT INTO Lessons (Title, [Description], StartDate, CreatedDate)
					VALUES (@Title, @Description, @StartDate, @CreatedDate);
					SET @LessonId = scope_identity();",
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

		private static void PrintMembersLike(string searchName)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@$"
						SELECT Id, Name, CreatedDate FROM Members
						WHERE Name LIKE @name",
				connection);

				var parameter = new SqlParameter
				{
					ParameterName = "@name",
					Value = searchName,
					SqlDbType = System.Data.SqlDbType.NVarChar
				};

				command.Parameters.Add(parameter);
				//command.Parameters.AddWithValue("@limit", take);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var id = reader.GetInt32(0);
						var name = reader.GetString(1);
						var createdDate = reader.GetDateTime(2);

						Console.WriteLine($"id: {id}, name: {name}, createdDate: {createdDate}");
					}
				}
			}
		}

		private static void PrintMembers(int take)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@$"
						SELECT Id, Name, CreatedDate FROM Members
						ORDER BY Id
						OFFSET 0 ROWS
						FETCH NEXT @limit ROWS ONLY; ",
				connection);

				var parameter = new SqlParameter
				{
					ParameterName = "@limit",
					Value = take,
					SqlDbType = System.Data.SqlDbType.Int
				};

				command.Parameters.Add(parameter);
				//command.Parameters.AddWithValue("@limit", take);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var id = reader.GetInt32(0);
						var name = reader.GetString(1);
						var createdDate = reader.GetDateTime(2);

						Console.WriteLine($"id: {id}, name: {name}, createdDate: {createdDate}");
					}
				}
			}
		}

		private static void PrintMembers()
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var command = new SqlCommand("SELECT TOP 100 * FROM Members", connection);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var id = reader.GetInt32(0);
						var name = reader.GetString(1);
						var createdDate = reader.GetDateTime(2);

						Console.WriteLine($"id: {id}, name: {name}, createdDate: {createdDate}");
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
