using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfApplication1.Test
{
    class TestPoint : IPoints
    {
        public Rumb Румб { get; set; }    //румб
        public int Градуси { get; set; }    //градус
        public int Хвилини { get; set; } //минуты
        public double Довжина { get; set; } //длина
    }

    class Collection
    {
        TestPoint point;
        private List<TestPoint> users;
        public List<TestPoint> Users { get { return users; } }

        public Collection()
        {
            point = new TestPoint();
            users = new List<TestPoint>();
            InitialData();
        }

        private void InitialData()
        {
            point.Румб = Rumb.ПдСх;//точка 1
            point.Градуси = 4;
            point.Хвилини = 56;
            point.Довжина = 66.7;
            AddCollection();
            point.Румб = Rumb.ПдЗх;//точка 2
            point.Градуси = 36;
            point.Хвилини = 1;
            point.Довжина = 19.7;
            AddCollection();
            point.Румб = Rumb.ПдСх;//точка 3
            point.Градуси = 49;
            point.Хвилини = 52;
            point.Довжина = 43.6;
            AddCollection();
            point.Румб = Rumb.ПнСх;//точка 4
            point.Градуси = 14;
            point.Хвилини = 38;
            point.Довжина = 23.85;
            AddCollection();
        }

        private void AddCollection()
        {
            users.Add(point);
        }
    }

    class Help_Class1Test
    {
        public List<TestPoint> ReturnColection()
        {
            Collection colection = new Collection();
            return colection.Users;
        }

        public Point[] ArrayPoints()
        {
            Point[] array = new Point[5];

            array[0].X = 400;
            array[0].Y = 900;
            array[1].X = 406.025280496369;
            array[1].Y = 876.923637744651;
            array[2].X = 412.050560992737;
            array[2].Y = 853.847275489303;
            array[3].X = 418.075841489106;
            array[3].Y = 830.770913233954;
            array[4].X = 424.101121985474;
            array[4].Y = 807.694550978605;

            return array;
        }        
    }    
}
