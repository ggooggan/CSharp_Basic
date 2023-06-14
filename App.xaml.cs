using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Prism.Events;
using System.Text.Json;
using System.Threading.Tasks.Dataflow;
using System.Windows;

namespace OptionTestProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IHost HostObject { get; }

        public IEventAggregator EventAggregator;

        public BroadcastBlock<ChangeNotifyType> ChangeNotifyBroadcastBlock { get; }

        public App()
        {
            ChangeNotifyBroadcastBlock = new BroadcastBlock<ChangeNotifyType>(null);

            HostObject = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.Sources.Clear();
                    IConfigurationRoot configurationRoot = configuration
                        .SetBasePath(context.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile("default.json", optional: false, reloadOnChange: true)
                        .Build();

                    _ = ChangeToken.OnChange(() => configurationRoot.GetSection("AppSettings").GetReloadToken(), () =>
                    {
                        ChangeNotifyBroadcastBlock.Post(ChangeNotifyType.APP_SETTINGS);
                    });
                    _ = ChangeToken.OnChange(() => configurationRoot.GetSection("defaultSquence").GetReloadToken(), () =>
                    {
                        ChangeNotifyBroadcastBlock.Post(ChangeNotifyType.DEFAULT);
                    });
                })
                .ConfigureServices((context, services) =>
                {
                    _ = services.Configure<AppSettings>(context.Configuration.GetSection("AppSettings"));
                    _ = services.Configure<DefaultSequence>(context.Configuration.GetSection("defaultSquence"));
                    _ = services.AddTransient(typeof(MainWindow));
                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await HostObject.StartAsync();
            HostObject.Services.GetRequiredService<MainWindow>().Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            await HostObject.StopAsync();
        }
    }
}
