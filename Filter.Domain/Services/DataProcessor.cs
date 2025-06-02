using Filter.Domain.Models;

namespace Filter.Domain.Services
{
    public class DataProcessor : IDataProcessor
    {
        public IEnumerable<UserPostSummary> FilterUsersWithPosts(IEnumerable<User> users, IEnumerable<Post> posts, string cityStartsWith)
        {
            return users
                .Where(u => u.Address.City.StartsWith(cityStartsWith, StringComparison.OrdinalIgnoreCase))
                .Select(u => new UserPostSummary(
                    u.Name,
                    u.Address.City,
                    posts.Count(p => p.UserId == u.Id)));
        }
    }
}
