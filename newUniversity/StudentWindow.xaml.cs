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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        List<CHOSENCourses> list = new List<CHOSENCourses>();
        CHOSENCourses cr1 = new CHOSENCourses(1, "ALGO", "123", "03/12/2019", "12:00", "JAFAR TANHA", 9876);
        CHOSENCourses cr2 = new CHOSENCourses(2, "ALGsdaO", "444", "03/06/2019", "16:00", "RAZAVI", 1313);
        CHOSENCourses cr3 = new CHOSENCourses(3, "ALGO", "123", "03/12/2019", "12:00", "JAFAR TANHA", 9876);
        CHOSENCourses cr4 = new CHOSENCourses(4, "ALGsdaO", "444", "03/06/2019", "16:00", "RAZAVI", 1313);
        public StudentWindow()
        {
           InitializeComponent();


         
            list.Add(cr1);
            list.Add(cr2);
            list.Add(cr3);
            list.Add(cr4);

         



        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void listViewItem0_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //This term Courses
            GridThisTermCourses.Visibility = Visibility.Visible;
            GridPassedCourses.Visibility = Visibility.Collapsed;
            GridGRADES.Visibility = Visibility.Collapsed;
            GridADDORREMOVECOURSE.Visibility = Visibility.Collapsed;
            GridUnitChoice.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }

        private void listViewItem1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //PassedCourses
            GridThisTermCourses.Visibility = Visibility.Collapsed;
            GridPassedCourses.Visibility = Visibility.Visible;
            GridGRADES.Visibility = Visibility.Collapsed;
            GridADDORREMOVECOURSE.Visibility = Visibility.Collapsed;
            GridUnitChoice.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }

        private void listViewItem2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Grades
            GridThisTermCourses.Visibility = Visibility.Collapsed;
            GridPassedCourses.Visibility = Visibility.Collapsed;
            GridGRADES.Visibility = Visibility.Visible;
            GridADDORREMOVECOURSE.Visibility = Visibility.Collapsed;
            GridUnitChoice.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }

        private void listViewItem3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //UnitChoice
            GridThisTermCourses.Visibility = Visibility.Collapsed;
            GridPassedCourses.Visibility = Visibility.Collapsed;
            GridGRADES.Visibility = Visibility.Collapsed;
            GridADDORREMOVECOURSE.Visibility = Visibility.Visible;
            GridUnitChoice.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }

        private void listViewItem4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Add remove
            GridThisTermCourses.Visibility = Visibility.Collapsed;
            GridPassedCourses.Visibility = Visibility.Collapsed;
            GridGRADES.Visibility = Visibility.Collapsed;
            GridADDORREMOVECOURSE.Visibility = Visibility.Collapsed;
            GridUnitChoice.Visibility = Visibility.Visible;
            GridChangePassword.Visibility = Visibility.Collapsed;
        }

        private void listViewItem5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Change Password
            GridThisTermCourses.Visibility = Visibility.Collapsed;
            GridPassedCourses.Visibility = Visibility.Collapsed;
            GridGRADES.Visibility = Visibility.Collapsed;
            GridADDORREMOVECOURSE.Visibility = Visibility.Collapsed;
            GridUnitChoice.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Visible;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginWindow = new LoginPage();
            loginWindow.Show();
            CloseWIndowUsingIdentifier("StudentWindow");
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
        //TESTING THE DATAGRID 
        public class Courses
        {
            public int rowNo { get; set; }
            public string NAME { get; set; }
            public string ID { get; set; }
            public string EXAMDATE { get; set; }
            public string EXAMTIME { get; set; }
            public Courses(int rowNo, string NAME, string ID, string EXAMDATE, string EXAMTIME)
            {
                this.rowNo = rowNo;
                this.NAME = NAME;
                this.ID = ID;
                this.EXAMDATE = EXAMDATE;
                this.EXAMTIME = EXAMTIME;
            }

           
        }
        public class PassedCourses
        {
            public int PassedrowNo { get; set; }
            public string PassedNAME { get; set; }
            public string PassedID { get; set; }
            public string PassedEXAMDATE { get; set; }
            public string PassedEXAMTIME { get; set; }
            public string PassedSTATE { get; set; }
            public float PassedGRADE { get; set; }
            public PassedCourses(int PassedrowNo, string PassedNAME, string PassedID, string PassedEXAMDATE, string PassedEXAMTIME, float PassedGRADE)
            {
                this.PassedrowNo = PassedrowNo;
                this.PassedNAME = PassedNAME;
                this.PassedID = PassedID;
                this.PassedEXAMDATE = PassedEXAMDATE;
                this.PassedEXAMTIME = PassedEXAMTIME;
                this.PassedGRADE = PassedGRADE;
                if (PassedGRADE >= 10)
                {
                    this.PassedSTATE = "Pass";
                }
                else
                {
                    this.PassedSTATE = "Fail";
                }
            }
           

        }
        public class CHOSENCourses
        {
            public int CHOSENCOURSErowNo { get; set; }
            public string CHOSENCOURSENAME { get; set; }
            public string CHOSENCOURSEID { get; set; }
            public string CHOSENCOURSEEXAMDATE { get; set; }
            public string CHOSENEXAMTIME { get; set; }
            public string CHOSENCOURSEMASTERNAME { get; set; }
            public int CHOSENCOURSECLASSNO { get; set; }
            public CHOSENCourses(int CHOSENCOURSErowNo, string CHOSENCOURSENAME, string CHOSENCOURSEID, string CHOSENCOURSEEXAMDATE, string CHOSENEXAMTIME, string CHOSENCOURSEMASTERNAME, int CHOSENCOURSECLASSNO)
            {
                this.CHOSENCOURSErowNo = CHOSENCOURSErowNo;
                this.CHOSENCOURSENAME = CHOSENCOURSENAME;
                this.CHOSENCOURSEID = CHOSENCOURSEID;
                this.CHOSENCOURSEEXAMDATE = CHOSENCOURSEEXAMDATE;
                this.CHOSENEXAMTIME = CHOSENEXAMTIME;
                this.CHOSENCOURSEMASTERNAME = CHOSENCOURSEMASTERNAME;
                this.CHOSENCOURSECLASSNO = CHOSENCOURSECLASSNO;
            }


        }

        private void courseID_GotFocus(object sender, RoutedEventArgs e)
        {
            AddNewCourseUnitChoicecourseID.Width += 10;
            AddNewCourseUnitChoiceButton.Width -= 10;
        }

        private void courseID_LostFocus(object sender, RoutedEventArgs e)
        {
            AddNewCourseUnitChoicecourseID.Width-= 10;
            AddNewCourseUnitChoiceButton.Width += 10;
        }

        private void courseID1_GotFocus(object sender, RoutedEventArgs e)
        {
            DELNewCourseUnitChoicecourseID.Width += 10;
            DELNewCourseUnitChoiceButton.Width -= 10;
        }

        private void courseID1_LostFocus(object sender, RoutedEventArgs e)
        {
            DELNewCourseUnitChoicecourseID.Width -= 10;
            DELNewCourseUnitChoiceButton.Width += 10;
        }

        private void AddNewCourseUnitChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            //AddNewCourseUnitChoiceButton
            string id = AddNewCourseUnitChoicecourseID.Text;
            //Here We got the id of the course which should be added to user's chosen units.
            //Be sure if it wasn't chosen before.
            //Be sure if the course with this id Exists
            //Then delete it

            DATAGRIDADDORREMOVECOURSE.Items.Add(cr1);


        }

        private void DELNewCourseUnitChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            //DELNewCourseUnitChoiceButton
            string id = DELNewCourseUnitChoicecourseID.Text;
            //Here We got the id of the course which should be deleted to user's chosen units.
            //Now we have to search and find that chosen course.If it exists then delete it
            //else show error    if(DATAGRIDUNITCHOICE.Items[i].Equals(list[j]))
            DATAGRIDADDORREMOVECOURSE.Items.Remove(cr1);
        }

        private void btn_change_Password_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
