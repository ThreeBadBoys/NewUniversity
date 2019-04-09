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
        private object o;
        private static int counter1 = 0;
        public MasterWindow(
     object o)
        {
            InitializeComponent();
            this.o = o;
          bindData(o);
        }
        public void bindData(object o)
        {
            if (o != null)
            {
                MasterObject master = o as MasterObject;
                txtUserName.Text = master.firstName + " " + master.lastName;
            }
        }
        private void listViewItem0_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridInsertGrade.Visibility = Visibility.Collapsed;
            GridListOfClasses.Visibility = Visibility.Visible;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveCourseMaster.Visibility = Visibility.Collapsed;
        }

        private void listViewItem1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridListOfClasses.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Visible;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveCourseMaster.Visibility = Visibility.Collapsed;
            GridInsertGrade.Visibility = Visibility.Collapsed;
        }
        private void listViewItem2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridCreateNewCourse.Visibility = Visibility.Visible;
            GridListOfClasses.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveCourseMaster.Visibility = Visibility.Collapsed;
            GridInsertGrade.Visibility = Visibility.Collapsed;
        }
        private void listViewItem3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridRemoveCourseMaster.Visibility = Visibility.Visible;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridListOfClasses.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridInsertGrade.Visibility = Visibility.Collapsed;
        }
        private void listViewItem4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
       
            GridInsertGrade.Visibility = Visibility.Visible;

            GridRemoveCourseMaster.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridListOfClasses.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
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


            Interface.changeUserPassword(
                o,
                txtCurentPasswordMaster.Text.ToString(),
                txtNewPasswordMaster.Password.ToString(),
                txtNewPasswordAgainMaster.Password.ToString()
                , "Master");



        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void btnReloadClassesList_Click(object sender, RoutedEventArgs e)
        {
            counter1 = 0;
            DATAGRIDGClASSES.Items.Clear();
            List<CourseObject> crs = Interface.getAllClasses(o);

            foreach (CourseObject crsObject in crs)
            {

                //DATAGRIDGClASSES.Items.Add(new Class(
                //    crsObject.name,
                //    crsObject.ID,
                //    crsObject.time,
                //    crsObject.date,
                //    crsObject.days,
                //    crsObject.examTime,
                //    crsObject.examDate));
            }
        }
        class Class
        {
            public int ClassNo { get; set; }
            public string ClassCourseName { get; set; }
            public string ClassCourseID { get; set; }
            public string ClassTime { get; set; }
            public string ClassDate { get; set; }
            public string ClassDays { get; set; }
            public string ClassExamTime { get; set; }
            public string ClassExamDate { get; set; }


            public Class(
                string ClassCourseName,
                string ClassCourseID,
                string ClassTime,
                string ClassDate,
                string ClassDays,
                string ClassExamTime,
                string ClassExamDate
                )
            {
                this.ClassNo = ++counter1;
                this.ClassCourseName = ClassCourseName;
                this.ClassCourseID = ClassCourseID;
                this.ClassTime = ClassTime;
                this.ClassDate = ClassDate;
                this.ClassDays = ClassDays;
                this.ClassExamTime = ClassExamTime;
                this.ClassExamDate = ClassExamDate;
            }
        }




        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {


            string days = "";

            if (checkBox_Sun.IsChecked.Value)
            {
                days += "Sun _ ";
            }
            if (checkBox_Mon.IsChecked.Value)
            {
                days += "Mon _ ";
            }

            if (checkBox_Tue.IsChecked.Value)
            {
                days += "Tue _ ";
            }
            if (checkBox_Wed.IsChecked.Value)
            {
                days += "Wed _ ";
            }

            if (checkBox_Thu.IsChecked.Value)
            {
                days += "Thu _ ";
            }
            days = days.Substring(0, days.Length - 3);
            Interface.addClass(o,
                txtCourseNameForCreateClass.Text.ToString(),
                txtCourseIDForCreateClass.Text.ToString(),
                txtCourseUnitNOForCreateClass.Text.ToString(),
                dpCourseExamDateForCreateClass.Text.ToString(),
                tmCourseExamTimeForCreateClass.Text.ToString(),
                tmCourseForCreateClass.Text.ToString(),
                days
                );
        }



        private void btn_DeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            Interface.removeCourseMaster(o, txtCourseIDMaster.Text.ToString());
        }

        private void Button_Insert_Grade_Click(object sender, RoutedEventArgs e)
        {
            Interface.insertGrade(
                o,
                txtCourseIDForInsertGrade.Text.ToString(),
                txtStudentIDForInsertGrade.Text.ToString(),
                txtGradeForInsertGrade.Text.ToString()
                );
        }
    }
}
