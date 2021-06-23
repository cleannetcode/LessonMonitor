using System;
using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Helper;
using LessonMonitor.Core.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LessonMonitor.DataAccess.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private string _connectionString;

        public QuestionsRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public int Add(Question newQuestion)
        {
            if (newQuestion is null)
                throw new ArgumentNullException(nameof(newQuestion));

            var newQuestionEntity = new Entities.Question
            {
                UserId = newQuestion.User.Id,
                Description = newQuestion.Description
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    INSERT INTO Questions (UserId, Description, CreatedDate, UpdatedDate)
                    VALUES (@UserId, @Description, @CreatedDate, @UpdatedDate);
                    SET @Id = scope_identity();",
                connection);

                command.Parameters.AddWithValue("@UserId", newQuestionEntity.UserId);
                command.Parameters.AddWithValue("@Description", newQuestionEntity.Description);
                command.Parameters.AddWithValue("@CreatedDate", newQuestionEntity.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", newQuestionEntity.UpdatedDate);

                var resultParameter = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Output,
                    SqlDbType = System.Data.SqlDbType.Int,
                    ParameterName = "@Id"
                };

                command.Parameters.Add(resultParameter);

                command.ExecuteNonQuery();

                if (command.Parameters["@Id"].Value is int questionId)
                {
                    return questionId;
                }
                else
                {
                    throw new InvalidOperationException($"value id cannot be converted: {command.Parameters["@Id"].Value}");
                }
            }
        }

        public void Delete(int questionId)
        {
            if (questionId <= 0)
                throw new ArgumentException(nameof(questionId));

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    UPDATE Questions
                    SET DeletedDate = @DeletedDate
                    WHERE Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", questionId);
                command.Parameters.AddWithValue("@DeletedDate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }

        public Question Get(int questionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                        SELECT 
                        q.Id,
                        q.Description,
                        u.Id as ""User.Id"",
                        u.Name as ""User.Name"",
                        u.Nicknames as ""User.Nicknames"",
                        u.Email as ""User.Email""
                        FROM Questions q
                        INNER JOIN Users u on q.UserId = u.Id
                        WHERE q.DeletedDate IS NULL AND q.Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", questionId);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return ModelMapper.CreateOf<Question>(reader);
                    }
                }
            }

            return null;
        }

        public Question[] Get()
        {
            var questions = new List<Question>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                        SELECT 
                        q.Id,
                        q.Description,
                        u.Id as ""User.Id"",
                        u.Name as ""User.Name"",
                        u.Nicknames as ""User.Nicknames"",
                        u.Email as ""User.Email""
                        FROM Questions q
                        INNER JOIN Users u on q.UserId = u.Id
                        WHERE q.DeletedDate IS NULL",
                connection);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        questions.Add(ModelMapper.CreateOf<Question>(reader));
                    }
                }
            }

            return questions.ToArray();
        }

        public void Update(Question question)
        {
            if (question is null)
                throw new ArgumentNullException(nameof(question));

            var updatedQuestionEntity = new Entities.Question
            {
                Id = question.Id,
                UserId = question.User.Id,
                Description  = question.Description
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    UPDATE Questions
                    SET 
                        UserId = @UserId,
                        Description = @Description, 
                        UpdatedDate = @UpdatedDate
                    WHERE Id = @Id",
                connection);

                command.Parameters.AddWithValue("@Id", updatedQuestionEntity.Id);
                command.Parameters.AddWithValue("@UserId", updatedQuestionEntity.UserId);
                command.Parameters.AddWithValue("@Description", updatedQuestionEntity.Description);
                command.Parameters.AddWithValue("@UpdatedDate", updatedQuestionEntity.UpdatedDate);

                command.ExecuteNonQuery();
            }
        }

        public void CleanTable()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
                    DELETE FROM Questions
                    WHERE Id NOT IN (SELECT TOP 8 Id FROM Questions)",
                connection);

                command.ExecuteNonQuery();
            }
        }
    }
}
