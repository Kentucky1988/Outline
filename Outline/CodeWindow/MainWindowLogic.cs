using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    class MainWindowLogic
    {
        Class1 class1;
        MainWindow poligon;      

        public MainWindowLogic(Class1 class1, MainWindow poligon)
        {
            this.class1 = class1;
            this.poligon = poligon;           
        }

        int[] array;//координаты первой точки ХY  
        string area = null;//площадь  
        public int[] Array { get { return array; } }      

        public void ActualWidthHeight()//координаты первой точки ХY  
        {
            array = new int[3];
            array[0] = (int)poligon.myGrid.ActualWidth / 2; //координаты первой точки Х ширина окна / 2    
            array[1] = (int)poligon.myGrid.ActualHeight / 2;//координаты первой точки Y ширина окна / 2 
            array[2] = (poligon.pointNumber.Text == string.Empty) ? 1 : int.Parse(poligon.pointNumber.Text);//номер точки от которой будут делать привязку
        }

        public void Info()//площадь, неувязка  
        {
            string[] array = class1.Info();
            area = array[0];
            poligon.lableArea.Content = array[0];    // площадь
            poligon.lableDiscrepancy.Content = $"Увага не'вязка: { array[1]} м"; //неувязка
        }

        public void Clear(Points coordinatesPolygon, Points coordinatesBinding, DataGrid dataGrid, DataGrid dataGridBindg)
        {
            MessageBoxResult clear = MessageBox.Show("Очистити полігон ?", "Очистка полігону", MessageBoxButton.YesNo);
            if (clear == MessageBoxResult.Yes)
            {
                coordinatesBinding.Collection().Clear();
                coordinatesPolygon.Collection().Clear();
                dataGrid.ItemsSource = coordinatesPolygon.Collection();
                dataGridBindg.ItemsSource = coordinatesBinding.Collection();
                poligon.myGrid.Children.Clear();
                poligon.kvartal.Text = "";
                poligon.vudel.Text = "";
                poligon.pointNumber.Text = "";
                poligon.lableDiscrepancy.Content = "";
            }
        }

        public void CopyMargins(Points coordinatesPolygon, Points coordinatesBinding)
        {
            Margins.Leshoz = poligon.leshoz.Text;        //лесхоз
            Margins.Forestry = poligon.forestry.Text;    //лесничество
            Margins.Felling = poligon.felling.Text;      //вид рубки
            Margins.Year = poligon.year.Text;            //год рубки
            Margins.Kvartal = poligon.kvartal.Text;      //квартал
            Margins.Vudel = poligon.vudel.Text;          //видел
            Margins.LableArea = area;                    //площаль
            Margins.PlanDrewFN = poligon.planDrewFN.Text;        //план начертил ФИО
            Margins.ShotPerformedFN = poligon.shotPerformedFN.Text; // съемку выполнил ФИО
            Margins.PointNumber = (poligon.pointNumber.Text == string.Empty) ? 1 : int.Parse(poligon.pointNumber.Text);//номер точки от которой будут делать привязку

            try
            {
                Margins.ShotPerformed = poligon.shotPerformed.Content.ToString();  // съемку выполнил
                Margins.PlanDrew = poligon.planDrew.Content.ToString(); //план начертил           
            }
            catch (Exception)
            {
                Margins.ShotPerformed = null;
                Margins.PlanDrew = null;
            }           
            
            Margins.CoordinatesPolygon = coordinatesPolygon;//координаты полигона 
            Margins.CoordinatesBinding = coordinatesBinding;//координаты привязки
        }
    }
}
