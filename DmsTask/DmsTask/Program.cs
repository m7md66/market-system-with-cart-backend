using DmsTask.Helper.Middleware;
using DmsTask.Models;
using DmsTask.Persistence;
using DmsTask.Persistence.IRepositories;
using DmsTask.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

string cor = "hi";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(n => n.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
  
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IJwtFunctions,JwtFunctions>();
builder.Services.AddScoped<IOrderDetailsRepository,OrderDetailsRepository>();
builder.Services.AddScoped<IItemsRepository,ItemsRepository>();
builder.Services.AddDbContext<DmsContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DmsDb")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DmsContext>().AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// JWT 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
    };
});

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(cor,
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//jwt
app.UseAuthentication();
app.UseAuthorization();
app.UseUnauthorizedMiddleware();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(cor);
app.MapControllers();

app.Run();
