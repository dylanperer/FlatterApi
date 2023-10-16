using Application;
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
            // builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "http://192.168.18.39:3000");
            builder.SetIsOriginAllowed(origin => true);
        });
    });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

  
    
    app.UseHttpsRedirection();

    app.UseCors(devCorsPolicy);

    app.UseAuthentication();
    app.UseAuthorization();
    app.Use((ctx, next) =>
    {
        ctx.Response.Headers["Access-Control-Allow-Origin"] = "http://192.168.18.39:3000";
        return next();
    });

    app.MapControllers();
    app.Run();
}