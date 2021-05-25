using System;
using MySql.Data.MySqlClient;

namespace ScoreListDataBase
{
    public class Menu
    {
        static string connectionString = "server=localhost;user=root;database=studentscoredb;port=3306;password=sqlpassword";
        static MySqlConnection conns = new MySqlConnection(connectionString);
        ScoreRepository scoreRepo = new ScoreRepository(conns);

         private void ShowMenu()
        {
            
            Console.WriteLine("1. Add Student Score");
            Console.WriteLine("2. List all Scores");
            Console.WriteLine("3. Find Student ");
            Console.WriteLine("4. Update Student Score");
            Console.WriteLine("5. Delete Student ");
            Console.WriteLine("6. Total Number of Student above Average");
            Console.WriteLine("7. Get Overall Best Student");
            Console.WriteLine("0. Back");
        }
         public void AddStudentScore()
        {
            Console.Write("Enter Student Full Name: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            Console.Write("English Score: ");
            int englishScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Math Score: ");
            int mathScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Economics Score: ");
            int economicScore = int.Parse(Console.ReadLine().Trim());

            scoreRepo.AddStudentScores(studentName, englishScore, mathScore, economicScore);
        }
        public void UpdateStudentScore()
        {
            Console.Write("Enter Full Name of Student you want to Update: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            Console.Write("Update English Score: ");
            int englishScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Update Math Score: ");
            int mathScore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Update Economics Score: ");
            int economicScore = int.Parse(Console.ReadLine().Trim());

            scoreRepo.UpdateScore(studentName, englishScore, mathScore, economicScore);
            scoreRepo.RefreshFile();
        }
        public void DeleteStudent()
        {
            Console.Write("Enter name of Student you want to Delete: ");
            string studentName = Console.ReadLine().ToLower().Trim();

            Console.Write("Are you sure you want to delete? (y/n) ");
            string option = Console.ReadLine().ToLower();

            if(option == "y")
            {
                scoreRepo.DeleteScoreByName(studentName);
            }

            else
            {
                ShowMenu();
            }
        }
        public void ShowScoreMenu()
        {
            ShowMenu();
            Console.Write("Enter Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                   AddStudentScore();
                    ShowScoreMenu();
                    break;
                case "2":
                    scoreRepo.GetScoreInfo();
                    ShowScoreMenu();
                    break;

                case "3":
                    scoreRepo.FindScore();
                    ShowScoreMenu();
                    break;

                case "4":
                    UpdateStudentScore();
                    ShowScoreMenu();
                    break;

                case "5":
                    DeleteStudent();
                    ShowScoreMenu();
                    break;
                case "6":
                    scoreRepo.NumberOfStudentsAboveAverage();
                    ShowScoreMenu();
                    break;
                    case "7":
                    scoreRepo.GetBestStudent();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }

    }
}