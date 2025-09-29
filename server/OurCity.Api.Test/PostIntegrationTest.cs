using Npgsql;
using OurCity.Api.Repositories;
using OurCity.Api.Services;
using Testcontainers.PostgreSql;

namespace OurCity.Api.Test;

public class PostIntegrationTest : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres =
        new PostgreSqlBuilder()
            .WithImage("postgres:16.10")
            .Build();

    public async Task InitializeAsync()
    {
        await _postgres.StartAsync();
        
        //TODO: probably remove once i set migrations in place..
        await using var connection = new NpgsqlConnection(_postgres.GetConnectionString());
        await connection.OpenAsync();
        var createPostsTable = "CREATE TABLE posts (title TEXT PRIMARY KEY, description TEXT);";
        await using var cmd = new NpgsqlCommand(createPostsTable, connection);
        await cmd.ExecuteNonQueryAsync();
    }

    public Task DisposeAsync()
    {
        return _postgres.DisposeAsync().AsTask();
    }

    [Fact]
    public async Task FreshDbShouldReturnNothing()
    {
        var postService = new PostService(new PostRepository(_postgres.GetConnectionString()));
        var posts = await postService.GetPosts();
        Assert.Empty(posts);
    }
}