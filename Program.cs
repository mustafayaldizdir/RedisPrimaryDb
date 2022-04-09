using RedisApi.Data;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

 

builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
     ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection"))
 );

builder.Services.AddControllers();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlatformRepo, RedisPlatformRepo>();
var app = builder.Build();

 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
