using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication1.CodeLogic;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для ShowTableDbPlotList.xaml
    /// </summary>
    public partial class ShowTableDbPlotList : Window
    {
        DataContext dc;//подключение к БД
        InteractionLogicLocalDB logicLocalDB;//отображать значения в ComboBox из БД
        DisplayingDataLocalDB displayingDataLocalDB;//отображение данных из БД в главном окне
        ArrayList colectionElement;//колекция елементов из главного окна

        public ShowTableDbPlotList(ArrayList colectionElement)
        {
            InitializeComponent();
            logicLocalDB = new InteractionLogicLocalDB();//отображать значения в ComboBox из БД
            displayingDataLocalDB = new DisplayingDataLocalDB();//отображение данных из БД в главном окне
            dc = new DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
            logicLocalDB.ShowTablePlotListDataGrid(showTablePlotListDataGrid, dc, ColectionContentComboBox());
            this.colectionElement = colectionElement;
        }

        private List<string> ColectionContentComboBox()
        {
            List<string> arrayList = new List<string>();

            arrayList.Add(Leshoz.Text);//0
            arrayList.Add(Forestry.Text);//1
            arrayList.Add(Felling.Text);//2
            arrayList.Add(Kvartal.Text);//3
            arrayList.Add(Year.Text);//4
            arrayList.Add(ShotPerformed.Text);//5
            arrayList.Add(PlanDrew.Text);//6

            return arrayList;
        }

        private void ComboBoxOpened_ShowTableDbPlotList(object sender, EventArgs e)
        {//событие на открытие ComboBox
            
            logicLocalDB.ComboBoxOpened_ShowTableDbPlotList(sender as ComboBox, ColectionContentComboBox());
        }

        private void ClosedComboBox_ShowInDataGrid(object sender, EventArgs e)
        {//событие на закрытие ComboBox и отображение в DataGrid выбранной информации
            logicLocalDB.ShowTablePlotListDataGrid(showTablePlotListDataGrid, dc, ColectionContentComboBox());
        }

        private void ShowPlot(object sender, RoutedEventArgs e)
        {
            displayingDataLocalDB.DisplayingPlotListDB(showTablePlotListDataGrid, dc, colectionElement);
        }

    }
}
