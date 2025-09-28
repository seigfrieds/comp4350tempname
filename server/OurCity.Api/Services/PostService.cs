using OurCity.Api.Repositories;

namespace OurCity.Api.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    
    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        var posts = await _postRepository.GetAllPosts();
        
        return posts.ToList();
    }
}