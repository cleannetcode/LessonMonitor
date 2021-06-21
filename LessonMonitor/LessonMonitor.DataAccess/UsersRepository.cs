using LessonMonitor.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace LessonMonitor.DataAccess
{
	public class UsersRepository : IUsersRepository
	{
		private readonly string _connection;

		public UsersRepository(string connection)
		{
			_connection = connection;
		}

		public Core.User[] Get()
		{
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();

				var command = new SqlCommand(@"
					SELECT Name, Age FROM Members
				",connection);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					var result = new List<Core.User>();
					while (reader.Read())
					{
						result.Add(new Core.User()
						{
							Name = reader.GetString(0),
							Age = reader.GetInt32(1)
						});
					}
					return result.ToArray();
				}
			}

			return null;
		}

		public Core.User Get(int userId)
		{
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();

				var command = new SqlCommand(@"
					SELECT Name, Age, Id FROM Members
					WHERE Id = @id AND DeletedDate is NULL
				",connection);

				command.Parameters.AddWithValue("@Id", userId);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					reader.Read();
					return new Core.User()
					{
						Name = reader.GetString(0),
						Age = reader.GetInt32(1),
						Id = reader.GetInt32(2)
					};
				}
			}

			return null;
		}

		public void Update(User user)
		{
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();

				var newUser = new DataAccess.Entities.User()
				{
					Name = user.Name,
					Age = user.Age,
					Id = user.Id
				};
				var command = new SqlCommand(@"
					UPDATE Members
					SET UpdatedDate = GETDATE(),
					    Name = @name,
					    Age = @Age
					WHERE Id = @Id
				",connection);

				command.Parameters.AddWithValue("@Id", newUser.Id);
				command.Parameters.AddWithValue("@Age", newUser.Age);
				command.Parameters.AddWithValue("@Name", newUser.Name);
				command.ExecuteNonQuery();
			}
		}

		public void Delete(int userId)
		{
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();

				var command = new SqlCommand(@"
					UPDATE Members
					SET DeletedDate = GETDATE()
					WHERE Id = @Id
				",connection);

				command.Parameters.AddWithValue("@Id", userId);
				command.ExecuteNonQuery();
			}
		}

		public int Create(Core.User user)
		{
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();

				var command = new SqlCommand(@"
					INSERT INTO Members (Name, Age, CreatedDate,UpdatedDate)
					VALUES (@name, @age, GETDATE(),GETDATE());
					SET @Id = scope_identity();
				", connection);

				var newUser = new DataAccess.Entities.User()
				{
					Name = user.Name,
					Age = user.Age,
				};
				command.Parameters.AddWithValue("@name", newUser.Name);
				command.Parameters.AddWithValue("@age", newUser.Age);

				command.Parameters.Add(new SqlParameter
				{
					Direction = System.Data.ParameterDirection.Output,
					SqlDbType = System.Data.SqlDbType.Int,
					ParameterName = "@Id"
				});

				command.ExecuteNonQuery();

				if (command.Parameters["@Id"].Value is int userId)
				{
					return userId;
				}
				else
				{
					throw new InvalidOperationException("couldn't get id parameter");
				}
			}
		}
		
		public void CleanTable()
		{
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();

				var command = new SqlCommand(@"
					DELETE FROM Members",
					connection);

				command.ExecuteNonQuery();
			}
		}
	}
}
