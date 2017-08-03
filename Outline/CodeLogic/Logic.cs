using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

[assembly: InternalsVisibleTo("Outline.Test")]

namespace WpfApplication1
{
    class Class1 : Window
    {
        Point[] myPoligon;//масив координат ХУ полигона
        Point[] myBinding;//масив координат ХУ привязки       

        public Point[] CalculationCoordinates(ObservableCollection<Points> сollection, int[] array, int x)//расчет координат
        {
            int a = сollection.Count + 1;//длина масива + координаты первой точки
            Point[] arrayPoligon = new Point[a];//создаем масив координат ХУ
            for (int i = 0; i < a; i++)
            {
                if (i == 0 && x == 0)
                {
                    arrayPoligon[0].X = array[0];  //координаты первой точки Х полигона: ширина окна / 2     
                    arrayPoligon[0].Y = array[1];  //координаты первой точки Y полигона: высота окна / 2           
                }
                else if (i == 0 && x == 1)
                {
                    if (array[2] > myPoligon.Length - 1)
                    {
                        MessageBox.Show("Перевірте правильность вводу номера точки від якої будете робити прив'язку");
                    }
                    arrayPoligon[0].X = myPoligon[array[2] - 1].X; //координаты первой точки Х привязки     
                    arrayPoligon[0].Y = myPoligon[array[2] - 1].Y; //координаты первой точки Y привязки          
                }
                else
                {
                    string rumb = сollection[i - 1].Румб.ToString();//румб
                    int grade = сollection[i - 1].Градуси; //градус
                    double minutes = сollection[i - 1].Хвилини; //минуты
                    double length = сollection[i - 1].Довжина; //длина

                    grade = (rumb == "x") ? int.Parse(ConvertingRumb(grade)[1]) : grade; //перевод градусов 360 в 90
                    rumb = (rumb == "x") ? ConvertingRumb(сollection[i - 1].Градуси)[0] : rumb;  //перевод градусов в румбы

                    if ("ПнСх" == rumb || "ПдСх" == rumb)
                    {
                        arrayPoligon[i].X = arrayPoligon[i - 1].X + Math.Sin((grade + (minutes / 60)) * (Math.PI / 180)) * length;
                    }
                    else
                    {
                        arrayPoligon[i].X = arrayPoligon[i - 1].X - Math.Sin((grade + (minutes / 60)) * (Math.PI / 180)) * length;
                    }
                    if ("ПнСх" == rumb || "ПнЗх" == rumb)
                    {
                        arrayPoligon[i].Y = arrayPoligon[i - 1].Y - Math.Cos((grade + (minutes / 60)) * (Math.PI / 180)) * length;
                    }
                    else
                    {
                        arrayPoligon[i].Y = arrayPoligon[i - 1].Y + Math.Cos((grade + (minutes / 60)) * (Math.PI / 180)) * length;
                    }
                }
            }
            return arrayPoligon;
        }

        public string[] ConvertingRumb(int grade)//перевод Градусов в Румбы
        {
            string[] array = new string[2];

            if (grade >= 0 && grade <= 90)
            {
                array[0] = "ПнСх";
                array[1] = grade.ToString();
            }
            else if (grade > 90 && grade <= 180)
            {
                array[0] = "ПдСх";
                array[1] = (180 - grade).ToString();
            }
            else if (grade > 180 && grade <= 270)
            {
                array[0] = "ПдЗх";
                array[1] = (grade - 180).ToString();
            }
            else if (grade > 270 && grade <= 360)
            {
                array[0] = "ПнЗх";
                array[1] = (360 - grade).ToString();
            }
            return array;
        }

        public double Area(Point[] array) //расчет площади многоугольника по координатам вершин
        {
            double area = 0;

            for (int i = 0; i < array.Length; i++)
            {
                Point A = array[i];
                Point B;

                if (i + 1 == array.Length)
                {
                    B = array[0];
                }
                else
                {
                    B = array[i + 1];
                }

                area += A.X * B.Y - A.Y * B.X;
            }

            if (area > 0)
            {
                return area / 20000;
            }
            else
            {
                return (area / 20000) * -1;
            }
        }

        public double Discrepancy(Point[] array) //рассчитывает неувязку 
        {
            Point A = array[0]; //координаты первой точки
            Point B = array[array.Length - 1]; //координаты последней точки

            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }

        public Canvas Number(ObservableCollection<Points> coordinatesPolygon, ObservableCollection<Points> coordinatesBinding, int[] array)//расчет координат номеров линий
        {
            Canvas numberLines = new Canvas(); //отображение номеров линий
            myPoligon = CalculationCoordinates(coordinatesPolygon, array, 0);//принимаем масив координат ХУ полигона
            myBinding = CalculationCoordinates(coordinatesBinding, array, 1);//принимаем масив координат ХУ привязки  

            for (int i = 0; i < myPoligon.Length; i++)//номера точек  полигона
            {
                if (i < myPoligon.Length - 1)//не показывать номер последней точки полигона
                {
                    TextBlock number = new TextBlock { Text = (i + 1).ToString() };
                    number.SetValue(Canvas.LeftProperty, myPoligon[i].X);
                    number.SetValue(Canvas.TopProperty, myPoligon[i].Y);

                    numberLines.Children.Add(number);//добавление номеров точек колекцию
                }
            }
            for (int i = 0; i < myBinding.Length; i++)//номера точек привязки
            {
                TextBlock number = new TextBlock();
                if (i < myBinding.Length - 1)//не показывать номер последней точки привязки
                {
                    number.Text = "П" + (i + 1).ToString();
                }
                if (i == myBinding.Length - 1)
                {
                    number.Text = "П";
                }
                number.SetValue(Canvas.LeftProperty, myBinding[i].X);
                number.SetValue(Canvas.TopProperty, myBinding[i].Y);
                if (i != 0)//не показывать номер первой точки привязки
                {
                    numberLines.Children.Add(number);//добавление номеров точек колекцию
                }
            }
            return numberLines;//добавление номеров точек в грид
        }

        public Path Poligon()//построение полигона
        {
            PathFigure pathFigure = new PathFigure();
            PathSegmentCollection segmentCollection = new PathSegmentCollection();
            PathFigureCollection figureCollection = new PathFigureCollection();

            for (int i = 0; i < myPoligon.Length; i++)//построение полигона
            {
                if (i == 0)
                {
                    pathFigure.StartPoint = new Point(myPoligon[i].X, myPoligon[i].Y);
                }
                else
                {
                    LineSegment line = new LineSegment();
                    line.Point = new Point(myPoligon[i].X, myPoligon[i].Y);
                    segmentCollection.Add(line);//добавление линий полигона в колекцию
                }
            }
            pathFigure.Segments = segmentCollection;
            figureCollection.Add(pathFigure);//добавление полигона

            PathFigure pathFigureBinding = new PathFigure();
            PathSegmentCollection segmentCollectionBinding = new PathSegmentCollection();

            for (int i = 0; i < myBinding.Length; i++)//построение привязки
            {
                if (i == 0)
                {
                    pathFigureBinding.StartPoint = new Point(myBinding[i].X, myBinding[i].Y);
                }
                else
                {
                    LineSegment line = new LineSegment();
                    line.Point = new Point(myBinding[i].X, myBinding[i].Y);
                    segmentCollectionBinding.Add(line);//добавление линий привязки в колекцию
                }
            }
            pathFigureBinding.Segments = segmentCollectionBinding;
            figureCollection.Add(pathFigureBinding);

            PathGeometry geometry = new PathGeometry();
            geometry.Figures = figureCollection;

            Path path = new Path();//последовательноть линий
            path.Stroke = Brushes.Black;//цвет линии      
            path.StrokeThickness = 1; //толшина линии
            path.Data = geometry;

            return path;//возврат полигона 
        }

        public string[] Info()//создание масива(площадь, неувязка) 
        {
            string[] array = new string[2];
            array[0] = Math.Round(Area(myPoligon), 2).ToString(); //площадь    
            array[1] = Math.Round(Discrepancy(myPoligon), 2).ToString();//неувязка    
            return array;
        }
    }
}
