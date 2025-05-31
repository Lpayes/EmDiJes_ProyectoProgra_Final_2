using Microsoft.Extensions.Configuration;

public static class Configuracion
{
    private static IConfigurationRoot config;

    static Configuracion()
    {
        config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
    }

    public static string ObtenerApiKeyOpenAI() => config["OpenAI:ApiKey"];

    public static string ObtenerModeloOpenAI() => config["OpenAI:Model"];
}
