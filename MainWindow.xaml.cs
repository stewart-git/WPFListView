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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Queue<StaffDetails> QueueStaff = new Queue<StaffDetails>();
        private void AddStaff_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(!string.IsNullOrEmpty(FullName.Text) && 
                !string.IsNullOrEmpty(Position.Text) &&
                 !string.IsNullOrEmpty(Salary.Text))
            {
                StaffDetails staffDetails = new StaffDetails();
                staffDetails.SetFullName(FullName.Text);
                staffDetails.SetPosition(Position.Text);
                staffDetails.SetSalay(int.Parse(Salary.Text));
                QueueStaff.Enqueue(staffDetails);
                DisplayAllStaff();
                ClearTextBoxes();
            }
        }
        private void DisplayAllStaff()
        {
            ListViewDisplayStaff.Items.Clear();
            foreach(StaffDetails staff in QueueStaff)
            {
                ListViewDisplayStaff.Items.Add(new
                {
                    StaffName = staff.GetName(),
                    StaffPosition = staff.GetPosition(),
                    StaffSalary = staff.GetSalary()
                });
            }
        }
        private void ClearTextBoxes()
        {
            FullName.Clear();
            Position.Clear();
            Salary.Clear();
        }
    }
}
