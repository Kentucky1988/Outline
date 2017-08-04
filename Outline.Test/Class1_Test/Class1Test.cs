using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WpfApplication1.Test
{
    [TestClass]
    public class Class1Test
    {
        Class1 class1 = new Class1();
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.Odbc", @"Dsn=Excel Files;dbq=.\Class1_Test\Градусы_Румбы.xlsx;defaultdir=.; driverid=790;maxbuffersize=2048;pagetimeout=5", "Лист1$", DataAccessMethod.Sequential)]

        public void ConvertingRumb_Rumb_FromXLSX()
        {//получение значения Румб в методе ConvertingRumb
            int x = Convert.ToInt32(TestContext.DataRow[0]);
            string excepted = (TestContext.DataRow[1]).ToString();

            string[] actual = new string[2];
            actual = class1.ConvertingRumb(x);

            Assert.AreEqual(excepted, actual[0]);
        }

        [TestMethod]
        public void Area_ArrayOFpoints_return09801()
        {//расчет площади многоугольника
            //1
            Point[] array = new Point[4];

            array[0].X = 1;
            array[0].Y = 1;
            array[1].X = 100;
            array[1].Y = 1;
            array[2].X = 100;
            array[2].Y = 100;
            array[3].X = 1;
            array[3].Y = 100;

            double expected = 0.9801;
            //2

            double actual = class1.Area(array);

            //3
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Discrepancy_ArrayOFpoints_return09801()
        {//растояние между первой и последней точкой
            //1
            Point[] array = new Point[4];

            array[0].X = 1;
            array[0].Y = 1;
            array[1].X = 100;
            array[1].Y = 1;
            array[2].X = 100;
            array[2].Y = 100;
            array[3].X = 1;
            array[3].Y = 100;

            double expected = 99;
            //2

            double actual = class1.Discrepancy(array);

            //3
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculationCoordinates_Poligon()
        {//тест метода росчета координат полигонна
         //1

            Help_Class1Test newcolection = new Help_Class1Test();
            ObservableCollection<TestPoint> сollection = new ObservableCollection<TestPoint>(newcolection.ReturnColection());
            int[] array = { 400, 900, 0 };//X,Y,номер точки от которой будут делать привязку
            Point[] expected = newcolection.ArrayPoints();

            //2
            Point[] actual = class1.CalculationCoordinates(сollection, array, 0);

            //3    
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i].X != actual[i].X || expected[i].Y != actual[i].Y)
                {
                    StringAssert.Contains(expected[i].ToString(), actual[i].ToString());
                }
            }
        }

        [TestMethod]
        public void CalculationCoordinates_Binding()
        {//тест метода росчета координат привязка
         //1

            Help_Class1Test newcolection = new Help_Class1Test();
            ObservableCollection<TestPoint> сollection = new ObservableCollection<TestPoint>(newcolection.ReturnColection());
            int[] array = { 400, 900, 1 };//X,Y,номер точки от которой будут делать привязку
            Point[] expected = newcolection.ArrayPoints();

            //2
            Point[] actual = class1.CalculationCoordinates(сollection, array, 0);//заполняем масив arrayPoligon, что б можно было привязатся
            actual = class1.CalculationCoordinates(сollection, array, 1);//координаты привязки

            //3    
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i].X != actual[i].X || expected[i].Y != actual[i].Y)
                {
                    StringAssert.Contains(expected[i].ToString(), actual[i].ToString());
                }
            }
        }
    }
}
