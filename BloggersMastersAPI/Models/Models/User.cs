﻿namespace BloggersMastersAPI.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
