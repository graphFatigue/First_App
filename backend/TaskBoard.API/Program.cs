using TaskBoard.API.Extensions;
using TaskBoard.Application.Extensions;
using TaskBoard.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePostgresSqlContext(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureBusinessLayerServices();
builder.Services.ConfigureDataAccessLayer();

builder.Services.ConfigureFluentValidation();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

//app.UseHttpsRedirection();

app.UseExceptionHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//await app.MigrateDatabase();

app.Run();
