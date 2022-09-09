using Aniventi.BLL.Services.UnitOfWork;
using Aniventi.DAL.ORM.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddDbContext<AniventiECommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration["DefaultConnection"]);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


//AddScoped, AddTransit, AddSingleton