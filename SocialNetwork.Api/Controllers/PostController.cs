using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SocialNetwork.Application.Users.Commands;
using SocialNetwork.Application.Users.Queries;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Api.Controllers;

public class PostController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetOne([FromQuery] PostDetailsQuery query) => Ok(await Mediator.Send(query));
    
    [HttpPost]
    public async Task<IActionResult> Create(PostCreateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete]
    public async Task<string> Delete(string id)
    {
        await DB.DeleteAsync<Post>(id);
        return "Ok!";
    }
}