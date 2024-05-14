using ShoppingCart.DAL;
using ShoppingCart.DAL.Data.Models;
using ShoppingCart.BL;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using ShoppingCart;
using ShoppingCart.DAL.Data.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//register services
builder.Services.AddBLServices();
builder.Services.AddDALServices(builder.Configuration);




#region Identity

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ProductContext>();

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    // Configure used authentication 
    options.DefaultAuthenticateScheme = "MyDefault";
    options.DefaultChallengeScheme = "MyDefault"; // return 401 if not authenticated, 403 if authenticated but not authorized
})
// Define the authentication scheme
    .AddJwtBearer("MyDefault", options =>
    {
        var keyFromConfig = builder.Configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
        var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
        var key = new SymmetricSecurityKey(keyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = key
        };
    });

#endregion

#region Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", b =>
        b
        .RequireClaim("type", "Admin")
        .RequireClaim(ClaimTypes.NameIdentifier));
});
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
