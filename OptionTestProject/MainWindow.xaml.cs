using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OptionTestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IOptionsSnapshot<AppSettings> appSettings { get; }

        private IOptionsSnapshot<DefaultSequence> defaultSequenceSettings { get; }

        private IDisposable broadcastLink { get; set; }

        public MainWindow(IOptionsSnapshot<AppSettings> appSettings, IOptionsSnapshot<DefaultSequence> defaultSequenceSettings)
        {
            this.appSettings = appSettings;
            this.defaultSequenceSettings = defaultSequenceSettings;
/*            this.configuration.OnChange((settings) =>
            {
                var a1a33 = this.configuration;
                var i = 0;
            });*/
            InitializeComponent();
            SetSubscribeChangegNotifyBroadcastBlock();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                TextBox control = sender as TextBox;
                appSettings.Value.Name = control.Text;
                defaultSequenceSettings.Value.addNewSample.description = control.Text;
                AppSettings.SaveChanged(appSettings.Value);
                DefaultSequence.SaveChanged(defaultSequenceSettings.Value);
            }
        }

        private void SetSubscribeChangegNotifyBroadcastBlock()
        {
            if (Application.Current is App rootApp)
            {
                broadcastLink = rootApp.ChangeNotifyBroadcastBlock.LinkTo(new ActionBlock<ChangeNotifyType>(type =>
                {
                    switch (type)
                    {
                        case ChangeNotifyType.INVALID:
                            break;
                        case ChangeNotifyType.APP_SETTINGS:
                            Dispatcher.Invoke(() =>
                            {
                                TextBlock.Text = appSettings.Value.Name;
                            });
                            break;
                        case ChangeNotifyType.DEFAULT:
                            Dispatcher.Invoke(() =>
                            {
                                TextBlock1.Text = defaultSequenceSettings.Value.addNewSample.description;
                            });
                            break;
                        default:
                            break;
                    }
                }));
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            broadcastLink.Dispose();
        }
    }
}
