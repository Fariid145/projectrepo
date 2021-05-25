using System;


namespace ContactFile
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string OfficeAddress { get; set; }


        public Contact(int id, string name, string email, string phoneNumber, string officeaddress)
        {
            this.Id = id;

            this.Name = name;

            this.Email = email;

            this.PhoneNumber = phoneNumber;

            this.OfficeAddress = officeaddress;

        }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Email}\t{PhoneNumber}\t{OfficeAddress} ";
        }

        internal static Contact StringToContactRep(string studentString)
        {
            var props = studentString.Split("\t");

            int id = int.Parse(props[0]);

            return new Contact(id, props[1], props[2], props[3], props[4]);
        }
        
    }
}