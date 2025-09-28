using Npgsql;

namespace OurCity.Api.Repositories;

public class PostRepository : IPostRepository
{
    private readonly string _connectionString;
    
    public PostRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private NpgsqlConnection GetConnection() => new NpgsqlConnection(_connectionString);

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        var posts = new List<Post>();
        await using var conn = GetConnection();
        await conn.OpenAsync();

        await using var cmd = new NpgsqlCommand("SELECT * FROM posts", conn);
        await using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            posts.Add(new Post
            {
                Title = reader.GetString(reader.GetOrdinal("title")),
                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal(("description")))
            });
        }

        return posts;
    }
}