using Filter.Domain.Models;

namespace Filter.Infrastructure.Api
{
    public interface IApiClient
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<Post>> GetPostsAsync();
    }
}
