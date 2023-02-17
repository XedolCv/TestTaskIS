using Microsoft.EntityFrameworkCore;
using TestTaskIS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectString = builder.Configuration.GetConnectionString("ApiAppCon");
builder.Services.AddDbContext<MyContext>(op => op.UseNpgsql(connectString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
app.UseRouting();
app.UseWhen(context => context.Request.Path.StartsWithSegments("/event") || context.Request.Path.StartsWithSegments("/device"), appBuilder => { appBuilder.UseMiddleware<MyMiddleware>(); });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
