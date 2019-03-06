using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;
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
                MyBlureEffect();
                if (passwordInput.Password.ToString().Equals(password))
                {

              
                    var newForm = new MainWindow(); //create your new form.
                    newForm.Show(); //show the new form.
                    this.Close(); //only if you want to close the current form.
                }
                else
                {

                }

            }
            else if (comboBox.SelectionBoxItem.ToString().Equals("Master"))
            {
                MyBlureEffect();

            }
            else if (comboBox.SelectionBoxItem.ToString().Equals("Student"))
            {
                MyBlureEffect();
            }
        }
        void Simulator()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(7);
            }
        }
     
        void MyBlureEffect()
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
       
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
    }
}
