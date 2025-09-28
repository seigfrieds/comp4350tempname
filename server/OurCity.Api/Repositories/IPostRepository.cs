namespace OurCity.Api.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllPosts();
}