using BackendTaskStage1.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Intern Info",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// API Endpoint
app.MapGet("/interninfo", () =>
{
    var response = new UserDto
    {
        SlackUserName = "Tsadhoq",
        Backend = true,
        Age = 22,
        Bio = "A fourth-year mechanical engineering student from the Federal University of Technology Minna"
    };

    return response; 
});

app.Run();
