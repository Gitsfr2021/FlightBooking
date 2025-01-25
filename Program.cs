using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utravs.Application.Handlers;
using Utravs.Application.Interfaces;
using Utravs.Application.Passenger.Commands;
using Utravs.Application.Services;
using Utravs.Application.Validation;
using Utravs.Infrastructure.Persistence.DbContexts;
using Utravs.Infrastructure.Repositories;
using Utravs.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Register application services
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();

builder.Services.AddTransient<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddTransient<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IPassengerService, PassengerService>();

// MediatR Services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFlightCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreatePassengerCommand>());
builder.Services.AddValidatorsFromAssemblyContaining<CreatePassengerCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//// Add controllers for Web API
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Configure Swagger/OpenAPI for API documentation
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Utravs API",
        Version = "v1"
    });
});
var app = builder.Build();
app.UseStaticFiles();
app.UseMiddleware<ErrorHandlingMiddleware>();

//Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Utravs API v1");
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


