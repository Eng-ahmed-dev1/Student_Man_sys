using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Student_Gradebook.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Gradebook
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Std(object sender, RoutedEventArgs e)
        {
            // Insert the Students and Subjects 
            try
            {
                using var context = new StudentsDB();
                string StdName = Std_Name.Text.Trim();
                if (string.IsNullOrEmpty(StdName) || string.IsNullOrWhiteSpace(StdName))
                {
                    MessageBox.Show("Please Enter Student Name");
                    return;
                }
                string StdSubject = Std_Sub.Text.Trim();
                if (string.IsNullOrEmpty(StdSubject) || string.IsNullOrWhiteSpace(StdSubject))
                {
                    MessageBox.Show("Please Enter Subject Name ");
                    return;

                }
                if (!int.TryParse(Std_Grade.Text, out int StdGrade))
                {
                    MessageBox.Show("Enter the grade as number");
                    return;

                }
                var subject = context.Subjects.FirstOrDefault(s => s.Name == StdSubject);
                if (subject == null)
                {
                    subject = new Subject(StdSubject);
                    context.Subjects.Add(subject);
                }

                var student = context.Students.FirstOrDefault(s => s.Name == StdName);
                if (student == null)
                {
                    student = new Student(StdName, StdGrade);
                    context.Students.Add(student);
                }

                if (!student.Subjects.Contains(subject))
                {
                    student.Subjects.Add(subject);
                }

                context.SaveChanges();
                MessageBox.Show("Student and Subject saved successfully!");

                // Select the Student and The Subjects From DB


                var StdList = context.Students
                 .Include(s => s.Subjects)
                 .ToList();

                Screen.ItemsSource = StdList;



            }
            catch (Exception y)
            {
                MessageBox.Show(y.InnerException?.Message ?? y.Message);
            }
        }

        private void CalculateAverage(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new StudentsDB();
                var avgGrade = context.Students.Average(s => s.Grade);
                Screen.ItemsSource = new List<object>
                {       
                  new { StudentName = "All Students", Subject = "-", Grade = "-", Average = avgGrade }
                };

            }
            catch (Exception x)
            {
                MessageBox.Show(x.InnerException?.Message ?? x.Message);
            }
        }
    }
}