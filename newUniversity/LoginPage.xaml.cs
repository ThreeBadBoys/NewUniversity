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
            ComboBoxItem ComboItem = (ComboBoxItem)comboBox.SelectedItem;


        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin(object sender, RoutedEventArgs e)
        {

            if (comboBox.SelectionBoxItem.ToString().Equals("Manager"))
            {

                var newForm = new MainWindow(); //create your new form.
                newForm.Show(); //show the new form.
                this.Close(); //only if you want to close the current form.
            }
            else if (comboBox.SelectionBoxItem.ToString().Equals("Master"))
            {

            }
            else if (comboBox.SelectionBoxItem.ToString().Equals("Student"))
            {

            }
        }
    }
}
