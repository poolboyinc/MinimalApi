using MongoDB.Entities;
using SocialNetwork.Domain.EntityServices;

namespace SocialNetwork.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password{ get; set; }
    public Many<Post, User> Posts { get; set; }
    
    public User()
    {
        this.InitOneToMany(() => Posts);
    }
    
}