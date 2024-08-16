using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using payment_service_provider.Data;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Domain.Fees;
using payment_service_provider.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Dependency injection instances
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IPayableService, PayableService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IPayableRepository, PayableRepository>();
builder.Services.AddScoped<IComputeFee, ComputeFee>();

// Connection to the database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Add AutoMapper configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// CORS configuration
var AllowSpecOrigins = "AllowSpecOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
              .WithMethods("GET", "POST")
              .WithHeaders(HeaderNames.ContentType, "Access-Control-Allow-Headers");
    });
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment Service Provider", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowSpecOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
