using AutoMapper;
using dywidag.Infastructure.Services;
using dywidag.Infastructure.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var config = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingProfile());
    });

// create a configuration instance
var nconfig = new NLog.Config.LoggingConfiguration();

// create a console logging target
var logConsole = new NLog.Targets.ConsoleTarget();

// send logs with levels from Info to Fatal to the console
nconfig.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logConsole);

// apply the configuration
NLog.LogManager.Configuration = nconfig;
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