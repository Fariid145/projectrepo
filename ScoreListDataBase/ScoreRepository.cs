using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ScoreListDataBase
{
    public class ScoreRepository
    {
         MySqlConnection conns;

        public static List<Score> Scores = new List<Score>();

          public ScoreRepository(MySqlConnection connection)
        {
            conns = connection;
        }
         public void AddStudentScores(string studentName, int englishScore, int mathScore, int economicScore)
        {
            try{
                conns.Open();
           string addStudentScore = "Insert into studentscore (StudentName, EnglishScore, MathsScore, EconsScore)values ('" + studentName + "', '" + englishScore + "', '" + mathScore + "', '" + economicScore+ "')";
                MySqlCommand command = new MySqlCommand(addStudentScore, conns);
                Console.WriteLine("Student Score Added Sucessfully!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conns.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conns.Close();
            return false;
        }
        public Score FindScore(string studentName)
        {
            Score score = null;
            try
            {
                conns.Open();
               string studentSql = "Select studentName, englishScore, mathScore, economicScore from studentscore where studentName = '" + studentName + "'";
                MySqlCommand command = new MySqlCommand(studentSql, conns);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                         int englishScore = reader.GetInt32(1);
                        int mathScore = reader.GetInt32(2);
                        int economicScore = reader.GetInt32(3);
                        studentScore = new Score(studentName, englishScore, mathScore, economicScore);
                    }
                    Console.WriteLine($"Student Name: {reader[0]}, English Score: {reader[1]}, Maths Score: {reader[2]}, Economics Score: {reader[3]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conns.Close();
            return studentScore;
        }
        public bool UpdateStudentScore(string studentName, int englishScore, int mathScore, int economicScore)
        {
            var student = FindStudentScore(studentName);
            if (student == null)
            {
                Console.WriteLine($"Student with Name: {studentName} does not exist");
            }
            try
            {
                conns.Open();
                string updateScoreQuery = "update studentscore set englishScore ='" + englishScore + "', mathScore = '" + mathScore + "' , economicScore = '" + economicScore + "' where studentName = '" + studentName + "'";
                MySqlCommand command = new MySqlCommand(updateScoreQuery, conns);
                int Count = command.ExecuteNonQuery();
                Console.WriteLine("Student Score Update Sucessful!");
                if (Count > 0)
                {
                    conns.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conns.Close();
            return false;
        }
        public bool DeleteStudentRecord(string studentName)
        {
            if (studentName == null)
            {
                Console.WriteLine($"Student with Name: {studentName} does not exist");
            }
            try
            {
                conns.Open();
                string deleteStudentQuery = "delete from studentscore where studentName = '" + studentName + "'";
                MySqlCommand command = new MySqlCommand(deleteStudentQuery, conns);
                Console.WriteLine("Student Record Deleted Sucessfully!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conns.Close();
            return false;
        }
        public void ListAllScores()
        {
            List<ScoreEntity> Scores = new List<ScoreEntity>();
            try
            {
                conn.Open();
                string scoreQuery = "Select studentName, englishScore, mathScore, economicScore from studentscore";
                MySqlCommand command = new MySqlCommand(scoreQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Student Name: {reader[0]}, English Score: {reader[1]}, Maths Score: {reader[2]}, Economics Score: {reader[3]}");
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void NumberOfStudentsAboveAverage()
        {
            List<ScoreEntity> Scores = new List<ScoreEntity>();
            try
            {
                int average =0;
                conn.Open();
                string scoreQuery = "Select studentName, englishScore, mathScore, economicScore from studentscore where englishScore+mathScore+economicScore > '" + 150 + "'";
                MySqlCommand command = new MySqlCommand(scoreQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    average++;
                }
                Console.WriteLine($"The number of Students that have their total score above average is: {average}");
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}