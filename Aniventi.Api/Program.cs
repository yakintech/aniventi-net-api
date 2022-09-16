using Aniventi.BLL.Services.UnitOfWork;
using Aniventi.DAL.ORM.Context;
using Aniventi.Dto.Models.Category;
using Aniventi.Dto.Validations.Category;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddFluentValidation();

builder.Services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<DeleteCategoryDto>, DeleteCategoryDtoValidator>();



builder.Services.AddDbContext<AniventiECommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


//AddScoped, AddTransit, AddSingleton