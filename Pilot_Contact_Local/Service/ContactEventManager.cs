using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOT USED
namespace Pilot_Contact_Local.Service
{
    public delegate void ListUpdateEventHandler();

    class ContactEventManager
    {
        public event ListUpdateEventHandler ListUpdate;

        public void DoListUpdate()
        {
            ;
        }
    }
}
