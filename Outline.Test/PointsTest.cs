using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WpfApplication1.Test
{
    [TestClass]
    public class PointsTest
    {
        Points point = new Points();

        [TestMethod]
        public void Градуси_valueMore90_gradeEgually0()
        {//Градуси_valueБольше360_значениеПоляgradeРавно0
            int x = 91;
            int expected = 0;

            point.Градуси = x;
            int actual = point.Градуси;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Градуси_valueLess90_gradeEguallyValue90()
        {//Градуси_valueМеньше90_значениеПоляgradeРавно90
            int x = 90;
            int expected = 90;

            point.Градуси = x;
            int actual = point.Градуси;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Хвилини_valueMore60_мinutesEgually0()
        {//Хвилини_value60_значениеПоляgradeРавно0
            int x = 61;
            int expected = 0;

            point.Хвилини = x;
            double actual = point.Хвилини;
            actual = point.Хвилини;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Хвилини_valueLess60_мinutesEguallyValue90()
        {//Хвилини_value59_значениеПоляgradeРавно59
            int x = 59;
            int expected = 59;

            point.Хвилини = x;
            double actual = point.Хвилини;

            Assert.AreEqual(expected, actual);
        }               
    }
}
