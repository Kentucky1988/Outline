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

        private void buttonClear_Click(object sender, RoutedEventArgs e)//очистка 
        {
            mainWindowLogic.Clear(coordinatesPolygon, coordinatesBinding);
        }

        private void leshoz_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка при его открытие
        {

            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
            cn.Open();
            string strSQL = $"SELECT * FROM Leshoz";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);
            SqlDataReader dr = myCommand.ExecuteReader();

            leshoz.Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

            while (dr.Read())
            {
                string sName = dr.GetString(1);

                leshoz.Items.Add(sName);// таблица Leshoz               
            }

            cn.Close();
        }

        private void forestry_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка при его открытие
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
            cn.Open();
            string strSQL = $"SELECT * FROM Forestry";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);
            SqlDataReader dr = myCommand.ExecuteReader();

            forestry.Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

            while (dr.Read())
            {
                string sName = dr.GetString(1);

                forestry.Items.Add(sName);// таблица Forestry(лесничества)              
            }

            cn.Close();
        }

        private void felling_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка при его открытие
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
            cn.Open();
            string strSQL = $"SELECT * FROM Felling";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);
            SqlDataReader dr = myCommand.ExecuteReader();

            felling.Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

            while (dr.Read())
            {
                string sName = dr.GetString(1);

                felling.Items.Add(sName);//рубки               
            }

            cn.Close();
        }

        private void shotPerformedFN_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка при его открытие
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
            cn.Open();
            string strSQL = $"SELECT * FROM Employee";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);
            SqlDataReader dr = myCommand.ExecuteReader();

            shotPerformedFN.Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

            while (dr.Read())
            {
                string sName = dr.GetString(0);

                shotPerformedFN.Items.Add(sName);//зйомку виконав
            }

            cn.Close();
        }

        private void planDrewFN_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка при его открытие
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
            cn.Open();
            string strSQL = $"SELECT * FROM Employee";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);
            SqlDataReader dr = myCommand.ExecuteReader();
                        
            planDrewFN.Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

            while (dr.Read())
            {
                string sName = dr.GetString(0);
                               
                planDrewFN.Items.Add(sName);// план накреслив
            }

            cn.Close();
        }

        private void shotPerformedFN_DropDownClosed(object sender, System.EventArgs e)//зависимость TextBox от выбора в ComboBox
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


    }
}
