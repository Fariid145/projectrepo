using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace StudentRecord
{
    public class StudentRepository
    {
        MySqlConnection conny;
        public static List<StudentEntity> Students = new List<StudentEntity>();
        public StudentRepository(MySqlConnection connection)
        {
            conny = connection;
        }
        public bool AddStudentInfo(string firstName, string lastName, string  email, string phoneNo, int age, string studentClass)
        {
            try
            {
                conny.Open();
                string addStudentInfo = "Insert into student (FirstName, LastName, Email, PhoneNumber, Age, Class)values ('" + firstName + "', '" + lastName + "', '" +  email + "', '" + phoneNo + "', '" + age + "', '" + studentClass + "')";
                MySqlCommand command = new MySqlCommand(addStudentInfo, conny);
                Console.WriteLine("Student Information Added Sucessfully!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conny.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conny.Close();
            return false;
        }
        public StudentEntity FindStudent(string  email)
        {
            StudentEntity student = null;
            try
            {
                conny.Open();
                string studentSql = "Select FirstName, LastName, Email, PhoneNumber, Age, Class from student where Email = '" +  email + "'";
                MySqlCommand command = new MySqlCommand(studentSql, conny);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        string firstName = reader.GetString(0);
                        string lastName = reader.GetString(1);
                        string phoneNo = reader.GetString(3);
                        int age = reader.GetInt32(4);
                        string studentClass = reader.GetString(5);
                        student = new StudentEntity(firstName, lastName, email, phoneNo, age, studentClass);
                    }
                    Console.WriteLine($"Student First Name: {reader[0]}  Student Last Name: {reader[1]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conny.Close();
            return student;
        }
        public void ListAllEmails()
        {
            List<StudentEntity> students = new List<StudentEntity>();
            try
            {
                conny.Open();
                string studentSql = "Select FirstName, LastName, Email, PhoneNumber, Age, Class from student";
                MySqlCommand command = new MySqlCommand(studentSql, conny);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[2]);
                }
                reader.Close();
                conny.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool UpdateStudentInfo(string firstName, string email, int age)
        {
            var student = FindStudent(email);
            if (student == null)
            {
                Console.WriteLine($"Student with {email} does not exist");
            }
            try
            {
                conny.Open();
                string updateStudentSql = "update student set FirstName ='" + firstName + "', Age = '" + age + "' where Email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(updateStudentSql, conny);
                Console.WriteLine("Student Update Sucessful!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conny.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conny.Close();
            return false;
        }
        public bool DeleteStudent(string lastName)
        {
            if (lastName == null)
            {
                Console.WriteLine($"student with Last Name: {lastName} does not exist");
            }
            try
            {
                conny.Open();
                string deleteStudentSql = "delete from student where LastName = '" + lastName + "'";
                Console.WriteLine("Student Information Deleted Sucessfully!");
                MySqlCommand command = new MySqlCommand(deleteStudentSql, conny);
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conny.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conny.Close();
            return false;
        }
        public void StudentAbove18Years()
        {
            int noOfStudentsOlderThan18 = 0;
            try
            {
                conny.Open();
                string studentQuery = "select Age from student where Age > 18";
                MySqlCommand command = new MySqlCommand(studentQuery, conny);
                MySqlDataReader reader = command.ExecuteReader();  
                while (reader.Read())
                {
                    noOfStudentsOlderThan18++;
                }
                Console.WriteLine($"No. of people greater than 18years = {noOfStudentsOlderThan18}");
                reader.Close();
                conny.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conny.Close();
        }
        public void ListOfJss1Students()
        {
            try
            {
                conny.Open();
                string studentQuery = "Select FirstName, LastName, Email, PhoneNumber, Age, Class from student where Class = 'jss1';";
                MySqlCommand command = new MySqlCommand(studentQuery, conny);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"First Name: {reader[0]}, Last Name: {reader[1]}, E-mail: {reader[2]}, Phone No.: {reader[3]}, Age: {reader[4]}, Class {reader[5]}");
                }
                reader.Close();
                conny.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conny.Close();
        }
    }
}