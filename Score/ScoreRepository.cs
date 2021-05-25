using System;
using System.Collections.Generic;
using System.IO;

namespace ScoreRecord
{
    public class ScoreRepository
    {
        public List<ScoreEntity> Scores = new List<ScoreEntity>();

        public ScoreRepository()
        {
            FetchScoreInfoFromFile();
        }

        public void FetchScoreInfoFromFile()
        {
            try
            {
                var scoreInfoLines = File.ReadAllLines("ScoreList.txt");
                foreach (var scoreInfoLine in scoreInfoLines)
                {
                    var Grade = ScoreEntity.StringToScoreEntity(scoreInfoLine);
                    Scores.Add(Grade);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetScoreInfo()
        {
            foreach (var Grade in Scores)
            {
                Console.WriteLine($" Name: {Grade.Name}, English Grade: {Grade.EnglishGrade}, Maths Grade: {Grade.MathGrade}, Economics Grade: {Grade.EconomicGrade}");
            }
        }
        public List<ScoreEntity> ListScoreInfo()
        {
            return Scores;
        }

        public void AddStudentScores(string name, int englishGrade, int mathGrade, int economicGrade)
        {
            var scoreExist = FindScoreByName(name);

            if (scoreExist != null)
            {
                Console.WriteLine($"Student with Name: {name} does not exist! ");
            }
            else
            {
                ScoreEntity Grade = new ScoreEntity(name, englishGrade, mathGrade, economicGrade);

                Scores.Add(Grade);

                TextWriter writer = new StreamWriter("ScoreList.txt", true);
                writer.WriteLine(Grade.ToString());
                Console.WriteLine("Student score added successfully!");
                writer.Close();
            }
        }
        public void DeleteScoreByName(string name)
        {
            Scores.RemoveAll(score => score.Name == name);
            RefreshFile();
            Console.WriteLine("Student Record Deleted Sucessfully!!");
        }
        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("ScoreList.txt");
            foreach (var Grade in Scores)
            {
                writer.WriteLine(Grade);
            }
            writer.Flush();
            writer.Close();
        }
        public ScoreEntity FindScoreByName(string name)
        {
            return Scores.Find(s => s.Name == name);
        }
        public void FindScore()
        {
            Console.Write("Enter Full Name of the Student you want to Find: ");
            string name = Console.ReadLine().ToLower().Trim();

            var Grade = FindScoreByName(name);

            if (Grade == null)
            {
                Console.WriteLine($"Student with Name: {name} does not exist! ");
            }

            else
            {
                Console.WriteLine($"Name: {Grade.Name}, English Grade: {Grade.EnglishGrade}, Maths Grade: {Grade.MathGrade}, Economics Grade: {Grade.EconomicGrade}");
            }
        }
        public void UpdateScore(string name, int englishGrade, int mathGrade, int economicGrade)
        {
            var Grade = FindScoreByName(name);

            if (Grade == null)
            {
                Console.WriteLine($"Student with Name: {name} does not exist! ");
            }
            else
            {
                Grade.EnglishGrade = englishGrade;
                Grade.MathGrade = mathGrade;
                Grade.EconomicGrade = economicGrade;
                Console.WriteLine("Grade Updated Sucessfully!!");
            }
        }
        public void NumberOfStudentsAboveAverage()
        {
            int Balance = 0;
            foreach (var Grade in Scores)
            {
                if (Grade.EnglishGrade + Grade.MathGrade + Grade.EconomicGrade > 100)
                {
                    Balance++;
                }
                
            }
            Console.WriteLine($"The number of Students that  their score is above average is: {Balance}");
        }

        public void BestOverallStudent()
        {
            List<int> TotalGrades = new List<int>();

            foreach (var Grade in Scores)
            {
                int totalGrade = Grade.EnglishGrade + Grade.MathGrade + Grade.EconomicGrade;
                TotalGrades.Add(totalGrade);
            }

            int bestStudent = TotalGrades[0];

            for (int i = 0; i < TotalGrades.Count; i++)
            {
                if (TotalGrades[i] >= bestStudent)
                {
                    bestStudent = TotalGrades[i];
                }
            }

            foreach (var Grade in Scores)
            {
                if(bestStudent == Grade.EnglishGrade + Grade.MathGrade + Grade.EconomicGrade)
                {
                    Console.WriteLine($"The name of Student with the best score is: {Grade.Name}");
                }
            }
        }
    }
}
