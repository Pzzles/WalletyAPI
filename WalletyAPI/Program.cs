using Microsoft.EntityFrameworkCore;
using WalletyAPI.Data;
using WalletyAPI.Repositories.Interfaces;
using WalletyAPI.Repositories.Impl_Classes;
using WalletyAPI.Services.Service_Interfaces;
using WalletyAPI.Services.Service_Impl_Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr")));

// Register repositories and services
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository_Impl<>));
builder.Services.AddScoped<IUserService, User_Service>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
