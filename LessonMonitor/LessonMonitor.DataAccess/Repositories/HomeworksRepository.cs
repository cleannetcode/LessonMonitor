using LessonMonitor.Core.Models;
using LessonMonitor.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LessonMonitor.DataAccess.Repositories
{
    public class HomeworksRepository : IHomeworksRepository
    {
        private string _connectionString;
        public HomeworksRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

		public int Add(Homework newHomework)
		{
			if (newHomework is null)
				throw new ArgumentNullException(nameof(newHomework));

			var newHomeworkEntity = new Entities.Homework
			{
				 
				//Title = newHomework.Title,
				//Description = newHomework.Description,
				//Link = newHomework.Link
			};

			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@"
					INSERT INTO Homeworks (Title, [Description], Link, CreatedDate, UpdatedDate)
					VALUES (@Title, @Description, @Link, @CreatedDate, @UpdatedDate );
					SET @Id = scope_identity();",
				connection);

				//command.Parameters.AddWithValue("@Title", newHomeworkEntity.Title);
				//command.Parameters.AddWithValue("@Description", newHomeworkEntity.Description);
				//command.Parameters.AddWithValue("@Link", newHomeworkEntity.Link);
				//command.Parameters.AddWithValue("@CreatedDate", newHomeworkEntity.CreatedDate);
				//command.Parameters.AddWithValue("@UpdatedDate", newHomeworkEntity.UpdatedDate);

				var resultParameter = new SqlParameter
				{
					Direction = System.Data.ParameterDirection.Output,
					SqlDbType = System.Data.SqlDbType.Int,
					ParameterName = "@Id"
				};
				command.Parameters.Add(resultParameter);

				command.ExecuteNonQuery();

				if (command.Parameters["@Id"].Value is int homeworkId)
				{
					return homeworkId;
				}
				else
				{
					throw new InvalidOperationException($"value id cannot be converted: {command.Parameters["@Id"].Value}");
				}
			}
		}

		public void Delete(int homeworkId)
		{
			if (homeworkId < 0)
				throw new ArgumentException(nameof(homeworkId));

			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@"
					UPDATE Homeworks
					SET DeletedDate = @DeletedDate
					WHERE Id = @Id",
				connection);

				command.Parameters.AddWithValue("@Id", homeworkId);
				command.Parameters.AddWithValue("@DeletedDate", DateTime.Now);

				command.ExecuteNonQuery();
			}
		}

		public Homework[] Get()
		{
			var homeworks = new List<Homework>();

			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@"
						SELECT 
							Id,
							Title,
							[Description],
							Link  
						FROM Homeworks
						WHERE DeletedDate IS NULL",
				connection);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						homeworks.Add(new Homework
						{
							//Id = reader.GetInt32(0),
							//Title = reader.GetString(1),
							//Description = reader.GetString(2),
							//Link = reader.GetString(3)
						});
					}
				}
			}

			return homeworks.ToArray();
		}

		public Homework Get(int homeworkId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@"
						SELECT 
							Id,
							Title,
							[Description],
							Link  
						FROM Homeworks
						WHERE DeletedDate IS NULL AND Id = @Id",
				connection);

				command.Parameters.AddWithValue("@Id", homeworkId);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var homework = new Homework
						{
							//Id = reader.GetInt32(0),
							//Title = reader.GetString(1),
							//Description = reader.GetString(2),
							//Link = reader.GetString(3)
						};

						return homework;
					}
				}
			}

			return null;
		}

		public void Update(Homework homework)
		{
			if (homework is null)
				throw new ArgumentNullException(nameof(homework));

			var updatedHomeworkEntity = new Entities.Homework
			{
				//Id = homework.Id,
				//Title = homework.Title,
				//Description = homework.Description,
				//Link = homework.Link
			};

			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@"
					UPDATE Homeworks
					SET 
						Title = @Title, 
						[Description] = @Description, 
						Link = @Link,
						UpdatedDate = @UpdatedDate
					WHERE Id = @Id",
				connection);

				//command.Parameters.AddWithValue("@Id", updatedHomeworkEntity.Id);
				//command.Parameters.AddWithValue("@Title", updatedHomeworkEntity.Title);
				//command.Parameters.AddWithValue("@Description", updatedHomeworkEntity.Description);
				//command.Parameters.AddWithValue("@Link", updatedHomeworkEntity.Link);
				//command.Parameters.AddWithValue("@UpdatedDate", updatedHomeworkEntity.UpdatedDate);

				command.ExecuteNonQuery();
			}
		}

		public void CleanTable()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var command = new SqlCommand(@"
					DELETE FROM Homeworks",
				connection);

				command.ExecuteNonQuery();
			}
		}
	}
}
