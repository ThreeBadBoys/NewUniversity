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
using newUniversity.Classes;
namespace newUniversity
{
    /// <summary>
    /// Interaction logic for MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        public MasterWindow(object o)
        {
            InitializeComponent();
            bindData(o);
        }
        public void bindData(object o)
        {
            if(o != null)
            {
                MasterObject master = o as MasterObject;
                txtUserName.Text = master.firstName + " " + master.lastName; 


            }
        }
        private void listViewItem0_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridListOfClasses.Visibility = Visibility.Visible;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
        }

        private void listViewItem1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridListOfClasses.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Visible;
            GridArrow.Visibility = Visibility.Collapsed;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginWindow = new LoginPage();
            loginWindow.Show();
            CloseWIndowUsingIdentifier("MasterWindow");
        }
        public static void CloseWIndowUsingIdentifier(string windowTag)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Window w in Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentAssembly && w.Tag.Equals(windowTag))
                {
                    w.Close();
                    break;
                }
            }
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void Button_change_Master_Password_Click(object sender, RoutedEventArgs e)
        {

        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void btnReloadClassesList_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
