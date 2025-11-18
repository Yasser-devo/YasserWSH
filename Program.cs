using Microsoft.EntityFrameworkCore;
using YasserWorkShop.Data;
using YasserWorkShop.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WSHDBContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("con")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IEmployeerRepo, EmployeerRepo>();
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.Urls.Add($"http://0.0.0.0:{Environment.GetEnvironmentVariable("PORT")}");


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
