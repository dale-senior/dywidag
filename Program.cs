using AutoMapper;
using dywidag.Infastructure.Services;
using dywidag.Infastructure.Profiles;
using Microsoft.Extensions.DependencyInjection;

    var config = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingProfile());
    });

    IMapper mapper = config.CreateMapper();

// Services
var services = new ServiceCollection()
    .AddScoped<ILeapYearApplication, LeapYearApplication>() 
    .AddScoped<ILeapYearService, LeapYearService>()
    .AddScoped<ICsvService, CsvService>()
    .AddScoped<IJsonService, JsonService>()
    .AddSingleton(mapper)
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
    .BuildServiceProvider();

// Run App Logic
var app = services.GetService<ILeapYearApplication>();
app?.Run();