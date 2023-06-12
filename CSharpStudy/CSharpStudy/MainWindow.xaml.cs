using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpStudy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyClass myClass = new MyClass();
            myClass.Func();

            Type type = typeof(MyClass);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);


            foreach (var attr in attributes)
            {
                History hist = attr as History;

                if(hist != null)
                {
                    Console.WriteLine($"version {hist.Version} // programmer {hist.Programmer} // Changes {hist.Changes}");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
