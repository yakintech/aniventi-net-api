using Aniventi.Api.Models.Exceptions;
using Aniventi.BLL.Services.UnitOfWork;
using Aniventi.DAL.ORM.Context;
using Aniventi.Dto.Models.Category;
using Aniventi.Dto.Validations.Category;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)))
    .AddFluentValidation();


builder.Services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<DeleteCategoryDto>, DeleteCategoryDtoValidator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidIssuer = "cagatay.com",
        ValidAudience = "cagatay2.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aEySwcUDaEySwcUD"))
    };
});




builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Aniventi ECommerce",
        Description = "Aniventi ECommerce...",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});



builder.Services.AddDbContext<AniventiECommerceContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();


//AddScoped, AddTransit, AddSingleton