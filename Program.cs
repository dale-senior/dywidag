using dywidag.Infastructure.Services;
using Microsoft.Extensions.DependencyInjection;

// Services
var services = new ServiceCollection()
    .AddScoped<ILeapYearApplication, LeapYearApplication>() 
    .AddScoped<ILeapYearService, LeapYearService>()
    .AddScoped<ICsvService, CsvService>()
    .AddScoped<IJsonService, JsonService>()
    .BuildServiceProvider();

// Run App Logic
var app = services.GetService<ILeapYearApplication>();
app?.Run();