using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pilot_Contact_Local.Model;
using Pilot_Contact_Local.Service;

namespace Pilot_Contact_Local.View
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window
    {
        List<Person> personList;

        public MainView()
        {
            InitializeComponent();

            // set window position
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            personList = new List<Person>();
            personList = ContactService.GetAllPeople();

            contactList.ItemsSource = personList;
        }


        // show add. window
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddPerson addPerson = new AddPerson();
            addPerson.Owner = this;

            // make modalless or modal
            // addPerson.Show();
            if (addPerson.ShowDialog() == true) { }
        }

        private void contactList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var list = sender as ListView;
            var cellValue = list.SelectedValue;

            tbName.Text = ((Person)cellValue).Name;
            tbEmail.Text = ((Person)cellValue).Email;
            tbMobilePhone.Text = ((Person)cellValue).MobilePhone;
            tbTelePhone.Text = ((Person)cellValue).TelePhone;
            tbFaxNumber.Text = ((Person)cellValue).FaxNumber;
            tbAddress.Text = ((Person)cellValue).Address;
            tbMemo.Text = ((Person)cellValue).Memo;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            personList = new List<Person>();
            personList = ContactService.GetAllPeople();

            contactList.ItemsSource = personList;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            ;
        }
    }
}
