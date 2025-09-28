using System.ComponentModel.DataAnnotations;

namespace OurCity.Api.Repositories;

public class Post
{
    [Required]
    public string Title { get; set; }
    
    public string? Description { get; set; }
}