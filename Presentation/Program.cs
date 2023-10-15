using Application;
using Application.External.Interfaces.Authentication;
using Infrastructure;
using Persistence;
var devCorsPolicy = "devCorsPolicy";

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpContextAccessor();
    
    builder.Services
        .AddPersistence(builder.Configuration)
        .AddApplication(builder.Configuration)
        .AddInfrastructure(builder.Configuration);
    
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(devCorsPolicy, builder => {
            //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
            //builder.SetIsOriginAllowed(origin => true);
        });
    });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors(devCorsPolicy);
    }

  
    
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.Use((ctx, next) =>
    {
        ctx.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:3000";
        return next();
    });
    app.MapControllers();
    app.Run();
}