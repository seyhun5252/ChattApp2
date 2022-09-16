using Business.Abstarct;
using Business.Concrete;
using Business.Validation.FluentValidation;
using DataLayer;
using DataLayer.Entity;
using FluentValidation;
using NuGet.Protocol.Core.Types;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ChatAppContext>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<DalUser>();

builder.Services.AddScoped<IComplainService, ComplainManager>();
builder.Services.AddScoped<DalComplain>();

builder.Services.AddScoped<IFriendService, FriendManager>();
builder.Services.AddScoped<DalFriend>();

builder.Services.AddScoped<IGroupService, GroupManager>();
builder.Services.AddScoped<DalGroup>();

builder.Services.AddScoped<IGroupMemberService, GroupMemberManager>();
builder.Services.AddScoped<DalGroupMember>();

builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<DalMessage>();


//builder.Services.AddScoped</*IValidator*/<User>, UserValidator>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAllowAll",
        builder =>
        {
            builder.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin => true);
        }
        );
});


var app = builder.Build();
app.UseCors("CorsAllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
