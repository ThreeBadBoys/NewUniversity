using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace newUniversity
{
    /// <summary>
    /// Interaction logic for CorrectWindow.xaml
    /// </summary>
    public partial class CorrectWindow : Window, IDisposable
    {
        public Action Worker { get; set; }
        LoginPage secondForm;
        public CorrectWindow(Action worker)
        {
            InitializeComponent();
            Worker = worker;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(Worker).ContinueWith(t => { Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void Dispose()
        {

        }
        private void image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }      
    }
}