using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LessonMonitor.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(User newUser)
        {
            if (newUser is null)
                throw new ArgumentNullException(nameof(newUser));

            var newUserEntity = new Entities.User
            {
                Name = newUser.Name,
                Nicknames = newUser.Nicknames,
                Email = newUser.Email
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    INSERT INTO Users (Name, Nicknames, Email, CreatedDate, UpdatedDate)
                    VALUES (@Name, @Nicknames, @Email, @CreatedDate, @UpdatedDate);
                    SET @Id = scope_identity();",
                connection);

                command.Parameters.AddWithValue("@Name", newUserEntity.Name);
                command.Parameters.AddWithValue("@Nicknames", newUserEntity.Nicknames);
                command.Parameters.AddWithValue("@Email", newUserEntity.Email);
                command.Parameters.AddWithValue("@CreatedDate", newUserEntity.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", newUserEntity.UpdatedDate);

                var resultParameter = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Output,
                    SqlDbType = System.Data.SqlDbType.Int,
                    ParameterName = "@Id"
                };

                command.Parameters.Add(resultParameter);

                command.ExecuteNonQuery();

                if (command.Parameters["@Id"].Value is int userId)
                {
                    return userId;
                }
                else
                {
                    throw new InvalidOperationException($"value id cannot be converted: {command.Parameters["@Id"].Value}");
                }
            }
        }

        public void Delete(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException(nameof(userId));

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    UPDATE Users
                    SET DeletedDate = @DeletedDate
                    WHERE Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", userId);
                command.Parameters.AddWithValue("@DeletedDate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }

        public User Get(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                        SELECT 
                            Id,
                            Name,
                            Nicknames,
                            Email
                        FROM Users
                        WHERE DeletedDate IS NULL AND Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", userId);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new Core.CoreModels.User
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Nicknames = reader.GetString(2),
                            Email = reader.GetString(3)
                        };

                        return user;
                    }
                }
            }

            return null;
        }

        public User[] Get()
        {
            var users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                        SELECT 
                            Id,
                            Name,
                            Nicknames,
                            Email
                        FROM Users
                        WHERE DeletedDate IS NULL",
                connection);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new Core.CoreModels.User
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Nicknames = reader.GetString(2),
                            Email = reader.GetString(3)
                        });
                    }
                }
            }

            return users.ToArray();
        }

        public void Update(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var updatedUserEntity = new Entities.User
            {
                Id = user.Id,
                Name = user.Name,
                Nicknames = user.Nicknames,
                Email = user.Email
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    UPDATE Users
                    SET 
                        Name = @Name,
                        Nicknames = @Nicknames,
                        Email = @Email,
                        UpdatedDate = @UpdatedDate
                    WHERE Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", updatedUserEntity.Id);
                command.Parameters.AddWithValue("@Name", updatedUserEntity.Name);
                command.Parameters.AddWithValue("@Nicknames", updatedUserEntity.Nicknames);
                command.Parameters.AddWithValue("@Email", updatedUserEntity.Email);
                command.Parameters.AddWithValue("@UpdatedDate", updatedUserEntity.UpdatedDate);

                command.ExecuteNonQuery();
            }
        }
        public void CleanTable()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
					DELETE FROM Users 
                    WHERE Id NOT IN (SELECT TOP 10 Id FROM Users)",
                connection);

                command.ExecuteNonQuery();
            }
        }
    }
}
