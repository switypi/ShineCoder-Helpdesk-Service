using Microsoft.EntityFrameworkCore;
using ShineCoder_Helpdesk.Core;
using Microsoft.AspNetCore.Mvc;
using ShineCoder_Helpdesk.Infrastructure;
using ShineCoder_Helpdesk.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HelpdeskDbContext>(options =>
options.UseSqlServer(
					builder.Configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly(typeof(HelpdeskDbContext).Assembly.FullName)));
builder.Services.AddScoped<HelpdeskDbContext>(provider => provider.GetService<HelpdeskDbContext>());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IResponseBuilder, ResponseBuilder>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextProxy, HttpContextProxy>();
builder.Services.AddApiVersioning(config =>
{
	config.DefaultApiVersion = new ApiVersion(1, 0);
	config.AssumeDefaultVersionWhenUnspecified = true;
});


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
