using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot_Contact_Local.Model
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string TelePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }

        public UserInfo() { }

        public UserInfo(string name, string email, string mobilephone,
            string telephone, string faxnumber, string address)
        {
            Name = name;
            Email = email;
            MobilePhone = mobilephone;
            TelePhone = telephone;
            FaxNumber = faxnumber;
            Address = address;
        }

        public UserInfo(int id, string name, string email, string mobilephone, 
            string telephone, string faxnumber, string address)
        {
            Id = id;
            Name = name;
            Email = email;
            MobilePhone = mobilephone;
            TelePhone = telephone;
            FaxNumber = faxnumber;
            Address = address;
        }
    }
}
