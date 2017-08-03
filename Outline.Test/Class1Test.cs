using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace WpfApplication1.Test
{
    [TestClass]
    public class Class1Test
    {
        Class1 class1 = new Class1();
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.Odbc", @"Dsn=Excel Files;dbq=.\Градусы_Румбы.xlsx;defaultdir=.; driverid=790;maxbuffersize=2048;pagetimeout=5", "Лист1$", DataAccessMethod.Sequential)]

        public void ConvertingRumbTest_Rumb_FromXLSX()
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


    }
}
