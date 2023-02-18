using Microsoft.EntityFrameworkCore;
using TestTaskIS.Services;
using Newtonsoft.Json;
using System.Reflection;
using Swashbuckle.AspNetCore.Newtonsoft;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.Converters.Add(new StringEnumConverter
    {
        CamelCaseText = true
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
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
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/event") || context.Request.Path.StartsWithSegments("/api/device"), appBuilder => { appBuilder.UseMiddleware<MyMiddleware>(); });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
