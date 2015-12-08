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
using Pilot_Contact_Local.ViewModel;
using Pilot_Contact_Local.Service;

namespace Pilot_Contact_Local.View
{
    /// <summary>
    /// AddPerson.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddPerson : Window
    {
        public AddPerson()
        {
            InitializeComponent();

            // set window position
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddViewModel addViewModel = FindResource("addViewModel") as AddViewModel;
            addViewModel.AddPersonToContact();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
