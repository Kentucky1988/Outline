﻿using System.Collections;
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
        JobFromLocalDB jobFromLocalDB;//клас сохранения, извличения, удаления сьемок в БД

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
            jobFromLocalDB = new JobFromLocalDB();//клас сохранения, извличения, удаления сьемок в БД
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
            EditingLcalDB showEditingLcalDB = new EditingLcalDB();
            showEditingLcalDB.Show();
        }

        private void savePlanLcalDB_Click(object sender, RoutedEventArgs e) //добавление сьемки в БД
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(coordinatesPolygon);//0
            arrayList.Add(leshoz);//1
            arrayList.Add(forestry);//2
            arrayList.Add(felling);//3
            arrayList.Add(kvartal);//4
            arrayList.Add(vudel);//5
            arrayList.Add(year);//6
            arrayList.Add(pointNumber);//7
            arrayList.Add(shotPerformedFN);//8
            arrayList.Add(planDrewFN);//9

            jobFromLocalDB.SaveLocalDB(arrayList);
        }

        //!!!!!!!!!!!!!!!добавить точки привязки в БД!!!!!!!!!!!!!!!!!!!!!!!
    }
}


