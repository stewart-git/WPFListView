using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
            FullName.Clear(); FullName.Foreground = Brushes.CadetBlue; FullName.Text = "Enter Full Name";
            Position.Clear(); Position.Foreground = Brushes.CadetBlue; Position.Text = "Enter Staff Position";     
            Salary.Clear(); Salary.Foreground = Brushes.CadetBlue; Salary.Text = "Enter Current Salary";
        }
        private void ListViewDisplayStaff_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListViewDisplayStaff.SelectedIndex != -1)
            {
                int indx = ListViewDisplayStaff.SelectedIndex;
                FullName.Text = QueueStaff.ElementAt(indx).GetName();
                Position.Text = QueueStaff.ElementAt(indx).GetPosition();
                Salary.Text = QueueStaff.ElementAt(indx).GetSalary().ToString();
            }
        }
        private void FullName_GotFocus(object sender, RoutedEventArgs e)
        {
            FullName.Clear(); FullName.Foreground = Brushes.Black;
        }

        private void Position_GotFocus(object sender, RoutedEventArgs e)
        {
            Position.Clear(); Position.Foreground = Brushes.Black;
        }

        private void Salary_GotFocus(object sender, RoutedEventArgs e)
        {
            Salary.Clear(); Salary.Foreground = Brushes.Black;
        }


    }
}
