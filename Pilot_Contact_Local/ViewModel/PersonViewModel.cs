using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pilot_Contact_Local.Service;
using Pilot_Contact_Local.Model;

namespace Pilot_Contact_Local.ViewModel
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string TelePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string Memo { get; set; }

        private List<Person> _people;
        public List<Person> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonViewModel()
        {
            this.Init();
        }

        private void Init()
        {
            this._people = ContactService.GetAllPeople();
        }
       
        
    }
}
