using System;
using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Helper;
using LessonMonitor.Core.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LessonMonitor.DataAccess.Repositories
{
    public class TopicsRepository : ITopicsRepository
    {
        private string _connectionString;

        public TopicsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Add(Topic newTopic)
        {
            if (newTopic is null)
                throw new ArgumentNullException(nameof(newTopic));

            var newTopicEntity = new Entities.Topic
            {
                Id = newTopic.Id,
                Theme = newTopic.Theme
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    INSERT INTO Topics ( Theme, CreatedDate, UpdatedDate)
                    VALUES (@Theme, @CreatedDate, @UpdatedDate);
                    SET @Id = scope_identity();
                ", connection);

                command.Parameters.AddWithValue("@Theme", newTopicEntity.Theme);
                command.Parameters.AddWithValue("@CreatedDate", newTopicEntity.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", newTopicEntity.UpdatedDate);

                var resultParameter = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Output,
                    SqlDbType = System.Data.SqlDbType.Int,
                    ParameterName = "@Id"
                };

                command.Parameters.Add(resultParameter);

                command.ExecuteNonQuery();

                if (command.Parameters["@Id"].Value is int topicId)
                {
                    return topicId;
                }
                else
                {
                    throw new InvalidOperationException($"value id cannot be converted: {command.Parameters["@Id"].Value}");
                }
            }
        }

        public void Delete(int topicId)
        {
            if (topicId <= 0)
                throw new ArgumentException(nameof(topicId));

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    UPDATE Topics
                    SET DeletedDate = @DeletedDate
                    WHERE Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", topicId);
                command.Parameters.AddWithValue("@DeletedDate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }

        public Topic Get(int topicId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                        SELECT 
                            Id,
                            Theme
                        FROM Topics
                        WHERE DeletedDate IS NULL AND Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", topicId);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return ModelMapper.CreateOf<Topic>(reader);
                    }
                }
            }

            return null;
        }

        public Topic[] Get()
        {
            var topics = new List<Topic>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                        SELECT 
                            Id,
                            Theme
                        FROM Topics
                        WHERE DeletedDate IS NULL",
                connection);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        topics.Add(ModelMapper.CreateOf<Topic>(reader));
                    }
                }
            }

            return topics.ToArray();
        }

        public void Update(Topic topic)
        {
            if (topic is null)
                throw new ArgumentNullException(nameof(topic));

            var updatedTopicEntity = new Entities.Topic
            {
                Id = topic.Id,
                Theme = topic.Theme
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    UPDATE Topics
                    SET 
                        Theme = @Theme,
                        UpdatedDate = @UpdatedDate
                    WHERE Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", updatedTopicEntity.Id);
                command.Parameters.AddWithValue("@Theme", updatedTopicEntity.Theme);
                command.Parameters.AddWithValue("@UpdatedDate", updatedTopicEntity.UpdatedDate);

                command.ExecuteNonQuery();
            }
        }

        public void CleanTable()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
					DELETE FROM Topics 
                    WHERE Id NOT IN (SELECT TOP 2 Id FROM Topics)",
                connection);

                command.ExecuteNonQuery();
            }
        }
    }
}
