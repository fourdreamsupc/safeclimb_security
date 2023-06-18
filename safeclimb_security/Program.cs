using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using safeclimb_security.Security.Mapping;
using safeclimb_security.Security.Security.Authorization.Handlers.Implementations;
using safeclimb_security.Security.Security.Authorization.Handlers.Interfaces;
using safeclimb_security.Security.Security.Authorization.Middleware;
using safeclimb_security.Security.Security.Authorization.Settings;
using safeclimb_security.Security.Security.Services;
using safeclimb_security.Security.Shared.Domain.Repositories;
using safeclimb_security.Security.Shared.Domain.Services;
using safeclimb_security.Security.Shared.Persistence.Contexts;
using safeclimb_security.Security.Shared.Persistence.Repositories;
using safeclimb_security.Security.Subscriptions.Domain.Repositories;
using safeclimb_security.Security.Subscriptions.Domain.Services;
using safeclimb_security.Security.Subscriptions.Persistence.Repositories;
using safeclimb_security.Security.Subscriptions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add CORS service
builder.Services.AddCors();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSwaggerGen(options => 
{
    // Add API Documentation Information
        
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Mecanillama API",
        Description = "Mecanillama RESTful API",
        TermsOfService = new Uri("https://mecanillama.github.io/Landing-Page/"),
        Contact = new OpenApiContact
        {
            Name = "Mecanillama.studio",
            Url = new Uri("https://mecanillama.github.io/Landing-Page/")
        },
        License = new OpenApiLicense
        {
            Name = "Mecanillama Resources License",
            Url = new Uri("https://mecanillama.github.io/Landing-Page/")
        }
    });
    options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

builder.Services.AddRouting(options => 
    options.LowercaseUrls = true);

builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure Error Handler Middleware

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling Middleware

app.UseMiddleware<JwtMiddleware>();


// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();