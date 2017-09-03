using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApplication1.CodeLogic;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Class1 class1;
        MainWindowLogic mainWindowLogic;
        Points coordinatesPolygon; //сьемка полигона 
        Points coordinatesBinding; //сьемка привязки
        InteractionLogicLocalDB logicLocalDB;//отображать значения в ComboBox из БД
        SaveFromLocalDB saveFromLocalDB;//клас сохранения, извличения, удаления сьемок в БД        

        public MainWindow()
        {
            InitializeComponent();
            class1 = new Class1();
            mainWindowLogic = new MainWindowLogic(class1, this);
            coordinatesPolygon = new Points();
            coordinatesBinding = new Points();
            dataGrid.ItemsSource = coordinatesPolygon.Collection();
            dataGridBindg.ItemsSource = coordinatesBinding.Collection();
            logicLocalDB = new InteractionLogicLocalDB();//отображать значения в ComboBox из БД
            saveFromLocalDB = new SaveFromLocalDB();//клас сохранения, извличения, удаления сьемок в БД
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myGrid.Children.Clear();//очистка предыдущего изображения на полигоне
            mainWindowLogic.ActualWidthHeight();//координаты первой точки ХY
            myGrid.Children.Add(class1.Number(dataGrid.ItemsSource as List<Points>, dataGridBindg.ItemsSource as List<Points>, mainWindowLogic.Array));//добавление номеров точек на полигон
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
            mainWindowLogic.Clear(coordinatesPolygon, coordinatesBinding, dataGrid, dataGridBindg);
        }

        private void leshoz_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка leshoz при его открытие
        {
            logicLocalDB.ComboBox_Opened(leshoz);
        }

        private void felling_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка felling при его открытие
        {
            logicLocalDB.ComboBox_Opened(felling);
        }

        private void shotPerformedFN_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка shotPerformedFN при его открытие
        {
            logicLocalDB.ComboBox_Opened(shotPerformedFN);
        }

        private void planDrewFN_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего списка planDrewFN при его открытие
        {
            logicLocalDB.ComboBox_Opened(planDrewFN);
        }

        private void forestry_DropDownOpened(object sender, System.EventArgs e)//обновление содержимого выпадающего forestry списка при его открытие
        {                                                                      //в зависимости от значения в ComboBox leshoz
            logicLocalDB.ComboBox_Opened(leshoz, forestry);
        }

        private void shotPerformedFN_DropDownClosed(object sender, System.EventArgs e)//зависимость Label shotPerformed от выбора в ComboBox таблица Employee
        {
            logicLocalDB.ComboBox_Opened(sender as ComboBox, shotPerformed);
        }

        private void planDrew_DropDownClosed(object sender, System.EventArgs e)//зависимость Label planDrew от выбора в ComboBox таблица Employee
        {
            logicLocalDB.ComboBox_Opened(sender as ComboBox, planDrew);
        }

        private void editingLcalDB_Click(object sender, RoutedEventArgs e)//открытие окна редактирования БД
        {
            EditingLcalDB editingLcalDB = new EditingLcalDB();
            editingLcalDB.Owner = this;//зaкрывать окно в cлучае закрытия главного окна
            editingLcalDB.Show();
        }

        private ArrayList ColectionContentComboBox()//создаем колекцию елементов главного окна
        {
            ArrayList colectionElement = new ArrayList();

            colectionElement.Add(lableArea);//0
            colectionElement.Add(leshoz);//1
            colectionElement.Add(forestry);//2
            colectionElement.Add(felling);//3
            colectionElement.Add(kvartal);//4
            colectionElement.Add(vudel);//5
            colectionElement.Add(year);//6
            colectionElement.Add(pointNumber);//7
            colectionElement.Add(shotPerformedFN);//8
            colectionElement.Add(planDrewFN);//9 
            colectionElement.Add(shotPerformed);//10
            colectionElement.Add(planDrew);//11
            colectionElement.Add(dataGrid);//12
            colectionElement.Add(dataGridBindg);//13
            colectionElement.Add(myGrid);//14
            colectionElement.Add(class1);//15
            colectionElement.Add(mainWindowLogic);//16 

            return colectionElement;
        }

        private void savePlanLcalDB_Click(object sender, RoutedEventArgs e) //добавление сьемки в БД
        {
            saveFromLocalDB.Reset((dataGrid.ItemsSource as List<Points>).Count);//обновление значения строки сообщения и передача количества точек в полигоне
            saveFromLocalDB.SavePlotListDB(ColectionContentComboBox());//добавление данных сьемки в БД
            saveFromLocalDB.SaveJournalPolygon(dataGrid.ItemsSource as List<Points> , 1);//добавление журнала сьемки УЧАСТКА в БД
            saveFromLocalDB.SaveJournalPolygon(dataGridBindg.ItemsSource as List<Points>, 0);//добавление журнала сьемки ПРИВЯЗКИ в БД

            saveFromLocalDB.MessageShow();//вывод сообщения о результатах работы
        }

        private void openPlanLcalDB_Click(object sender, RoutedEventArgs e)//открытие окна для выбора участка из БД для отображения
        {
            ShowTableDbPlotList showTableDbPlotList = new ShowTableDbPlotList(ColectionContentComboBox());
            showTableDbPlotList.Owner = this;//закрывать окно в cлучае закрытия главного окна 
            showTableDbPlotList.Show();
        }
    }
}


