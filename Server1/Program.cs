using Microsoft.EntityFrameworkCore;
using Server1;
using Server1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
	options.UseSqlServer("Server=localhost;Database=ChatService;Trusted_Connection=True;TrustServerCertificate=True;User=root;password=root");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHub<ChatHub>("/Chat"); // Faz com que o hub seja acessível em /Chat

app.UseAuthorization();

app.MapControllers();

app.Run();