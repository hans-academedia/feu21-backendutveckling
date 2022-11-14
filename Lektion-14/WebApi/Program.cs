using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using WebApi.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddCors(x =>
{
    x.AddPolicy("react", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:3001", "https://feu21.azurewebsites.net", "http://127.0.0.1:5500");
        policy.WithMethods("POST", "GET", "PUT");
        policy.WithHeaders(HeaderNames.ContentType);
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
//app.UseCors("react");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
