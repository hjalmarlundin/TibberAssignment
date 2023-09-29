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
builder.Services.AddTransient<IDatabase, Database>();


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





