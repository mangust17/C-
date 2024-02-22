using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ClassLibrary1
{
    public class Note
    {
        private string FIO_;
        private string phoneNumber;
        public virtual string Email { get; set; }

        public string FIO
        {
            get { return FIO_; }
            set { FIO_ = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public virtual void display()
        {
            Console.WriteLine(FIO + " " + PhoneNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Note otherNote = (Note)obj;
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 1;
                result = (result * FIO.GetHashCode()) ^ 10;
                result = (result * PhoneNumber.GetHashCode()) ^ 100;
                return result;
            }
        }

        public Note() { }
        
        public Note(string fio, string phoneNumber_)
        {
            FIO_ = fio;
            PhoneNumber = phoneNumber_;
        }
    }

    public class Friend : Note
    {
        private DateTime birthdayDate;
        public override string Email { get; set; }


        public DateTime BirthdayDate
        {
            get { return birthdayDate; }
            set { birthdayDate = value; }
        }
        public override void display()
        {
            Console.WriteLine(FIO + " " + PhoneNumber + " " + Email + " " + BirthdayDate.ToString("dd.MM.yyyy"));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (!base.Equals(obj))
            {
                return false;
            }

            Friend otherFriend = (Friend)obj;
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 1;
                result = (result * FIO.GetHashCode()) ^ 10;
                result = (result * PhoneNumber.GetHashCode()) ^ 100;
                result = (result * BirthdayDate.GetHashCode()) ^ 1000;
                result = (result * Email.GetHashCode()) ^ 10000;
                return result;
            }
        }

        public Friend() { }

        public Friend(string fio, string phoneNumber_, string email_, DateTime birthdayDate_) : base(fio, phoneNumber_)
        {
            Email = email_;
            BirthdayDate = birthdayDate_;
        }
    }

    public class AddressBook
    {
        private List<Note> notes;

        private bool NoteExistsFIO(string fio)
        {
            return notes.Any(note => note.FIO == fio);
        }

        private bool NoteExistsPhoneNum(string number)
        {
            return notes.Any(note => note.PhoneNumber == number);
        }
        private bool NoteExistsEmail(string email)
        {
            return notes.Any(note => note.Email == email);
        }

        public void AddNote(Note note)
        {
            try
            {
                if (NoteExistsFIO(note.FIO))
                {
                    throw new Exception("Запись с таким именем уже существует.");
                }

                if (NoteExistsPhoneNum(note.PhoneNumber))
                {
                    throw new Exception("Запись с таким номером телефона уже существует.");
                }

                if (NoteExistsEmail(note.Email))
                {
                    throw new Exception("Запись с таким email уже существует.");
                }

                if (!IsValidEmail(note.Email))
                {
                    throw new Exception("Адресс электронной почты не валиден.");
                }

                notes.Add(note);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RemoveNote(Note note)
        {
            try
            {
                if (!NoteExistsFIO(note.FIO))
                {
                    throw new Exception("Запись не найдена.");
                }

                notes.Remove(note);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DisplayAllNotes()
        {
            foreach (Note note in notes)
            {
                note.display();
            }
        }

        static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }


        public AddressBook()
        {
            notes = new List<Note>();
        }
    }

}