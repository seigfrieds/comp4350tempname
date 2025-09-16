using OurCity.Api.Configurations;
using OurCity.Api.Middlewares;
using Scalar.AspNetCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ExampleSettings>(builder.Configuration.GetSection("ExampleSettings"));

builder.Services.AddSerilog();

builder.Services.AddAuthentication("Cookie")
    .AddCookie("Cookie");
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseGlobalExceptionHandler();
}

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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();