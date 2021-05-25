using System;

namespace StudentRecord
{
    public class StudentEntity
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int Age { get; set; }
        public string StudentClass { get; set; }
        public StudentEntity(string firstName, string lastName, string eMail, string phoneNo, int age, string studentClass)
        {
            FirstName = firstName;
            LastName =  lastName;
            Email = eMail;
            PhoneNo = phoneNo;
            Age = age;
            StudentClass =studentClass;
        }
    }
}