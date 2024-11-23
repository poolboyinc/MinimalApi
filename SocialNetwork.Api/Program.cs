using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using SocialNetwork.Api.Config;
using SocialNetwork.Application;
using SocialNetwork.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();  
builder.Services.AddInfrastructure();  

var corsConfiguration = new CorsConfiguration();
builder.Configuration
    .GetSection("CorsConfiguration")
    .Bind(corsConfiguration);

builder.Services.AddCors(options => options.AddPolicy("AllowOrigins",
    x => x.WithMethods("GET",
            "POST",
            "PATCH",
            "DELETE",
            "OPTIONS",
            "PUT")
        .WithHeaders(HeaderNames.Accept,
            HeaderNames.ContentType,
            HeaderNames.Authorization,
            HeaderNames.XRequestedWith,
            "x-signalr-user-agent")
        .AllowCredentials()
        .WithOrigins(corsConfiguration.AllowedOrigins!)));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();