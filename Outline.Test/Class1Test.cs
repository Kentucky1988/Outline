using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
