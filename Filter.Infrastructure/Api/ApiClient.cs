using Filter.Domain.Models;
using System.Net.Http.Json;

namespace Filter.Infrastructure.Api
{
    public class ApiClient(HttpClient client) : IApiClient
    {
        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await client.GetFromJsonAsync<IEnumerable<User>>("users")
                ?? throw new HttpRequestException("Unable to fetch users.");

        public async Task<IEnumerable<Post>> GetPostsAsync() =>
            await client.GetFromJsonAsync<IEnumerable<Post>>("posts")
                ?? throw new HttpRequestException("Unable to fetch posts.");
    }
}
