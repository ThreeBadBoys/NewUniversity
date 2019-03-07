using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace newUniversity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {

        public ManagerWindow()
        {
            InitializeComponent();
        }
        BlurEffect myEffect = new BlurEffect();

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
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyBlureEffectLoading();
            //TODO: RESULTS OF CHANGING PASSWORD WITH UI SHOULD BE SET






        }
        void MyBlureEffectLoading()
        {
            myEffect.Radius = 10;
            Effect = myEffect;

            using (LoadingPage lw = new LoadingPage(Simulator))
            {
                lw.Owner = this;
                lw.ShowDialog();
            }
            myEffect.Radius = 0;
            Effect = myEffect;

        }
        void Simulator()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(7);
            }
        }
        public void ResetPasswordPanel()
        {
            PasswordChangedSuccessfullyMsg.Visibility = Visibility.Collapsed;
            PasswordNotChangedSuccessfullyMsg1.Visibility = Visibility.Collapsed;
            PasswordNotChangedSuccessfullyMsg2.Visibility = Visibility.Collapsed;
        }

        private void listViewItem0_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordPanel();

            GridCreateNewUser.Visibility = Visibility.Visible;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUser.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }
        private void listViewItem1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordPanel();

            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Visible;
            GridRemoveUser.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }
        private void listViewItem2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordPanel();

            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUser.Visibility = Visibility.Visible;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }
        private void listViewItem3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordPanel();

            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUser.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Visible;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }
        private void listViewItem4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ResetPasswordPanel();

            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUser.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Visible;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }
        private void listViewItem5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUser.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Visible;
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginWindow = new LoginPage();
            loginWindow.Show();
            CloseWIndowUsingIdentifier("ManagerWindow");
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
    }
}