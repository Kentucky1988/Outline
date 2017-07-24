using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для EditingLcalDB.xaml
    /// </summary>
    public partial class EditingLcalDB : Window
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dataTable;
        SqlCommandBuilder cmbd;

        public EditingLcalDB()
        {
            InitializeComponent();
            EmployeeGrid();
        }

        private void EmployeeGrid()//отображение Employee в DataGrid
        {
            try
            {
                connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
                connection.Open();
                command = new SqlCommand("SELECT * FROM Employee", connection);
                adapter = new SqlDataAdapter(command);
                dataTable = new DataTable("Employee");
                adapter.Fill(dataTable);
                employeeDataGrid.ItemsSource = dataTable.DefaultView;
            }

            catch (Exception)
            {
                MessageBox.Show("Помилка відкриття БД");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)//Сохранение изминений БД
        {
            cmbd = new SqlCommandBuilder(adapter);
            adapter.Update(dataTable);
            MessageBox.Show("Зміни успішно збережено");
        }
    }
}

