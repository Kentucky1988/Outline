using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.Data;

namespace WpfApplication1.CodeLogic
{

    class InteractionLogicLocalDB//Логика взаимодействия с LocalDB
    {
        SqlConnection cn;//подключение к БД

        public InteractionLogicLocalDB()
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");//подключение к БД
        }

        public void ComboBox_Opened(ComboBox comboBox)//обновление содержимого выпадающего списка при его открытие
        {
            string nameTable = null;

            switch (comboBox.Name)
            {
                case "leshoz":
                    nameTable = "Leshoz";
                    break;
                case "felling":
                    nameTable = "Felling";
                    break;
                case "shotPerformedFN":
                    nameTable = "Employe";
                    break;
                case "planDrewFN":
                    nameTable = "Employe";
                    break;
                default:
                    break;
            }

            try
            {
                cn.Open();

                string strSQL = $"SELECT * FROM {nameTable}";
                SqlCommand myCommand = new SqlCommand(strSQL, cn);
                SqlDataReader dr = myCommand.ExecuteReader();

                comboBox.Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

                while (dr.Read())
                {
                    string sName = dr.GetString(0);
                    comboBox.Items.Add(sName);// добавление значений в ComboBox            
                }

                cn.Close();
            }
            catch (Exception)
            {
                cn.Close();
                MessageBox.Show("Помилка відкриття БД");
            }


        }

        public void ComboBox_Opened(ComboBox leshoz, ComboBox forestry)//обновление содержимого выпадающего списка при его открытие в зависимости от значения в другом ComboBox
        {
            try
            {
                cn.Open();

                string strSQL = null;

                if (leshoz.Text != string.Empty)
                {
                    strSQL = $"SELECT Forestry FROM Forestry WHERE Leshoz = N'{leshoz.Text}'";
                }
                else
                {
                    strSQL = $"SELECT * FROM Forestry";
                }

                SqlCommand myCommand = new SqlCommand(strSQL, cn);
                SqlDataReader dr = myCommand.ExecuteReader();

                forestry.Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

                while (dr.Read())
                {
                    string sName = dr.GetString(0);
                    forestry.Items.Add(sName);// добавление значений в ComboBox                
                }

                cn.Close();
            }
            catch (Exception)
            {
                cn.Close();
                MessageBox.Show("Помилка відкриття БД");
            }
        }

        public void ComboBox_Opened(ComboBox sender, Label lablePosition)//зависимость Label от выбора в ComboBox таблица Employee
        {
            try
            {
                cn.Open();

                string strSQL = $"SELECT * FROM Employe WHERE Employe = N'{(sender).Text}'";
                SqlCommand myCommand = new SqlCommand(strSQL, cn);
                SqlDataReader dr = myCommand.ExecuteReader();

                while (dr.Read())
                {
                    lablePosition.Content = dr[1].ToString();// добавление значений в Label    
                }

                cn.Close();
            }
            catch (Exception)
            {
                cn.Close();
                MessageBox.Show("Помилка відкриття БД");
            }
        }

        public void ComboBoxOpened_ShowTableDbPlotList(ComboBox comboBox, List<string> arrayList)//обновление содержимого выпадающего списка в при его открытие,
        {                                                                                        //окно роботы с БД
            try
            {
                cn.Open();
                string strSQL = $"SELECT DISTINCT {comboBox.Name} FROM PlotList WHERE Leshoz = N'{arrayList[0]}' ";

                if (comboBox.Name == "Leshoz")
                {
                    strSQL = $"SELECT DISTINCT Leshoz FROM PlotList";
                }
                else
                {
                    if (arrayList[0] != string.Empty && comboBox.Name != "Forestry" && arrayList[1] != string.Empty)
                    {
                        strSQL += $"AND Forestry = N'{arrayList[1]}'";
                    }
                    if (arrayList[0] != string.Empty && comboBox.Name != "Felling" && arrayList[2] != string.Empty)
                    {
                        strSQL += $"AND Felling = N'{arrayList[2]}'";
                    }
                    if (arrayList[0] != string.Empty && comboBox.Name != "Kvartal" && arrayList[3] != string.Empty)
                    {
                        strSQL += $"AND Kvartal = N'{arrayList[3]}'";
                    }
                    if (arrayList[0] != string.Empty && comboBox.Name != "Year" && arrayList[4] != string.Empty)
                    {
                        strSQL += $"AND Year = N'{arrayList[4]}'";
                    }
                    if (arrayList[0] != string.Empty && comboBox.Name != "ShotPerformed" && arrayList[5] != string.Empty)
                    {
                        strSQL += $"AND ShotPerformed = N'{arrayList[5]}'";
                    }
                    if (arrayList[0] != string.Empty && comboBox.Name != "PlanDrew" && arrayList[6] != string.Empty)
                    {
                        strSQL += $"AND PlanDrew = N'{arrayList[6]}'";
                    }
                }

                SqlCommand myCommand = new SqlCommand(strSQL, cn);
                SqlDataReader dr = myCommand.ExecuteReader();

                comboBox.Items.Clear();//удаление содержимого выпадающего списка чтоб небыло (список * 2)

                while (dr.Read())
                {
                    string sName = dr[0].ToString();
                    comboBox.Items.Add(sName);// добавление значений в ComboBox                
                }

                cn.Close();
            }
            catch (Exception)
            {
                cn.Close();
                MessageBox.Show("Помилка відкриття БД");
            }
        }

        public void ShowTablePlotListDataGrid(DataGrid showTablePlotListDataGrid, DataContext dc, List<string> arrayList)//отображение содержимого в DataGrid в зависимости от выбраного значения в ComboBox
        {
            try
            {
                showTablePlotListDataGrid.ItemsSource = from table in dc.GetTable<PlotList>()
                                                        where ((arrayList[0] != string.Empty) ? (table.Leshoz == arrayList[0]) : true)
                                                        where ((arrayList[1] != string.Empty) ? (table.Forestry == arrayList[1]) : true)
                                                        where ((arrayList[2] != string.Empty) ? (table.Felling == arrayList[2]) : true)
                                                        where ((arrayList[3] != string.Empty) ? (table.Kvartal == int.Parse((!string.IsNullOrEmpty(arrayList[3]) ? arrayList[3] : "0"))) : true)
                                                        where ((arrayList[4] != string.Empty) ? (table.Year == int.Parse((!string.IsNullOrEmpty(arrayList[4]) ? arrayList[4] : "0"))) : true)
                                                        where ((arrayList[5] != string.Empty) ? (table.ShotPerformed == arrayList[5]) : true)
                                                        where ((arrayList[6] != string.Empty) ? (table.PlanDrew == arrayList[6]) : true)
                                                        select new
                                                        {
                                                            Номер = table.Id,
                                                            Лісгосп = table.Leshoz,
                                                            Лісництво = table.Forestry,
                                                            Вид_рубки = table.Felling,
                                                            Квартал = table.Kvartal,
                                                            Виділ = table.Vudel,
                                                            Площа = table.Area,
                                                            Рік_рубки = table.Year,
                                                            Зйомку_виконав = table.ShotPerformed,
                                                            План_накреслив = table.PlanDrew,
                                                        };
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка відкриття БД");
            }

        }
    }

    class SaveFromLocalDB//сохранение данных в БД
    {
        DataContext dc;//подключение к БД
        string stringMessage = null; //строка сообщения о неуказанных данных         
        int quantityPoint = 0; //количество введеных точек        

        public SaveFromLocalDB()
        {
            dc = new DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
        }

        public void Reset(int x)//обновление значения глобальных переменных
        {
            stringMessage = null; //обнуление строки от предыдущих сообщений            
            quantityPoint = x; //количество введеных точек участка      
        }

        public void SavePlotListDB(ArrayList  colectionElement)//добавление данных сьемки в БД
        {
            try
            {
                if ((colectionElement[0] as Label).Content.ToString() == "0")//area
                {
                    stringMessage += "Розрахуйте площу ділянки\n";
                }
                if ((colectionElement[1] as ComboBox).Text == string.Empty)//leshoz
                {
                    stringMessage += "Вкажіть назву лісгоспу \n";
                }
                if ((colectionElement[2] as ComboBox).Text == string.Empty)//forestry
                {
                    stringMessage += "Вкажіть назву лісництва \n";
                }
                if ((colectionElement[3] as ComboBox).Text == string.Empty)//felling
                {
                    stringMessage += "Вкажіть вид рубки \n";
                }
                if ((colectionElement[4] as TextBox).Text == string.Empty)//kvartal
                {
                    stringMessage += "Вкажіть номер кварталу \n";
                }
                if ((colectionElement[5] as TextBox).Text == string.Empty)//vudel
                {
                    stringMessage += "Вкажіть номер виділу \n";
                }
                if ((colectionElement[6] as TextBox).Text == string.Empty)//year
                {
                    stringMessage += "Вкажіть рік заходу \n";
                }
                if ((colectionElement[7] as TextBox).Text == string.Empty)//pointNumber
                {
                    stringMessage += "Вкажіть номер точки прив'язки \n";
                }
                if ((colectionElement[8] as ComboBox).Text == string.Empty)//shotPerformedFN
                {
                    stringMessage += "Вкажіть П.І.Б. особи яка виконала зйомку \n";
                }
                if ((colectionElement[9] as ComboBox).Text == string.Empty)//planDrewFN
                {
                    stringMessage += "Вкажіть П.І.Б. особи яка накреслила план \n";
                }
                if (quantityPoint == 0)
                {
                    stringMessage += "Введіть данні зйомки";
                }

                if (quantityPoint != 0 && stringMessage == null)
                {
                    PlotList tablePlotList = new PlotList(); // добавление данных сьемки

                    tablePlotList.Area = decimal.Parse((colectionElement[0] as Label).Content.ToString());
                    tablePlotList.Leshoz = (colectionElement[1] as ComboBox).Text;
                    tablePlotList.Forestry = (colectionElement[2] as ComboBox).Text;
                    tablePlotList.Felling = (colectionElement[3] as ComboBox).Text;
                    tablePlotList.Kvartal = int.Parse((colectionElement[4] as TextBox).Text);
                    tablePlotList.Vudel = decimal.Parse((colectionElement[5] as TextBox).Text);
                    tablePlotList.Year = int.Parse((colectionElement[6] as TextBox).Text);
                    tablePlotList.PointNumber = int.Parse((colectionElement[7] as TextBox).Text);
                    tablePlotList.ShotPerformed = (colectionElement[8] as ComboBox).Text;
                    tablePlotList.PlanDrew = (colectionElement[9] as ComboBox).Text;

                    dc.GetTable<PlotList>().InsertOnSubmit(tablePlotList);
                    dc.SubmitChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка збереження даних зйомки. \n Спробуйте ще раз.");
            }
        }

        public void SaveJournalPolygon(List<Points> сollectin, int x)//добавление журнала сьемки участка в БД
        {
            try
            {                
                int numberElementsPlotList = 0;//значение Id в таблице PlotList

                var IdPlotList = from table in dc.GetTable<PlotList>()
                                 select table.Id;//получаем столбец Id таблицы PlotList               

                if (IdPlotList.Count() != 0)//количество строк в таблице PlotList (максимальное значение Id)
                {
                    numberElementsPlotList = IdPlotList.Max();
                }

                for (int i = 0; i < сollectin.Count && stringMessage == null; i++)//добавление журнала сьемки участка
                {
                    Journal tableJournal = new Journal();

                    tableJournal.Id_PlotList = numberElementsPlotList;
                    tableJournal.Identifier = x;
                    tableJournal.Rumb = сollectin[i].Румб.ToString();
                    tableJournal.Grade = сollectin[i].Градуси;
                    tableJournal.Minutes = сollectin[i].Хвилини;
                    tableJournal.Length = decimal.Parse(сollectin[i].Довжина.ToString());

                    dc.GetTable<Journal>().InsertOnSubmit(tableJournal);
                    dc.SubmitChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка збереження журналу зйомки. \n Спробуйте ще раз.");
            }
        }

        public void MessageShow()//вывод сообщения о результатах работы
        {
            if (stringMessage == null && quantityPoint != 0)
            {
                MessageBox.Show("Зйомка успішно збережена в БД");
            }
            else
            {
                MessageBox.Show(stringMessage);//вывод строки о неуказанных данных
            }
        }
    }

    class DisplayingDataLocalDB//отображение данных из БД в главном окне
    {
        int index = 0;//получение значение ID выделеного столбца
        DataContext dc = null;//подключение к БД

        public void IndexItem(DataGrid showTablePlotListDataGrid, DataContext dc)
        {
            var selectedCell = showTablePlotListDataGrid.SelectedCells[0];
            var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
            index = int.Parse((cellContent as TextBlock).Text);//получение значение ID выделеного столбца
            this.dc = dc;//подключение к БД
        }

        public void DisplayingPlotListDB(ArrayList colectionElement)//отображение данных лесхоза из БД в окне
        {
            try
            {
                InteractionLogicLocalDB logicLocalDB = new InteractionLogicLocalDB();

                var selectedItem = (from table in dc.GetTable<PlotList>()
                                    where table.Id == index
                                    select table).ToArray();//получаем значение выделенной строки         

                (colectionElement[0] as Label).Content = selectedItem[0].Area.ToString();
                (colectionElement[1] as ComboBox).Text = selectedItem[0].Leshoz.ToString();
                (colectionElement[2] as ComboBox).Text = selectedItem[0].Forestry.ToString();
                (colectionElement[3] as ComboBox).Text = selectedItem[0].Felling.ToString();
                (colectionElement[4] as TextBox).Text = selectedItem[0].Kvartal.ToString();
                (colectionElement[5] as TextBox).Text = selectedItem[0].Vudel.ToString();
                (colectionElement[6] as TextBox).Text = selectedItem[0].Year.ToString();
                (colectionElement[7] as TextBox).Text = selectedItem[0].PointNumber.ToString();
                (colectionElement[8] as ComboBox).Text = selectedItem[0].ShotPerformed.ToString();
                (colectionElement[9] as ComboBox).Text = selectedItem[0].PlanDrew.ToString();

                logicLocalDB.ComboBox_Opened(colectionElement[8] as ComboBox, colectionElement[10] as Label);
                logicLocalDB.ComboBox_Opened(colectionElement[9] as ComboBox, colectionElement[11] as Label);
            }
            catch (Exception)
            {
                MessageBox.Show("Виберіть ділянку");
            }
        }

        public void DisplayingJournalPolygon(DataGrid dataGrid)//добавление журнала сьемки участка в БД
        {

            var collectionСoordinates = (from table in dc.GetTable<Journal>()
                                        where table.Id_PlotList == index
                                        where ((dataGrid.Name == "dataGrid") ? (table.Identifier == 1) : (table.Identifier == 0))
                                        select new Points
                                        {
                                            Румб = (table.Rumb == "ПнСх" ? Rumb.ПнСх :
                                            (table.Rumb == "ПдСх" ? Rumb.ПдСх :
                                            (table.Rumb == "ПдЗх" ? Rumb.ПдЗх :
                                            (table.Rumb == "ПнЗх" ? Rumb.ПнЗх : Rumb.x)))),
                                            Градуси = table.Grade,
                                            Хвилини = table.Minutes,
                                            Довжина = Convert.ToDouble(table.Length),
                                        }).ToList();

            dataGrid.ItemsSource = collectionСoordinates;

        }
    }
}
