using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Video> videos = new Dictionary<string, Video>();

        public bool Contains(User user)
        {
            return users.ContainsKey(user.Id);
        }

        public bool Contains(Video video)
        {
            return videos.ContainsKey(video.Id);
        }

        public void DislikeVideo(User user, Video video)
        {
            if (!videos.ContainsKey(video.Id) || !users.ContainsKey(user.Id))
            {
                throw new ArgumentException();
            }

            videos[video.Id].Dislikes += 1;
            users[user.Id].DislikedVideos.Add(video);
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            return users
                .Select(u => u.Value)
                .Where(u => u.WatchedVideos.Count == 0 && u.LikedVideos.Count == 0 && u.DislikedVideos.Count == 0);
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            return users
                .Select(u => u.Value)
                .OrderByDescending(u => u.WatchedVideos.Count)
                .ThenByDescending(u => u.LikedVideos.Count + u.DislikedVideos.Count)
                .ThenBy(u => u.Username);
        }

        public IEnumerable<Video> GetVideos()
        {
            return videos.Values;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            return videos
                .Select(v => v.Value)
                .OrderByDescending(v => v.Views)
                .ThenByDescending(v => v.Likes)
                .ThenBy(v => v.Dislikes);
        }

        public void LikeVideo(User user, Video video)
        {
            if (!videos.ContainsKey(video.Id) || !users.ContainsKey(user.Id))
            {
                throw new ArgumentException();
            }

            videos[video.Id].Likes += 1;
            users[user.Id].LikedVideos.Add(video);
        }

        public void PostVideo(Video video)
        {
            videos.Add(video.Id, video);
        }

        public void RegisterUser(User user)
        {
            users.Add(user.Id, user);
        }

        public void WatchVideo(User user, Video video)
        {
            if (!videos.ContainsKey(video.Id) || !users.ContainsKey(user.Id))
            {
                throw new ArgumentException();
            }

            videos[video.Id].Views += 1;
            users[user.Id].WatchedVideos.Add(video);
        }
    }
}
