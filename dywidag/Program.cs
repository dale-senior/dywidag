using AutoMapper;
using dywidag.Infastructure.Services;
using dywidag.Infastructure.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;

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
    .AddScoped<IFileSystem, FileSystem>()
    .AddSingleton(mapper)
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
    .BuildServiceProvider();

// Run App Logic
var app = services.GetService<ILeapYearApplication>();
await app!.Run();