// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MambuConnector.DependencyInjection;
using MambuConnector.Models.Search;
using MambuConnector.Builders;
using MambuConnector.Interfaces;
using MambuConnector.Models.Enums;
using MambuConnector.Extensions;


var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();


var mambuConnector = serviceProvider.GetRequiredService<IMambuConnector>();

var searchCriteria = new SearchCriteriaBuilder()
    .Build();

var result = mambuConnector.Groups.Search(searchCriteria, new Dictionary<string, string>() { { "limit", "1000" }, { "offset", "1000"} }).Result;


Console.ReadLine();

IServiceCollection ConfigureServices()
{
    var services = new ServiceCollection();

    services.AddLogging(config => config.AddConsole());

    services.AddMambuConnector(opt =>
    {
        opt.Url = "https://camesadev.sandbox.mambu.com/api/";
        opt.User = "usuarioCore";
        opt.Password = "oR5{)UTNPM";
    });

    return services;


}
