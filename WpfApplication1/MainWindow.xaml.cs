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

        private void shotPerformedFN_DropDownClosed(object sender, System.EventArgs e)//зависимость Label от выбора в ComboBox таблица Employee
        {
            logicLocalDB.ComboBox_Opened(sender as ComboBox, shotPerformed, planDrew);
        }

        private void editingLcalDB_Click(object sender, RoutedEventArgs e)//открытие окна редактирования БД
        {
            new EditingLcalDB().Show();
        }

        private void savePlanLcalDB_Click(object sender, RoutedEventArgs e) //добавление сьемки в БД
        {
            List<string> arrayList = new List<string>();

            arrayList.Add(lableArea.Content.ToString());//0
            arrayList.Add(leshoz.Text);//1
            arrayList.Add(forestry.Text);//2
            arrayList.Add(felling.Text);//3
            arrayList.Add(kvartal.Text);//4
            arrayList.Add(vudel.Text);//5
            arrayList.Add(year.Text);//6
            arrayList.Add(pointNumber.Text);//7
            arrayList.Add(shotPerformedFN.Text);//8
            arrayList.Add(planDrewFN.Text);//9                       

            saveFromLocalDB.Reset(new ObservableCollection<Points>(coordinatesPolygon.Collection()).Count);//обновление значения строки сообщения и передача количества точек в полигоне
            saveFromLocalDB.SavePlotListDB(arrayList);//добавление данных сьемки в БД
            saveFromLocalDB.SaveJournalPolygon(coordinatesPolygon, 1);//добавление журнала сьемки УЧАСТКА в БД
            saveFromLocalDB.SaveJournalPolygon(coordinatesBinding, 0);//добавление журнала сьемки ПРИВЯЗКИ в БД

            saveFromLocalDB.MessageShow();//вывод сообщения о результатах работы
        }
                
        private void openPlanLcalDB_Click(object sender, RoutedEventArgs e)//открытие окна для выбора участка из БД для отображения
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

            new ShowTableDbPlotList(colectionElement).Show();
        }
    }
}


