using System.Collections.Generic;
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

        private void EmployeeColection()
        {
            EmployeeEntities obj = new EmployeeEntities();

            List<Employee> lstEmployee = obj.Employee.ToList();            
            shotPerformedFN.ItemsSource = lstEmployee;
            planDrewFN.ItemsSource = lstEmployee;

            List<Forestry> lstForestry = obj.Forestry.ToList();
            forestry.ItemsSource = lstForestry;

            List<Leshoz> lstLeshoz = obj.Leshoz.ToList();
            leshoz.ItemsSource = lstLeshoz;

            List<Felling> lstFelling = obj.Felling.ToList();
            felling.ItemsSource = lstFelling;
        }
    }
}
