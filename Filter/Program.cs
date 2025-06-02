using Filter;
using Filter.Domain.Services;
using Filter.Infrastructure.Api;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddHttpClient<IApiClient, ApiClient>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

services.AddScoped<IDataProcessor, DataProcessor>();

var provider = services.BuildServiceProvider();

var apiClient = provider.GetRequiredService<IApiClient>();
var dataProcessor = provider.GetRequiredService<IDataProcessor>();

Console.Write(Messages.EnterCity);
var cityStart = Console.ReadLine()?.Trim() ?? "";

var users = await apiClient.GetUsersAsync();
var posts = await apiClient.GetPostsAsync();

var summaries = dataProcessor.FilterUsersWithPosts(users, posts, cityStart);

foreach (var summary in summaries)
{
    Console.WriteLine($"{Messages.Name} {summary.Name}");
    Console.WriteLine($"{Messages.City} {summary.City}");
    Console.WriteLine($"{Messages.PostsCount} {summary.PostsCount}");
    Console.WriteLine(new string('-', 20));
}
