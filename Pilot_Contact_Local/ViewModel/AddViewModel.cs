using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pilot_Contact_Local.Model;
using Pilot_Contact_Local.Service;

namespace Pilot_Contact_Local.ViewModel
{
    public class AddViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string TelePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string Memo { get; set; }

        public void AddPersonToContact()
        {
            Person person = new Person(Name, Email, MobilePhone, TelePhone, FaxNumber, Address, Memo);
            ContactService.AddPersonToDB(person);
        }
    }
}