using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MP.ApiDotNet6.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Api DotNet 6",
        Version = "v1",
        Description = "Criando uma Api em DotNet Core 6"

    });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = @"Autenticacao em JWT. \r\n\r\n
                        Ex: Bearer{token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In= ParameterLocation.Header

            },

            new List<string>()

        }

    });


});


//referenciar as classes que foram criadas em MP.ApiDotNet6.IoC
//DependencyInjection - Infra Estrutura (AddInInfrastructure)
//e Servico (AddServices)
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
//_____________________________________________________________

//Remove os nulos do nosso return no Json
builder.Services.AddMvc().AddJsonOptions(option =>
{

    option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
//____________________________________________________________


//Referente ao TOKEN
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projetoDotNetCore6"));
builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer("Bearer", options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = key,
        ValidateAudience = false,
        ValidateIssuer = false
    };
});


//_________________________________________________________________

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();    
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

