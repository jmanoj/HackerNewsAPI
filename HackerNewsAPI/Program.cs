using HackerNewsAPI.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

builder.Services.AddControllers();
// EXTENSION METHOD FOR DI
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureCors("AllowAll");
builder.Services.AddSwaggerGen();
builder.Services.ConfigureAppServices(configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();
