using Cleaner.Application;
using Cleaner.Repository;
using Swashbuckle.AspNetCore.Filters;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
});
builder.Services.AddControllers();
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
builder.Services.AddTransient<IPathRequestHandler, PathRequestHandler>();

var connectionString = builder.Configuration.GetConnectionString("DbContext") ?? throw new Exception("Could not find database configuration");
builder.Services.AddSingleton<IDatabase, Database>(x => new Database(connectionString));
Console.WriteLine($"Using connection: {connectionString}");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();





