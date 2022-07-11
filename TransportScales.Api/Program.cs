
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using TransportScales.Api;
using TransportScales.Api.HealthCheck;
using TransportScales.Core.Configuration;
using TransportScales.Data;
using TransportScales.Data.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddDbContext<TransportDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
}
    );

builder.Services.MakeRepositoryDependencies();
builder.Services.MakeServiceDependencies();
builder.Services.AddAutoMapper(typeof(MapperConfiguration));

builder.Services.AddHealthChecks()
                .AddCheck<LivenessCheck>("liveness", tags: new[] { "liveness" })
                .AddCheck<ReadinessCheck>("readiness", tags: new[] { "readiness" });


//builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddHangfireServer();

builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

var origins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
app.UseCors(x => x
                .WithOrigins(origins)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()); 

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health/liveness", new HealthCheckOptions { Predicate = x => x.Name == "liveness" });
    endpoints.MapHealthChecks("/health/readiness", new HealthCheckOptions { Predicate = x => x.Name == "readiness" });
    endpoints.MapControllers();
});

await SeedData.SeedDb(builder);

app.Run();
