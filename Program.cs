using Microsoft.EntityFrameworkCore;
using PWDManager_BE.Data;

var myCors = "MyCors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// DataBase Context
builder.Services.AddDbContext<DataContext>(
    options => options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("PasswordManager"))
);

// CORS
builder.Services.AddCors(policy => {
    policy.AddPolicy(
        name: myCors,
        builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*")
    );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
