using System;
using MySql.Data.MySqlClient;

namespace StudentRecord
{
    public class Menu
    {
        static string connectionString = "server=localhost;user=root;database=studentmanagementdb;port=3306;password=sqlpassword";
        static MySqlConnection conny = new MySqlConnection(connectionString);
        StudentRepository studentRepo = new StudentRepository(conny);
        private void StudentMenu()
        {
            
            Console.WriteLine("1. Add Student Information");
            Console.WriteLine("2. Find Student InformationBy E-Mail");
            Console.WriteLine("3. List all E-Mails");
            Console.WriteLine("4. Update Student Information");
            Console.WriteLine("5. Delete Student Information");
            Console.WriteLine("6. Check Number of Student greater than 18");
            Console.WriteLine("7. Print Information of Students in Jss1");
            Console.WriteLine("0. Exit");
        }
        private void AddStudentInfo()
        {
            Console.Write("Enter Student First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Student last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Student E-Mail: ");
            string email = Console.ReadLine();

            Console.Write("Enter Student Phone-No: ");
            string phoneNo = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Class: ");
            string studentClass = Console.ReadLine().ToLower();

            studentRepo.AddStudentInfo(firstName, lastName, email, phoneNo, age, studentClass);
        }
        private void UpdateStudent()
        {
            Console.Write("Enter E-Mail of student you want to update: ");
            string email = Console.ReadLine();

            Console.Write("Update Student First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Update Student Age: ");
            int age = int.Parse(Console.ReadLine());

            studentRepo.UpdateStudentInfo(firstName, email,  age);
        }
        private void DeleteStudent()
        {
            Console.Write("Enter Last Name of Student you want to Delete: ");
            string lastName = Console.ReadLine();
            studentRepo.DeleteStudent(lastName);
        }
        public void MainMenu()
        {
            StudentMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddStudentInfo();
                    MainMenu();
                    break;
                case "2":
                    Console.Write("Enter E-mail of the Student you want to Find: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("");
                    studentRepo.FindStudent(email);
                    MainMenu();
                    break;
                case "3":
                    studentRepo.ListAllEmails();
                    MainMenu();
                    break;
                case "4":
                    UpdateStudent();
                    MainMenu();
                    break;
                case "5":
                    DeleteStudent();
                    MainMenu();
                    break;
                case "6":
                    studentRepo.StudentAbove18Years();
                    MainMenu();
                    break;
                case "7":
                    studentRepo.ListOfJss1Students();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}