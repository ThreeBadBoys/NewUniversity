﻿using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using newUniversity.Classes;

namespace newUniversity
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private object o;
        private static int counter1 = 0;
        private static int counter2 = 0;
        public StudentWindow(
        object o)
        {
            InitializeComponent();
       bindData(o);
            this.o = o;
       
        }
        public void bindData(object o)
        {
            if (o != null)
            {
                StudentObject student = o as StudentObject;
                txtUserName.Text = student.firstName + " " + student.lastName;


            }
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
            GridArrow.Visibility = Visibility.Collapsed;
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
            GridArrow.Visibility = Visibility.Collapsed;
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
            GridArrow.Visibility = Visibility.Collapsed;
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
            GridArrow.Visibility = Visibility.Collapsed;
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
            GridArrow.Visibility = Visibility.Collapsed;
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
            GridArrow.Visibility = Visibility.Collapsed;
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
           
            public CHOSENCourses(string CHOSENCOURSENAME, string CHOSENCOURSEID, string CHOSENCOURSEEXAMDATE, string CHOSENEXAMTIME, string CHOSENCOURSEMASTERNAME)
            {
                this.CHOSENCOURSErowNo = ++counter2;
                this.CHOSENCOURSENAME = CHOSENCOURSENAME;
                this.CHOSENCOURSEID = CHOSENCOURSEID;
                this.CHOSENCOURSEEXAMDATE = CHOSENCOURSEEXAMDATE;
                this.CHOSENEXAMTIME = CHOSENEXAMTIME;
                this.CHOSENCOURSEMASTERNAME = CHOSENCOURSEMASTERNAME;
               
            }


        }

        private void courseID_GotFocus(object sender, RoutedEventArgs e)
        {
            AddNewCourseUnitChoicecourseID.Width += 10;
            AddNewCourseUnitChoiceButton.Width -= 10;
        }

        private void courseID_LostFocus(object sender, RoutedEventArgs e)
        {
            AddNewCourseUnitChoicecourseID.Width -= 10;
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
            //Here We got the id of the course which should be added to user's chosen units.
            //Be sure if it wasn't chosen before.
            //Be sure if the course with this id Exists
            //Then delete it


       



        List<object>crses =   Interface.chooseCourse(o, UnitChoiceID.Text.ToString());
            foreach(CourseObject crs in crses)
            {
                DATAGRIDADDORREMOVECOURSE.Items.Add(
                    new CHOSENCourses(crs.name,crs.ID+"",crs.examDate,crs.examTime,crs.masterID+""));
            }







        }

        private void DELNewCourseUnitChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            //DELNewCourseUnitChoiceButton
            string id = DELNewCourseUnitChoicecourseID.Text;
            //Here We got the id of the course which should be deleted to user's chosen units.
            //Now we have to search and find that chosen course.If it exists then delete it
            //else show error    if(DATAGRIDUNITCHOICE.Items[i].Equals(list[j]))
         
            
            // DATAGRIDADDORREMOVECOURSE.Items.Remove(cr1);
        }

        private void btn_change_Password_Click(object sender, RoutedEventArgs e)
        {


        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        public void ResetPasswordPanel()
        {
            PasswordChangedSuccessfullyMsg.Visibility = Visibility.Collapsed;
            PasswordNotChangedSuccessfullyMsg1.Visibility = Visibility.Collapsed;
            PasswordNotChangedSuccessfullyMsg2.Visibility = Visibility.Collapsed;
        }
        class ThisTermCourse
        {

            public int TermCourseNo { get; set; }
            public string TermCourseID { get; set; }
            public string TermCourseNAME { get; set; }
            public string TermCourseTime { get; set; }
            public string TermCourseDays { get; set; }
            public string TermCourseEXAMDATE { get; set; }
            public string TermCourseEXAMTIME { get; set; }
            public string TermCoursesMasterID { get; set; }
       
            public ThisTermCourse(
                string TermCourseID,
                string TermCourseNAME,
                string TermCourseTime,
                string TermCourseDays,
                string TermCourseEXAMDATE,
                string TermCourseEXAMTIME,
                string TermCoursesMasterID
                )
            {
                this.TermCourseNo = ++counter1;
                this.TermCourseID = TermCourseID;
                this.TermCourseNAME = TermCourseNAME;
                this.TermCourseTime = TermCourseTime;
                this.TermCourseDays = TermCourseDays;
                this.TermCourseEXAMDATE = TermCourseEXAMDATE;
                this.TermCourseEXAMTIME = TermCourseEXAMTIME;
                this.TermCoursesMasterID = TermCoursesMasterID;
            }

        }


        private void btnReloadThisTemCoursesList_Click(object sender, RoutedEventArgs e)
        {
            counter1 = 0;
            DATAGRIDTHISTERMCOURSES.Items.Clear();
            List<object> courses = Interface.getThisTermCourse(o);
            foreach (CourseObject termCrs in courses)
            {
             
                DATAGRIDTHISTERMCOURSES.Items.Add(new ThisTermCourse(
                    termCrs.ID.ToString(),
                    termCrs.name,
                    termCrs.courseTime,
                    termCrs.classDays,
                    termCrs.examDate,
                    termCrs.examTime,
                    termCrs.masterID.ToString()

                    ));
            }
        }

        private void btnReloadPassedCoursesList_Click(object sender, RoutedEventArgs e)
        {
            DATAGRIDPASSEDCOURSES.Items.Clear();




        }

        private void btnReloadUnits_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
