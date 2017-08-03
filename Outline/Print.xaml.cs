using System.Collections.Generic;
using System.Windows;
namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для Print.xaml
    /// </summary>
    public partial class Print : Window
    {
        Class1 class1;
        Points coordinatesPolygon; //координаты полигона 
        Points coordinatesBinding; //координаты привязки

        int[] array;//координаты первой точки ХY

        private List<PointsPrints> PointsPrint(Points coordinates, int x)//копирование колекции с добавление порядкового номера линий
        {
            List<PointsPrints> arraycoordinates = new List<PointsPrints>();
            int number = 0;
            
            foreach (var item in coordinates.Collection())
            {
                number++;
                string numberLine = null;
                if (x == 0)
                {
                    if (number == coordinates.Collection().Count)
                    {
                        numberLine = $"{number}-1";
                    }
                    else
                    {
                        numberLine = $"{number}-{number + 1}";
                    }
                }
                else
                {
                    if (number == 1)
                    {
                        numberLine = $"{Margins.PointNumber}-П{number + 1}";
                    }
                    else if (number == coordinates.Collection().Count)
                    {
                        numberLine = $"П{number}-П";
                    }
                    else
                    {
                        numberLine = $"П{number}-П{number + 1}";
                    }
                }
                arraycoordinates.Add(new PointsPrints()
                {
                    Номер = numberLine,
                    Румб = (item.Румб.ToString() == "x") ? class1.ConvertingRumb(item.Градуси)[0] : item.Румб.ToString(),
                    Градус = (item.Румб.ToString() == "x") ? int.Parse(class1.ConvertingRumb(item.Градуси)[1]) : item.Градуси,
                    Хвилин = item.Хвилини,
                    Довжина = item.Довжина 
                });
            }
            return arraycoordinates;
        }

        public Print()
        {
            InitializeComponent();
            class1 = new Class1();
            coordinatesPolygon = Margins.CoordinatesPolygon;
            coordinatesBinding = Margins.CoordinatesBinding;
            myDataGridPoligon.ItemsSource = PointsPrint(coordinatesPolygon, 0);
            myDataGridBinding.ItemsSource = PointsPrint(coordinatesBinding, 1);
            ShowAbrus();
        }

        private void ShowAbrus()
        {
            leshoz.Content = $"Лісгосп: {Margins.Leshoz}  Лісництво: {Margins.Forestry}";
            felling.Content = $"Ділянка відведена під: {Margins.Felling} на {Margins.Year} рік";
            area.Content = $"Квартал: {Margins.Kvartal} Виділ: { Margins.Vudel} Площа: {Margins.LableArea} га";

            myGrid.Children.Clear();//очистка предыдущего изображения на полигоне
            ActualWidthHeight();
            myGrid.Children.Add(class1.Number(coordinatesPolygon.Collection(), coordinatesBinding.Collection(), array));
            myGrid.Children.Add(class1.Poligon());//построение полигона
            shotPerformed.Content = $"Зйомку виконав: {Margins.ShotPerformed} ______________________________ {Margins.ShotPerformedFN}";
            planDrew.Content = $"План накреслив: {Margins.PlanDrew} ______________________________ {Margins.PlanDrewFN}";
        }

        private void ActualWidthHeight()
        {
            array = new int[3];
            array[0] = 250; //координаты первой точки Х 
            array[1] = 400;//координаты первой точки Y
            array[2] = Margins.PointNumber;//номер точки от которой будут делать привязку
        }
    }
}

