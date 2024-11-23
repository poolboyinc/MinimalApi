using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Users.Commands;
using SocialNetwork.Application.Users.Queries;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Api.Controllers;


public class UserController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] UsersAllDetailsQuery query) => Ok(await Mediator.Send(query));
    
    [HttpGet]
    public async Task<IActionResult> GetOne([FromQuery] UserDetailsQuery query) => Ok(await Mediator.Send(query));

    [HttpGet]
    public async Task<IActionResult> GetUserPosts([FromQuery] UserPostsDetails query) => Ok(await Mediator.Send(query));
    
    [HttpPost]
    public async Task<IActionResult> Create(UserCreateCommand command) => Ok(await Mediator.Send(command));

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand command) => Ok(await Mediator.Send(command));
    

    [HttpPut]
    public async Task Update(UserUpdateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete]
    public async Task<string> Delete(string id)
    {
        await DB.DeleteAsync<User>(id);
        return "Ok!";
    }
}