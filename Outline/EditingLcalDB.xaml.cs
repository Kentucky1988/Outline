using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

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

        ArrayList arrayList = new ArrayList();  

        public EditingLcalDB()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\Outline\Employee.mdf;Integrated Security=True");
            EmployeeGrid(employeeDataGrid, "Employee");
            EmployeeGrid(leshozDataGrid, "Leshoz");
            EmployeeGrid(forestryDataGrid, "Forestry");
            EmployeeGrid(fellingDataGrid, "Felling");
        }

        private void EmployeeGrid(DataGrid nameGrid, string table)//отображение таблицы БД в DataGrid
        {
            try
            {
                connection.Open();
                command = new SqlCommand($"SELECT * FROM {table}", connection);
                arrayList.Add(command);
                adapter = new SqlDataAdapter(command);
                arrayList.Add(adapter);
                dataTable = new DataTable(table);
                arrayList.Add(dataTable);
                adapter.Fill(dataTable);
                nameGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Нажаль не вдалось підключитись до файлів Бази Данних. Спробуйте ще раз, або перезапустіть программу");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)//Сохранение изминений БД
        {
            int x = 0;// если Employee          

            switch ((sender as Button).Name)
            {             
                case "Leshoz":
                    x = 3;
                    break;
                case "Forestry":
                    x = 6;
                    break;
                case "Felling":
                    x = 9;
                    break;               
            }

            try
            {
                connection.Open();
                command = (SqlCommand)arrayList[x];
                adapter = (SqlDataAdapter)arrayList[x + 1];
                dataTable = (DataTable)arrayList[x + 2];
                cmbd = new SqlCommandBuilder(adapter);
            }
            catch (Exception)
            {
                connection.Close();
                MessageBox.Show("Нажаль не вдалось підключитись до файлів Бази Данних. Спробуйте ще раз, або перезапустіть программу");
            }
            
            try
            {
                adapter.Update(dataTable);
                connection.Close();
                MessageBox.Show("Зміни успішно збережено");
            }
            catch (Exception)
            {
                MessageBox.Show("Вкажіть П.І.Б. і посаду");
            }

            connection.Close();
        }
    }
}

