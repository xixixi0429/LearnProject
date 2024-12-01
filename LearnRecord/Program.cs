using LearnRecordAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LearnRecordDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LearnRecord")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API 文件 v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//定義路由
app.MapControllerRoute(
    name: "LearnRecord",
    pattern: "{controller=LearnRecord}/{action=Index}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LearnRecord}/{action=Index}");
app.Run();

app.Run();
