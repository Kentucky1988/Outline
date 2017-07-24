using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        Points coordinatesPolygon; //съмка полигона 
        Points coordinatesBinding; //съмка привязки

        public MainWindow()
        {
            InitializeComponent();
            class1 = new Class1();
            mainWindowLogic = new MainWindowLogic(class1, this);
            coordinatesPolygon = new Points();
            coordinatesBinding = new Points();
            dataGrid.ItemsSource = coordinatesPolygon.Collection();
            dataGridBindg.ItemsSource = coordinatesBinding.Collection();
            EmployeeColection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            mainWindowLogic.Clear(coordinatesPolygon, coordinatesBinding);
        }

        private void EmployeeColection()//выпадающий список
        {
            EmployeeEntities obj = new EmployeeEntities();

            List<Employee> lstEmployee = obj.Employee.ToList();// таблица Employee      
            shotPerformedFN.ItemsSource = lstEmployee;//зйомку виконав
            planDrewFN.ItemsSource = lstEmployee;//план накреслив

            List<Forestry> lstForestry = obj.Forestry.ToList();// таблица Forestry
            forestry.ItemsSource = lstForestry;//лесничество

            List<Leshoz> lstLeshoz = obj.Leshoz.ToList();// таблица Leshoz
            leshoz.ItemsSource = lstLeshoz;//лесхоз

            List<Felling> lstFelling = obj.Felling.ToList();// таблица Felling
            felling.ItemsSource = lstFelling;//рубки
        }

        private void shotPerformedFN_DropDownClosed(object sender, System.EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
            cn.Open();                    
            string strSQL = $"SELECT * FROM Employee WHERE Name = '{((ComboBox)sender).Text}'";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);
            SqlDataReader dr = myCommand.ExecuteReader();
            
            while (dr.Read())
            {
                if (((ComboBox)sender).Name == "shotPerformedFN")
                {
                    shotPerformed.Text = dr[2].ToString();
                }
                else
                {
                    planDrew.Text = dr[2].ToString();
                }
            }

            cn.Close();
        }
    }
}
