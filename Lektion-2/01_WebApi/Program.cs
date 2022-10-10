var builder = WebApplication.CreateBuilder(args);

// Services (Databaser, Serviceklasser, Helpers)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware - Swagger (API documentation)
app.UseSwagger();
app.UseSwaggerUI();

// Middleware - CORS
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Middleware - SSL
app.UseHttpsRedirection();

// Middleware - Vad får du göra? (role)
app.UseAuthorization();

// Middleware - Mappar upp alla endpoints
app.MapControllers();

app.Run();
