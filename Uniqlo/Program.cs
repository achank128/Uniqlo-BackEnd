using Uniqlo.Middlewares;
using Uniqlo.DataAccess;
using Uniqlo.BusinessLogic;
using Uniqlo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<Performance>();
app.UseMiddleware<GlobalException>();

app.MapControllers();

app.Run();
