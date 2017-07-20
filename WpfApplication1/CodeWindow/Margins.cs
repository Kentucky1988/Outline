
namespace WpfApplication1
{
    static class Margins
    {
        public static string Leshoz { get; set; }  //лесхоз
        public static string Forestry { get; set; }//лесничество
        public static string Felling { get; set; } //вид рубки
        public static string Year { get; set; }    //год рубки
        public static string Kvartal { get; set; } //квартал
        public static string Vudel { get; set; }   //видел
        public static string LableArea { get; set; }//площаль
        public static int PointNumber { get; set; }//номер точки от которой будут делать привязку
        public static string ShotPerformed { get; set; } // съемку выполнил
        public static string ShotPerformedFN { get; set; } // съемку выполнил ФИО
        public static string PlanDrew { get; set; } //план начертил
        public static string PlanDrewFN { get; set; } //план начертил ФИО
        
        public static Points CoordinatesPolygon { get; set; }//координаты полигона 
        public static Points CoordinatesBinding { get; set; }//координаты привязки
    }
}
