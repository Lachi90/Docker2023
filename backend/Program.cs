using ExampleBackend.Database;
using ExampleBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExampleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExampleDatabase"));
});

builder.Services.AddTransient<IBookService, BookService>();

const string corsPolicy = nameof(corsPolicy);
builder.Services.AddCors(o => o.AddPolicy(corsPolicy, b =>
{
    b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<ExampleContext>();
await dbContext.Database.MigrateAsync();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();