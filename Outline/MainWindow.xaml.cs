using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        Class1 class1;
        MainWindowLogic mainWindowLogic;
        Points coordinatesPolygon; //съeмка полигона 
        Points coordinatesBinding; //съeмка привязки
        SqlConnection cn;//подключение к БД

        public MainWindow()
        {
            InitializeComponent();
            class1 = new Class1();
            mainWindowLogic = new MainWindowLogic(class1, this);
            coordinatesPolygon = new Points();
            coordinatesBinding = new Points();
            dataGrid.ItemsSource = coordinatesPolygon.Collection();
            dataGridBindg.ItemsSource = coordinatesBinding.Collection();
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\Outline\Employee.mdf;Integrated Security=True");//подключение к БД
        }

        private void Button_Click(object sender, RoutedEventArgs e)//построение съемки
        {
            myGrid.Children.Clear();//очистка предыдущего изображения на полигоне
            mainWindowLogic.ActualWidthHeight();//координаты первой точки ХY
            myGrid.Children.Add(class1.Number(coordinatesPolygon.Collection(), coordinatesBinding.Collection(), mainWindowLogic.Array));//добавление номеров точек на полигон
            myGrid.Children.Add(class1.Poligon());//построение полигона
            mainWindowLogic.Info();//площадь, неувязка
        }

        private void buttonPrint_Click(object sender, RoutedEventArgs e)//печать
        {
            //mainWindowLogic.CopyMargins(coordinatesPolygon, coordinatesBinding);
            //Print print = new Print();
            //print.Show();
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                mainWindowLogic.CopyMargins(coordinatesPolygon, coordinatesBinding);
                Print print = new Print();
                printDialog.PrintVisual(print.printAbrus, "Абрис");
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)//очистка 
        {
            mainWindowLogic.Clear(coordinatesPolygon, coordinatesBinding);
        }
        
        private void ComboBox_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка при его открытие
        {
            string table = null;
            ComboBox comboBoxName = sender as ComboBox;

            switch (comboBoxName.Name)
            {
                case "leshoz":
                    table = "Leshoz";
                    break;
                case "forestry":
                    table = "Forestry";
                    break;
                case "felling":
                    table = "Felling";
                    break;
                case "shotPerformedFN":
                    table = "Employee";
                    break;
                case "planDrewFN":
                    table = "Employee";
                    break;
            }
           
            cn.Open();
            string strSQL = $"SELECT * FROM {table}";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);
            SqlDataReader dr = myCommand.ExecuteReader();

            (comboBoxName).Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

            while (dr.Read())// добавление колекции в ComoBox      
            {
                string sName = dr.GetString(0);

                (comboBoxName).Items.Add(sName);        
            }

            cn.Close();
        }

        private void shotPerformedFN_DropDownClosed(object sender, System.EventArgs e)//зависимость TextBox от выбора в ComboBox таблица Employee
        {
            ComboBox comboBox = sender as ComboBox;

            cn.Open();
            string strSQL = $"SELECT * FROM Employee WHERE Name = '{comboBox.Text}'";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);
            SqlDataReader dr = myCommand.ExecuteReader();

            while (dr.Read())
            {
                if (comboBox.Name == "shotPerformedFN")
                {
                    shotPerformed.Content = dr[1].ToString();
                }
                else
                {
                    planDrew.Content = dr[1].ToString();
                }
            }

            cn.Close();
        }

        private void editingLcalDB_Click(object sender, RoutedEventArgs e)//открытие окна редактирования БД
        {
            EditingLcalDB showEditingLcalDB = new EditingLcalDB();
            showEditingLcalDB.Show();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)//Выход
        {
            this.Close();
        }
    }
}
