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
using newUniversity.Classes;
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
                Thread.Sleep(4);
            }
        }
        public void ResetPasswordPanel()
        {
            PasswordChangedSuccessfullyMsg.Visibility = Visibility.Collapsed;
            PasswordNotChangedSuccessfullyMsg1.Visibility = Visibility.Collapsed;
            PasswordNotChangedSuccessfullyMsg2.Visibility = Visibility.Collapsed;
        }
        public void ResetUnitChoicePanel()
        {
            UnitChoiceStateMsg.Visibility = Visibility.Collapsed;
        }
        private void listViewItem0_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordPanel();
            ResetUnitChoicePanel();
            GridCreateNewUser.Visibility = Visibility.Visible;
            GridSTUDENTS.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveStudent.Visibility = Visibility.Collapsed;
        }
        private void listViewItem1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordPanel();
            ResetUnitChoicePanel();
            GridSTUDENTS.Visibility = Visibility.Collapsed;
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Visible;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveStudent.Visibility = Visibility.Collapsed;
        }
        private void listViewItem2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordPanel();
            GridSTUDENTS.Visibility = Visibility.Collapsed;
            ResetUnitChoicePanel();
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Visible;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveStudent.Visibility = Visibility.Collapsed;
        }
        private void listViewItem3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordPanel();
            ResetUnitChoicePanel();
            GridSTUDENTS.Visibility = Visibility.Collapsed;
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Visible;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveStudent.Visibility = Visibility.Collapsed;
        }
        private void listViewItem4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ResetPasswordPanel();
            ResetUnitChoicePanel();
            GridSTUDENTS.Visibility = Visibility.Collapsed;
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Visible;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridRemoveStudent.Visibility = Visibility.Collapsed;
        }
        private void listViewItem5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetUnitChoicePanel();
            GridSTUDENTS.Visibility = Visibility.Collapsed;
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Visible;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveStudent.Visibility = Visibility.Collapsed;
        }

        private void listViewItem6_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MasterList
            GridSTUDENTS.Visibility = Visibility.Collapsed;
            ResetUnitChoicePanel();
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Visible;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed; GridRemoveStudent.Visibility = Visibility.Collapsed;
        }
        private void listViewItem7_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResetUnitChoicePanel();
            GridSTUDENTS.Visibility = Visibility.Visible;
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveStudent.Visibility = Visibility.Collapsed;
        }
        private void listViewItem8_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            GridSTUDENTS.Visibility = Visibility.Collapsed;
            ResetUnitChoicePanel();
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Visible;
            GridArrow.Visibility = Visibility.Collapsed;
            GridRemoveStudent.Visibility = Visibility.Collapsed;
        }
        private void listViewItem9_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridRemoveStudent.Visibility = Visibility.Visible;
            GridSTUDENTS.Visibility = Visibility.Collapsed;
            ResetUnitChoicePanel();
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridMASTERLIST.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
            GridArrow.Visibility = Visibility.Collapsed;
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

        private void btnUnitChoice_Click(object sender, RoutedEventArgs e)
        {
            if (UnitChoiceStateMsg.Visibility == Visibility.Visible)
            {
                UnitChoiceStateMsg.Visibility = Visibility.Collapsed;
            }
            MyBlureEffectLoading();
            UnitChoiceStateMsg.Visibility = Visibility.Visible;
            //TODO: RESULTS OF CHANGING STATE OF THE UNIT CHOICE WITH UI SHOULD BE SET
        }

        private void btn_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            MyBlureEffectLoading();
            //TODO: RESULTS OF CHANGING PASSWORD WITH UI SHOULD BE SET
        }

        private void btn_DeleteCourse_Click(object sender, RoutedEventArgs e)
        {

            MyBlureEffectLoading();
            //TODO: RESULTS OF DELETINGCOURSE PASSWORD WITH UI SHOULD BE SET
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            MyBlureEffectLoading();
            //TODO: RESULTS OF CREATING NEW USER WITH UI SHOULD BE SET
        }

        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            MyBlureEffectLoading();
            //TODO: RESULTS OF CREATING NEW Course WITH UI SHOULD BE SET
        }

        private void btnPassTheTerm_Click(object sender, RoutedEventArgs e)
        {
            Interface.passTerm();
            MyBlureEffectLoading();
        }

        private void btnNotPassTheTerm_Click(object sender, RoutedEventArgs e)
        {
            GridCreateNewUser.Visibility = Visibility.Collapsed;
            GridCreateNewCourse.Visibility = Visibility.Collapsed;
            GridRemoveUserCompletely.Visibility = Visibility.Collapsed;
            GridRemoveCourse.Visibility = Visibility.Collapsed;
            GridControllingUnitChoosing.Visibility = Visibility.Collapsed;
            GridChangePassword.Visibility = Visibility.Collapsed;
            GridFinishTerm.Visibility = Visibility.Collapsed;
        }

        private void btn_DeleteStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_changeManagerPassword_Click(object sender, RoutedEventArgs e)
        {

            MyBlureEffectLoading();
            //TODO: RESULTS OF CHANGING PASSWORD WITH UI SHOULD BE SET

        }

        private void btnReloadStudentsList_Click(object sender, RoutedEventArgs e)
        {
           List<StudentObject> students = Interface.getAllStudents();



        }
    }
}