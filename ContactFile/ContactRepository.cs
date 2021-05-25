using System;
using System.Collections.Generic;
using System.IO;

namespace ContactFile
{
    public class ContactRepositry
    {
        ContactRepositry ccontactRepo = new ContactRepositry();
        public List<Contact> Contacts = new List<Contact>();

        public ContactRepositry()
        {
            FetchContactInfoFromFile();
        }

        public void FetchContactInfoFromFile()
        {
            try
            {
                var contactInfoLines = File.ReadAllLines("Files//MyContact.txt");
                foreach (var contactInfoLiness in contactInfoLines)
                {
                    var student = Contact.StringToContactRep(contactInfoLiness);
                    Contacts.Add(student);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintContactInfo(Contact contact)
        {
            Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, Phone Number: {contact.PhoneNumber}, OfficeAddress: {contact.OfficeAddress} ");
        }

        public void GetContactInfo()
        {
            foreach (Contact student in Contacts)
            {
                PrintContactInfo(student);
            }
        }

        // public List<Student> ListStudentInfo()
        // {
        //     return contacts;
        // }

        public void AddContactDetails(int id, string name, string email, string phoneNumber, string officeaddress)
        {
            var contactExist = FindContactByEmail(email);

            if (contactExist != null)
            {
                Console.WriteLine($"stock with {email} already exist");
            }

            Contact contact = new Contact(id, name, email, phoneNumber, officeaddress);

            Contacts.Add(contact);

            TextWriter writer = new StreamWriter("Files//MyContact.txt", true);
            writer.WriteLine(contact.ToString());
            Console.WriteLine("Student Info added successfully!");
            writer.Close();
        }

        // public void UpdateStock(string firstName, string lastName, string email, string phoneNumber, int age, string studentClass)
        // {
        //     var student = FindContactByEmail(email);
        //     if (student == null)
        //     {
        //         Console.WriteLine($"Student with {email} does not exist");
        //     }

        //     student.FirstName = firstName;
        //     RefreshFile();
        // }

        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("Files//MyContact.txt");
            foreach (var student in Contacts)
            {
                writer.WriteLine(student);
            }
            writer.Flush();
            writer.Close();
        }

        public void DeleteContact(string lastName)
        {
            // var student = FindStudentByLastName(lastName);
            // if (student == null)
            // {
            //     Console.WriteLine($"Student with {lastName} does not exist");
            // }

            Contacts.RemoveAll(student => student.Name == lastName);
            RefreshFile();
        }

        public Contact FindContactByEmail(string email)
        {
            return Contacts.Find(s => s.Email == email);
        }

        // public List<Student> FindStudentByLastName(string lastName)
        // {
        //     return contacts.FindAll(s => s.LastName == lastName);
        // }

        public void FindStudent()
        {
            Console.WriteLine("Enter the email of the Contact you want to find: ");
            string email = Console.ReadLine();

            var contact = FindContactByEmail(email);

            if (contact == null)
            {
                Console.WriteLine($"Contact with Email: \t {email} does not exist! ");
            }

            else
            {
                Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, Phone Number: {contact.PhoneNumber}, OfficeAddress: {contact.OfficeAddress}  ");
            }
        }
        public void ListAllEmails()
        {
            //var studentInfoLines = File.ReadAllLines("Files//student.txt");
            foreach (var contact in Contacts)
            {
                Console.WriteLine($"Email: {contact.Email} ");
            }
            if (Contacts == null)
            {
                Console.Write("Empty");
            }

        }

        public void ListAllAges()
        {
            List<Contact> contacts = new List<Contact>();
            {
                int count = 0;
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"Age:  {contacts[2]}");
                    count++;
                }

                Console.WriteLine($"Number of contacts with ages greater than 18 is {count}. ");
            }
        }

        // public void ListAllStudentInJss1()
        // {
        //     List<Contact> contacts = new List<Contact>();

        //     foreach (var student in contacts)
        //     {
        //         if (student.Class == "jss1")
        //         {
        //             Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Email + " " + student.PhoneNumber + " " + student.Age + " " + student.Class);
        //         }
        //         else
        //         {
        //             Console.WriteLine("Not Exist");
        //         }

        //     }

        // }
        public void UpdateContact(string name, string email, string officeaddress)
        {
            var student = FindContactByEmail(email);

            if (student == null)
            {
                Console.WriteLine($"Contact with {email} does not exist");
            }
            else
            {
                foreach (var studenti in Contacts)
                {
                    studenti.Name = name;
                    studenti.OfficeAddress = officeaddress;
                }
            }
        }
    }
}