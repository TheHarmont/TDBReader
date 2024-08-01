using TDBReader.Extensions;
using TDBReader.Presistence.Extensions;

try
{
    var builder = Host.CreateDefaultBuilder(args);

    builder.
        ConfigureAppConfiguration((config) =>
        {
            config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
        }).
        ConfigureServices((hostContext, services) =>
        {
            var configuration = hostContext.Configuration;
        
            services.AddLayers(configuration);
        });

    var app = builder.Build();

    await app.RunAsync();
}
catch (Exception ex)
{
    ///TODO: записать лог
	throw;
}

