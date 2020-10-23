﻿namespace TravelLine.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}