using Infrastructure;
using Infrastructure.Queries;
using Infrastructure.Repository;
using InventoryManagerAPI.Application.Commands;
using InventoryManagerAPI.Application.Interfaces;
using InventoryManagerAPI.Application.Services;
using InventoryManagerAPI.Domain.Interfaces;
using InventoryManagerAPI.Host.Handlers;
using InventoryManagerAPI.Infrastructure.Queries;
using InventoryManagerAPI.Infrastructure.Seeder;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiDbContext>(options => options
	.UseInMemoryDatabase(nameof(ApiDbContext)));

builder.Services.AddTransient<DataSeeder>();

// Add services to the container.
builder.Services.AddScoped(typeof(IGetItemByName), typeof(GetItemByName));
builder.Services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IUserQueries), typeof(IdentifyUser));
builder.Services.AddScoped(typeof(IGetItems), typeof(GetItems));
builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Inventory Manager",
		Description = "An inventory manager for items",
	});

	options.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
	{
		Description = "Basic Auth",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Scheme = "basic",
		Type = SecuritySchemeType.Http
	});

	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Basic" }
			},
			new List<string>()
		}
	});
	// using System.Reflection;
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(typeof(CreateItemCommandHandler));
builder.Services.AddMediatR(typeof(DeleteItemCommandHandler));
builder.Services.AddMediatR(typeof(GetItemsCommandHandler));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddAuthorization();
var app = builder.Build();

SeedData(app);

//Seed Data
void SeedData(IHost app)
{
	var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

	using (var scope = scopedFactory.CreateScope())
	{
		var service = scope.ServiceProvider.GetService<DataSeeder>();
		service.Seed();
	}
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
