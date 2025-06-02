using Filter.Domain.Models;

namespace Filter.Domain.Services
{
    public interface IDataProcessor
    {
        IEnumerable<UserPostSummary> FilterUsersWithPosts(IEnumerable<User> users, IEnumerable<Post> posts, string cityStartsWith);
    }
}
