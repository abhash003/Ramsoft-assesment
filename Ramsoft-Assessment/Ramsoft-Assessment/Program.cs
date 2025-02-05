
using Ramsoft_Assessment.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container (DI container)
builder.Services.AddSingleton<TaskService>(); // Register TaskService for DI

// Add controllers to the services container
builder.Services.AddControllers();

// Add Swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // This adds Swagger generation to the project

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
