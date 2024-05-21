using Presentation.Dependency.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Needed for IHttpClientFactory registered type
builder.Services.AddHttpClient();

// DEMO FUNCTIONS START HERE
{
    // Standard approach
    builder.Services.StandardRegistration();

    // Register all the things with scrutor
    //builder.Services.RegisterWithScrutor();
}

builder.Services.RegisterOtherThings();
builder.Services.RegisterConcreteClasses();
builder.Services.BrokenRegistrations();

var app = builder.Build();

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
