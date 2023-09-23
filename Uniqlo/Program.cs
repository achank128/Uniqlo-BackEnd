using Uniqlo.Middlewares;
using Uniqlo.DataAccess;
using Uniqlo.BusinessLogic;
using Uniqlo;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger
builder.Services.AddSwagger();

//Jwt
builder.Services.AddJwt(builder.Configuration);

//Middlewares
builder.Services.AddMiddlewares();

//Data Access
builder.Services.AddDataAccess(builder.Configuration);

//Business Logic
builder.Services.AddBusinessLogic();

//Cors
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//Memory caching
builder.Services.AddMemoryCache();

//Distributed caching
//builder.Services.AddDistributedMemoryCache();

//Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    //options.InstanceName = "Uniqlo";
});

//HttpContext Access
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

//app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
//    RequestPath = new PathString("/Resources")
//});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<Performance>();
app.UseMiddleware<GlobalException>();

app.MapControllers();

app.Run();
