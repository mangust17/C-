using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibrary1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            Friend friend1 = new Friend("Antony Zorikov", "123456789", "Antony@example.com", new DateTime(2005, 9, 12));
            Friend friend2 = new Friend("Matvey Leiko", "987654321", "Matvey@example.com", new DateTime(2005, 11, 17));
            Friend friend3 = new Friend("Karl Zorikov", "223456789", "Karl@example.com", new DateTime(2005, 9, 12));

            

            addressBook.AddNote(friend1);
            addressBook.AddNote(friend2);
            addressBook.AddNote(friend3);

            addressBook.DisplayAllNotes();
            Console.WriteLine(" ");
            //******************************//
            addressBook = new AddressBook();
            friend1 = new Friend("Antony Zorikov", "123456789", "Antony@example.com", new DateTime(2005, 9, 12));
            friend2 = new Friend("Matvey Leiko", "987654321", "Matvey@example.com", new DateTime(2005, 11, 17));
            friend3 = new Friend("Antony Zorikov", "223456789", "Karl@example.com", new DateTime(2005, 9, 12));


            addressBook.AddNote(friend1);
            addressBook.AddNote(friend2);
            addressBook.AddNote(friend3);

            addressBook.DisplayAllNotes();
            Console.WriteLine(" ");
            //******************************//
            addressBook = new AddressBook();
            friend1 = new Friend("Antony Zorikov", "123456789", "Antony@example.com", new DateTime(2005, 9, 12));
            friend2 = new Friend("Matvey Leiko", "987654321", "Matvey@example.com", new DateTime(2005, 11, 17));
            friend3 = new Friend("Karl Zorikov", "123456789", "Karl@example.com", new DateTime(2005, 9, 12));


            addressBook.AddNote(friend1);
            addressBook.AddNote(friend2);
            addressBook.AddNote(friend3);

            addressBook.DisplayAllNotes();
            Console.WriteLine(" ");
            //******************************//
            addressBook = new AddressBook();
            friend1 = new Friend("Antony Zorikov", "123456789", "Antony@example.com", new DateTime(2005, 9, 12));
            friend2 = new Friend("Matvey Leiko", "987654321", "Matvey@example.com", new DateTime(2005, 11, 17));
            friend3 = new Friend("Karl Zorikov", "223456789", "Antony@example.com", new DateTime(2005, 9, 12));


            addressBook.AddNote(friend1);
            addressBook.AddNote(friend2);
            addressBook.AddNote(friend3);

            addressBook.DisplayAllNotes();
            Console.WriteLine(" ");
            //******************************//
            addressBook = new AddressBook();
            friend1 = new Friend("Antony Zorikov", "123456789", "Antony@example.com", new DateTime(2005, 9, 12));
            friend2 = new Friend("Matvey Leiko", "987654321", "Matvey@example.com", new DateTime(2005, 11, 17));
            friend3 = new Friend("Karl Zorikov", "223456789", "Antony@example.com", new DateTime(2005, 9, 12));


            addressBook.AddNote(friend1);
            addressBook.AddNote(friend2);
            addressBook.AddNote(friend3);

            addressBook.DisplayAllNotes();
            Console.WriteLine(" ");
            //addressBook.RemoveNote(friend1);
            //Console.WriteLine(" ");
            //addressBook.DisplayAllNotes();
            //Console.WriteLine(" ");
            //addressBook.RemoveNote(friend1);
            //Console.WriteLine(friend1.GetHashCode() + " " + friend2.GetHashCode() + " " + friend3.GetHashCode() + " " + friend1.Equals(friend2) + " " + friend1.Equals(friend3));
            Console.ReadLine();
        }
    }
}
