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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GradesPrototype.Data;
using GradesPrototype.Services;

namespace GradesPrototype.Views
{
    /// <summary>
    /// Interaction logic for LogonPage.xaml
    /// </summary>
    public partial class LogonPage : UserControl
    {
        public LogonPage()
        {
            InitializeComponent();
        }

        #region Event Members
        public event EventHandler LogonSuccess;
        // TODO: Exercise 3: Task 1a: Define LogonFailed event
        public event EventHandler LogonFailed;

        #endregion

        #region Logon Validation

        // TODO: Exercise 3: Task 1b: Validate the username and password against the Users collection in the MainWindow window
        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacherFind =
                (from Teacher teacher in DataSource.Teachers
                where string.Compare(teacher.UserName, username.Text) == 0 &&
                      string.Compare(teacher.Password, password.Password) == 0
                select teacher).FirstOrDefault();

            if (!string.IsNullOrEmpty(teacherFind.UserName))
            {
                SessionContext.UserID = teacherFind.TeacherID;
                SessionContext.UserRole = Role.Teacher;
                SessionContext.UserName = teacherFind.UserName;
                SessionContext.CurrentTeacher = teacherFind;

                LogonSuccess(true, null);
            } else
            {
                Student studentFind =
                (from Student student in DataSource.Students
                 where string.Compare(student.UserName, username.Text) == 0 &&
                       string.Compare(student.Password, password.Password) == 0
                 select student).FirstOrDefault();

                if (!string.IsNullOrEmpty(studentFind.UserName))
                {
                    SessionContext.UserID = studentFind.TeacherID;
                    SessionContext.UserRole = Role.Student;
                    SessionContext.UserName = studentFind.UserName;
                    SessionContext.CurrentStudent = studentFind;

                    LogonSuccess(true, null);
                } else
                {
                    LogonFailed(true, null);
                }
            }
        }
        #endregion
    }
}
