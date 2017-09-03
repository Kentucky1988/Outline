using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApplication1
{
    interface IPoints
    {
        Rumb Румб { get; set; }
        int Градуси { get; set; }
        int Хвилини { get; set; }
        double Довжина { get; set; }
    }

    public enum Rumb
    {
        ПнСх, ПдСх, ПдЗх, ПнЗх, x
    }

    class Points : IPoints
    {
        private int мinutes; //минты
        private int grade; //градусы

        public Rumb Румб { get; set; }
        public int Градуси
        {
            get { return grade; }
            set
            {
                if (value > 360)
                {
                    grade = 0;
                    MessageBox.Show("Градуси повинні бути в межах 0 - 360");
                }
                else if (Румб.ToString() != "x" && value > 90)
                {
                    grade = 0;
                    MessageBox.Show("Градуси повинні бути в межах 0 - 90");
                }
                else
                { grade = value; };
            }
        }
        public int Хвилини
        {
            get { return мinutes; }
            set
            {
                if (value > 60)
                {
                    мinutes = 0;
                    MessageBox.Show("Хвилини повинні бути в межах  0 - 60");
                }
                else
                { мinutes = value; };
            }
        }
        public double Довжина { get; set; }

        ObservableCollection<Points> collection = new ObservableCollection<Points>();
        public List<Points> Collection()
        {
            List<Points> colectionPoint = new List<Points>(collection);
            return colectionPoint;
        }
    }

    class PointsPrints
    {
        public string Номер { get; set; }
        public string Румб { get; set; }
        public int Градус { get; set; }
        public int Хвилин { get; set; }
        public double Довжина { get; set; }
    }
}