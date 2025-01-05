using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// OpenWeather API için HttpClient'i Dependency Injection'a ekleyelim
builder.Services.AddHttpClient("OpenWeatherClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["OpenWeather:BaseUrl"]);
});

// CORS ayarları ekliyoruz
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Her yerden erişime izin verir
              .AllowAnyMethod()   // Her HTTP metoduna izin verir
              .AllowAnyHeader();  // Her header'a izin verir
    });
});


// API ile çalışmak için gerekli hizmetleri ekliyoruz
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Uygulama başlatılıyor
var app = builder.Build();

// Swagger UI kullanımı
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS politikasını uyguluyoruz
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
