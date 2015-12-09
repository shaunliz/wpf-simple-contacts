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
using Microsoft.Office.Interop.Excel;

namespace Pilot_Contact_Local.View
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : System.Windows.Window
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

        private void btnSaveToExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.CreatePrompt = true;
            saveFileDialog.OverwritePrompt = true;

            saveFileDialog.DefaultExt = "*.xls";
            saveFileDialog.Filter = "Excel Files (*.xls)|*.xls";
            //saveFileDialog.InitialDirectory = "C:\\";
            // 내문서 위치로
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 

            if(saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    object missingType = Type.Missing;
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add(missingType);
                    Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.Add(missingType, missingType, missingType, missingType);
                    excelApp.Visible = false;

                    // 내용 저장
                    // excelWorksheet.Cells[1, 2] = "TEST";

                    /* Title 정리 */
                    excelWorksheet.Cells[1, 1] = "ID";
                    excelWorksheet.Cells[1, 2] = "Name";
                    excelWorksheet.Cells[1, 3] = "Email";
                    excelWorksheet.Cells[1, 4] = "Mobile Phone";
                    excelWorksheet.Cells[1, 5] = "Telephone";
                    excelWorksheet.Cells[1, 6] = "Fax.";
                    excelWorksheet.Cells[1, 7] = "Address";
                    excelWorksheet.Cells[1, 8] = "Memo";

                    for (int i = 0; i < personList.Count; i++ )
                    {
                        excelWorksheet.Cells[2 + i, 1] = personList[i].Id.ToString();
                        excelWorksheet.Cells[2 + i, 2] = personList[i].Name;
                        excelWorksheet.Cells[2 + i, 3] = personList[i].Email;
                        excelWorksheet.Cells[2 + i, 4] = personList[i].MobilePhone;
                        excelWorksheet.Cells[2 + i, 5] = personList[i].TelePhone;
                        excelWorksheet.Cells[2 + i, 6] = personList[i].FaxNumber;
                        excelWorksheet.Cells[2 + i, 7] = personList[i].Address;
                        excelWorksheet.Cells[2 + i, 8] = personList[i].Memo;

                    }

                    excelBook.SaveAs(@saveFileDialog.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                        missingType, missingType, missingType, missingType, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        missingType, missingType, missingType, missingType, missingType);

                    excelApp.Visible = true;

                    excelBook.Close(missingType, missingType, missingType);
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelBook);

                }
                catch 
                {
                    ;
                }
            }
        }

        #region 메모리해제
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion


    }
}
