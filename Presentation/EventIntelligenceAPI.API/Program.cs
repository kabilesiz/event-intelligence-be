using EventIntelligenceAPI.Application;
using EventIntelligenceAPI.Infrastructure;
using EventIntelligenceAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("All", opt =>
    {
        opt.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

        //opt.WithOrigins("http://nursin.com", "http://yavuzsamet.com").WithMethods("GET").AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAInfrastructureServices(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("All");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();