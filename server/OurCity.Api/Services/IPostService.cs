using OurCity.Api.Repositories;

namespace OurCity.Api.Services;

public interface IPostService
{
    Task<IEnumerable<Post>> GetPosts();
}