using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Habit_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseConnection db;
        private string habitName;
        public MainWindow()
        {
            InitializeComponent();
            db = new DatabaseConnection();
            MySqlConnection conn = db.SetDataBaseConnection();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            habitName = myTextBox.Text;
            DateTime? startdate = mydate.SelectedDate;
            Boolean state = false;
            if(radiobtn.IsChecked == true || radiobtn1.IsChecked == true)
            {
                state = true;
            }
            int hours = int.Parse(timetxtbox.Text);
            db.InsertData(habitName,startdate,state,hours);
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            habitName = myTextBox.Text;
            db.DeleteData(habitName);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void clear(object sender, RoutedEventArgs e)
        {
            ClearInputs(myGrid.Children);
        }
        private void ClearInputs(UIElementCollection controls) { 
            foreach(UIElement element in controls)
            {
                if (element is TextBox) {
                    ((TextBox)element).Text = string.Empty; 
                }
                if(element is RadioButton)
                {
                    ((RadioButton)element).IsChecked = false;
                }
                if (element is DatePicker)
                {
                    ((DatePicker)element).SelectedDate = null;
                }
            }
        
        }
    }
}