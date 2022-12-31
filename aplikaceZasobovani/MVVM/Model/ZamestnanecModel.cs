using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.MVVM.Model
{
    internal class ZamestnanecModel
    {
    }
    internal class Zamestnanec : INotifyPropertyChanged
    {
        public ObjectId ZamestnanecId { get; set; }
        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; RaisePropertyChanged(nameof(FirstName)); } }
        private string lastName;
        public string LastName { get { return lastName; } set { lastName = value; RaisePropertyChanged(nameof(LastName)); } }
        private int age;
        public int Age { get { return age; } set { age = value; RaisePropertyChanged(nameof(Age)); } }
        private string email;
        public string Email { get { return email; } set { email = value; RaisePropertyChanged(nameof(Email)); } }
        private string skladId;
        public String SkladId { get { return skladId; } set { skladId = value; RaisePropertyChanged(nameof(SkladId)); } }

        public Zamestnanec(string firstName, string lastName, int age, string email, String skladId)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            SkladId = skladId;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
};