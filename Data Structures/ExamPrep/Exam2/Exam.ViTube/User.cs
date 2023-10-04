using System.Collections.Generic;

namespace Exam.ViTube
{
    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public List<Video> WatchedVideos { get; set; }

        public List<Video> DislikedVideos { get; set; }

        public List<Video> LikedVideos { get; set; }

        public User(string id, string username)
        {
            Id = id;
            Username = username;
            WatchedVideos = new List<Video>();
            DislikedVideos = new List<Video>();
            LikedVideos = new List<Video>();
        }
    }
}
