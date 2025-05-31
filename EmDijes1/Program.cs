using EmDijes1.Models;
using Microsoft.Extensions.Configuration;
using EmDijes1;

static class Program
{
    public static IConfiguration Configuration { get; private set; }

    [STAThread]
    static void Main()
    {
        try
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var configAWS = Configuration.GetSection("AWS").Get<ConfiguracionAWS>();
            var configOpenAI = Configuration.GetSection("OpenAI").Get<OpenAISettings>(); // 🔧 Aquí está el fix

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm(configAWS, configOpenAI));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"💥 Error crítico al iniciar la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}