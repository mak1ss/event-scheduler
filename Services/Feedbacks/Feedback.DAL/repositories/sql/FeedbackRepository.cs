using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.repositories;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ADO_Dapper_ServiceManagment.DAL.repositories.sql
{
    public class FeedbackRepository : GenericRepository<Feedback, int>, IFeedbackRepository
    {
        private static readonly string tableName = "Feedback";
        private string connectionString;

        public FeedbackRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, tableName)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            this.connectionString = connectionString;
            connectionFactory.SetConnection(connectionString);
        }

        public IEnumerable<Feedback> GetAllFeedbacksWithLikes()
        {
            var feedbacks = new List<Feedback>();

            string query = @"
                        SELECT f.Id, f.UserId, f.Content, f.Rating, f.CreatedAt, f.UpdatedAt, f.EventId,
                               l.Id AS LikeId
                        FROM Feedback f
                        LEFT JOIN Likes l ON f.Id = l.FeedbackId
                        ORDER BY f.Id;";

            using (var dbConnection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, dbConnection))
            {
                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    Feedback currentFeedback = null;

                    while (reader.Read())
                    {
                        int feedbackId = Convert.ToInt32(reader["Id"]);

                        if (currentFeedback == null || currentFeedback.Id != feedbackId)
                        {
                            currentFeedback = new Feedback
                            {
                                Id = feedbackId,
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Content = reader["Content"].ToString(),
                                Rating = Convert.ToInt32(reader["Rating"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["UpdatedAt"]) : null,
                                EventId = Convert.ToInt32(reader["EventId"])
                            };

                            feedbacks.Add(currentFeedback);
                        }

                        if (reader["LikeId"] != DBNull.Value)
                        {
                            currentFeedback.Likes ??= new List<Like>();
                            currentFeedback.Likes.Add(new Like
                            {
                                Id = Convert.ToInt32(reader["LikeId"])
                            });
                        }
                    }
                }
            }

            return feedbacks;
        }

        public Feedback GetFeedbackWithLikes(int feedbackId)
        {
            Feedback feedback = null;

            string query = @"
                        SELECT f.Id, f.UserId, f.Content, f.Rating, f.CreatedAt, f.UpdatedAt, f.EventId,
                               l.Id AS LikeId, l.UserId AS LikedUserId, l.LikedAt
                        FROM Feedback f
                        LEFT JOIN Likes l ON f.Id = l.FeedbackId
                        WHERE f.Id = @FeedbackId
                        ORDER BY f.Id;";

            using (var dbConnection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@FeedbackId", feedbackId);
                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (feedback == null)
                        {
                            feedback = new Feedback
                            {
                                Id = feedbackId,
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Content = reader["Content"].ToString(),
                                Rating = Convert.ToInt32(reader["Rating"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["UpdatedAt"]) : null,
                                EventId = Convert.ToInt32(reader["EventId"]),
                                Likes = new List<Like>()
                            };
                        }

                        if (reader["LikeId"] != DBNull.Value)
                        {
                            feedback.Likes.Add(new Like
                            {
                                Id = Convert.ToInt32(reader["LikeId"]),
                                FeedbackId = feedback.Id,
                                UserId = Convert.ToInt32(reader["LikedUserId"]),
                                LikedAt = reader["LikedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["LikedAt"]) : null
                            });
                        }
                    }
                }
            }

            return feedback;
        }

    }
}
