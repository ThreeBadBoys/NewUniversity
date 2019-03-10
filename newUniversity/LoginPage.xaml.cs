using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
namespace newUniversity
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {

        public LoginPage()
        {
            InitializeComponent();
        }
        string id = "1234";
        string password = "1234";
        BlurEffect myEffect = new BlurEffect();
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectionBoxItem.ToString().Equals("Manager"))
            {
                MyBlureEffectLoading();

                if (passwordInput.Password.ToString().Equals(password))
                {
                    MyBlureEffectCorrect();
                    ManagerWindow managerWindow = new ManagerWindow();
                    managerWindow.Show();
                    CloseWIndowUsingIdentifier("login");

                }
                else
                {
                    MyBlureEffectWrong();
          
                }

            }
            else if (comboBox.SelectionBoxItem.ToString().Equals("Master"))
            {
                MyBlureEffectLoading();
                if (passwordInput.Password.ToString().Equals(password))
                {
                    MyBlureEffectCorrect();
                    MasterWindow masterWindow = new MasterWindow();
                    masterWindow.Show();
                    CloseWIndowUsingIdentifier("login");

                }
                else
                {
                    MyBlureEffectWrong();

                }

            }
            else if (comboBox.SelectionBoxItem.ToString().Equals("Student"))
            {
                MyBlureEffectLoading();

                if (passwordInput.Password.ToString().Equals(password))
                {
                    MyBlureEffectCorrect();
                    StudentWindow studentWindow = new StudentWindow();
                    studentWindow.Show();
                    CloseWIndowUsingIdentifier("login");

                }
                else
                {
                    MyBlureEffectWrong();

                }
            }
        }
        void Simulator()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(7);
            }
        }
        void SimulatorWrongWindow()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(5);
            }
        }
        void Simulator1()
        {
            Thread.Sleep(0);
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
        void MyBlureEffectWrong()
        {
            myEffect.Radius = 10;
            Effect = myEffect;

            using (WrongWindow lw = new WrongWindow(SimulatorWrongWindow))
            {
                lw.Owner = this;
                lw.ShowDialog();

            }


            myEffect.Radius = 0;
            Effect = myEffect;

        }
        void MyBlureEffectCorrect()
        {
            myEffect.Radius = 10;
            Effect = myEffect;

            using (CorrectWindow lw = new CorrectWindow(SimulatorWrongWindow))
            {
                lw.Owner = this;
                lw.ShowDialog();

            }


            myEffect.Radius = 0;
            Effect = myEffect;

        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
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
