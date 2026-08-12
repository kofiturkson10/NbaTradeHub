using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NbaTradeHub_Api.Core.Interfaces;
using NbaTradeHub_Api.Core.Services;
using NbaTradeHub_Api.Data;
using NbaTradeHub_Api.Data.Enteties;
using NbaTradeHub_Api.Data.Interfaces;
using NbaTradeHub_Api.Data.Repos;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];
var jwtKey = builder.Configuration["Jwt:Key"];

//Web api med controllers.
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<IBlogPostRepo, BlogPostRepo>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddSwaggerGen(options =>
//Detta är konfiguration som gör det möjligt att testa endpoints med behörighet.
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Skriv: Bearer <token>"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//Här sätter vi upp att aplikationen ska jobba med authentication och att det är JWT som sätter detta.
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   //Här säger vi hur vi skall jobba med JWT
   .AddJwtBearer(opt => {
       opt.TokenValidationParameters = new TokenValidationParameters
       {
           //Issuer är vem (vilken server) som utfärdat en JWT token
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = jwtIssuer,
           ValidAudience = jwtAudience,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
       };
   });

//EF connectionstring.
var connString = "Data Source=KOFI\\SQLEXPRESS; Initial Catalog=NbaTradeHubDb;Integrated Security=SSPI;TrustServerCertificate=True;";

builder.Services.AddDbContext<NbaTradesContext>(options => 
    options.UseSqlServer(connString)
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//Routing för att kunna mappa url:en med rätt endpoint i controllern.
app.UseRouting();

//Detta måste sättas upp efter routing.
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
