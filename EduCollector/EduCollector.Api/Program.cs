using EduCollector.Application;
using Persistence.EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEduCollectorApplication();
builder.Services.AddEduCollectorPersistenceEFServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("Open");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
