﻿
namespace ADO_Dapper_ServiceManagment.DAL.dtos.like
{
    public class LikeResponse
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
