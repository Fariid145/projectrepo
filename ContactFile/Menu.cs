using System;

namespace ContactFile
{
    public class Menu
    {
        static ContactRepositry contactrepo = new ContactRepositry();

        private void ShowMenu()
        {
            
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Find Contact by email");
            Console.WriteLine("3. List Contact emails");
            Console.WriteLine("4. Update Contact Info");
            Console.WriteLine("5. Delete Contact Info");
            Console.WriteLine("0. Back");
        }

        public void AddStudentDetails()
        {
            Console.Write("Enter your Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();

            contactrepo.AddContactDetails(id, name, email, phoneNumber, address);
        }

        public void UpdateContactDetails()
        {
            Console.Write("Enter email of Contact : ");
            string email = Console.ReadLine();

            Console.Write("Update Contact Name: ");
            string name = Console.ReadLine();

            Console.Write("Update Contct Age: ");
            string address = Console.ReadLine();

            contactrepo.UpdateContact(name, email, address);
            contactrepo.RefreshFile();
        }

        public void DeleteContact()
        {
            Console.Write("Enter last name of Contact you want to delete: ");
            string name = Console.ReadLine();

            Console.Write("Are you sure you want to delete? ");
            string option = Console.ReadLine();

            if (option == "yes")
            {
                contactrepo.DeleteContact(name);

                Console.WriteLine($"{name} deleted successfully! ");
            }

            else
            {
                ShowMenu();
            }
       }
        public void ShowContactMenu()
        {
            ShowMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddStudentDetails();
                    ShowContactMenu();
                    break;
                case "2":
                    contactrepo.FindStudent();
                    ShowContactMenu();
                    break;

                case "3":
                    contactrepo.ListAllEmails();
                    ShowContactMenu();
                    break;

                case "4":
                    UpdateContactDetails();
                    ShowContactMenu();
                    break;

                case "5":
                    DeleteContact();
                    ShowContactMenu();
                    break;

                // case "6":
                //     Search();
                //     ShowContactMenu();
                //     break;

            
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }

        // public void Search(Contact cont)
        // {
        //     Contact con = new Contact();

        //     Console.WriteLine("Enter a String");
        //     string Strings = Console.ReadLine();

        //     if(Strings == con.Name || Strings == con.Email || Strings == con.OfficeAddress)
        //     {
        //         Console.WriteLine($"Id: {cont.Id}, Name: {cont.Name}, Email: {cont.Email}, Phone Number: {cont.PhoneNumber}, OfficeAddress: {cont.OfficeAddress}");
        //     }
        // }

    }
}