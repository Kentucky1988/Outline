using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WpfApplication1.CodeLogic;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для ShowTableDbPlotList.xaml
    /// </summary>
    public partial class ShowTableDbPlotList : Window
    {
        DataContext dc;//подключение к БД
        InteractionLogicLocalDB logicLocalDB;//отображать значения в ComboBox из БД
        DisplayingDataLocalDB displayingDataLocalDB;//отображение данных из БД в главном окне
        DeleteDataLocalDB deleteDataLocalDB;//удаление дынных из БД
        ArrayList colectionElement;//колекция елементов из главного окна

        public ShowTableDbPlotList(ArrayList colectionElement)
        {
            InitializeComponent();
            logicLocalDB = new InteractionLogicLocalDB();//отображать значения в ComboBox из БД
            displayingDataLocalDB = new DisplayingDataLocalDB();//отображение данных из БД в главном окне
            deleteDataLocalDB = new DeleteDataLocalDB();//удаление дынных из БД
            dc = new DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\Outline\Employee.mdf;Integrated Security=True");
            logicLocalDB.ShowTablePlotListDataGrid(showTablePlotListDataGrid, dc, ColectionContentComboBox());
            this.colectionElement = colectionElement;
        }

        private List<string> ColectionContentComboBox()
        {
            List<string> arrayList = new List<string>();

            arrayList.Add(Leshoz.Text);//0
            arrayList.Add(Forestry.Text);//1
            arrayList.Add(Felling.Text);//2
            arrayList.Add(Kvartal.Text);//3
            arrayList.Add(Year.Text);//4
            arrayList.Add(ShotPerformed.Text);//5
            arrayList.Add(PlanDrew.Text);//6

            return arrayList;
        }

        private void ComboBoxOpened_ShowTableDbPlotList(object sender, EventArgs e)//событие на открытие ComboBox       
        {
            logicLocalDB.ComboBoxOpened_ShowTableDbPlotList(sender as ComboBox, ColectionContentComboBox());
        }

        private void ClosedComboBox_ShowInDataGrid(object sender, EventArgs e)//событие на закрытие ComboBox и отображение в DataGrid выбранной информации
        {
            logicLocalDB.ShowTablePlotListDataGrid(showTablePlotListDataGrid, dc, ColectionContentComboBox());
        }

        private void ShowPlot(object sender, RoutedEventArgs e)//отображение данных из БД в главном окне
        {
            displayingDataLocalDB.IndexItem(showTablePlotListDataGrid, dc);//получаем индекс выделеного участка, передача стороки подключение к БД
            displayingDataLocalDB.DisplayingPlotListDB(colectionElement);//отображение данных лесхоза из БД в окне
            displayingDataLocalDB.DisplayingJournalPolygon(colectionElement[12] as DataGrid);//добавление журнала сьемки участка из БД в DataGrid
            displayingDataLocalDB.DisplayingJournalPolygon(colectionElement[13] as DataGrid);//добавление журнала привязки участка из БД в DataGrid

            //построение полигонна
            (colectionElement[14] as StackPanel).Children.Clear();//очистка предыдущего изображения на полигоне
            (colectionElement[16] as MainWindowLogic).ActualWidthHeight();//координаты первой точки ХY
            (colectionElement[14] as StackPanel).Children.Add((colectionElement[15] as Class1).Number((colectionElement[12] as DataGrid).ItemsSource as List<Points>, (colectionElement[13] as DataGrid).ItemsSource as List<Points>, (colectionElement[16] as MainWindowLogic).Array));//добавление номеров точек на полигон
            (colectionElement[14] as StackPanel).Children.Add((colectionElement[15] as Class1).Poligon());//построение полигона
            (colectionElement[16] as MainWindowLogic).Info();//площадь, неувязка
        }

        private void DeletePlot(object sender, RoutedEventArgs e)//удаление участка из БД
        {
            if (MessageBox.Show("Ви бажаєте видалити вибрану ділянку з БД?", "Збереження змін", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                deleteDataLocalDB.IndexItem(showTablePlotListDataGrid, dc);//получаем индекс выделеного участка, передача стороки подключение к БД
                deleteDataLocalDB.DeleteDataFromPlotList(showTablePlotListDataGrid);//удаление дынных из БД таблицы Journal
            }
        }
    }
}
