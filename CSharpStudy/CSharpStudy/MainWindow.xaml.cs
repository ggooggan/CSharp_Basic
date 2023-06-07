using System.Windows;

namespace CSharpStudy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        YamlRead _yamlRead = new YamlRead();
        YamlWrite _yamlWrite = new YamlWrite();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Click_YamlRead(object sender, RoutedEventArgs e)
        {
            _yamlRead.Read();
        }

        private void Click_YamlWrite(object sender, RoutedEventArgs e)
        {
            _yamlWrite.Write();
        }
    }
}
