using OurCity.Api.Configurations;
using OurCity.Api.Middlewares;
using OurCity.Api.Repositories;
using OurCity.Api.Services;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ExampleSettings>(builder.Configuration.GetSection("ExampleSettings"));

builder.Host.UseSerilog((ctx, config) => config
    .ReadFrom.Configuration(builder.Configuration));

builder.Services.AddAuthentication("Cookie")
    .AddCookie("Cookie");
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddScoped<IPostRepository>(sp => new PostRepository(connectionString));

builder.Services.AddScoped<IPostService, PostService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseGlobalExceptionHandler();
}

app.UseCorrelationId();
app.UseSecurityHeaders();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    //Multiple API documentation tools
    app.MapScalarApiReference();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.Run();