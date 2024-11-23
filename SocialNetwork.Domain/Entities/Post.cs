using MongoDB.Entities;

namespace SocialNetwork.Domain.Entities;

public class Post : Entity
{
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastModified { get; set; }
    
    public User UserEmbeded { get; set; }
    public One<User> Owner { get; set; }
}