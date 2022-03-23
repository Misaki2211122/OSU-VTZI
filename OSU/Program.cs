using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using API.Attributes;
using Application;
using Database;
//using InternalConnector;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        ReferenceHandler = ReferenceHandler.Preserve,
    }));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Слой основной бизнес логики
/// </summary>
builder.Services.AddApplication();
/// <summary>
/// Слой микросервиса базы данных
/// </summary>
builder.Services.AddInfrastructureDatabase(builder.Configuration);


/// <summary>
/// Слой микросервиса внутренних соединений
/// </summary>
//builder.Services.AddInfrastructureConnector();
//builder.Services.AddInfrastructureInternalConnectors();

/*builder.Services.AddAuthentication()
    .AddScheme<BasicAuthOptions, BasicAuthHandler>("BasicScheme", null);
builder.Services.AddAuthorization(x =>
    x.AddPolicy("BasicPolicy",
        policy =>
        {
            policy.AddAuthenticationSchemes("BasicScheme");
            policy.RequireClaim(ClaimTypes.Name);
        }));*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScanCity.LK");
    c.RoutePrefix = string.Empty;
});

app.Run();