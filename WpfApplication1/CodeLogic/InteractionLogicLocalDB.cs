using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections;

namespace WpfApplication1.CodeLogic
{

    class InteractionLogicLocalDB
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
                MessageBox.Show("Помилка відкриття БД");
            }


        }

        public void ComboBox_Opened(ComboBox leshoz, ComboBox forestry)//обновление содержимого выпадающего списка при его открытие
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
                MessageBox.Show("Помилка відкриття БД");
            }
        }

        public void ComboBox_Opened(ComboBox sender, Label shotPerformed, Label planDrew)//зависимость Label от выбора в ComboBox таблица Employee
        {
            try
            {
                cn.Open();

                string strSQL = $"SELECT * FROM Employe WHERE Employe = '{(sender).Text}'";
                SqlCommand myCommand = new SqlCommand(strSQL, cn);
                SqlDataReader dr = myCommand.ExecuteReader();

                while (dr.Read())
                {
                    if ((sender).Name == "shotPerformedFN")
                    {
                        shotPerformed.Content = dr[1].ToString();// добавление значений в Label      
                    }
                    else
                    {
                        planDrew.Content = dr[1].ToString();// добавление значений в Label      
                    }
                }

                cn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка відкриття БД");
            }
        }
    }

    class JobFromLocalDB
    {
        public void SaveLocalDB(ArrayList arrayList)//добавление сьемки в БД
        {
            ObservableCollection<Points> сollectin = (arrayList[0] as Points).Collection();//колекция сьемки coordinatesPolygon

            try
            {
                DataContext dc = new DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Абрис\Outline\WpfApplication1\Employee.mdf;Integrated Security=True");
                int numberElementsPlotList = (from table in dc.GetTable<PlotList>()
                                              select table.Id).Max();//количество строк с таблице PlotList (максимальное значение Id)

                string stringMessage = null; //строка сообщения о неуказанных данных
                int quantityPoint = сollectin.Count; //количество введеных точек

                if ((arrayList[1] as ComboBox).Text == string.Empty)//leshoz
                {
                    stringMessage += "Вкажіть назву лісгоспу \n";
                }
                if ((arrayList[2] as ComboBox).Text == string.Empty)//forestry
                {
                    stringMessage += "Вкажіть назву лісництва \n";
                }
                if ((arrayList[3] as ComboBox).Text == string.Empty)//felling
                {
                    stringMessage += "Вкажіть вид рубки \n";
                }
                if ((arrayList[4] as TextBox).Text == string.Empty)//kvartal
                {
                    stringMessage += "Вкажіть номер кварталу \n";
                }
                if ((arrayList[5] as TextBox).Text == string.Empty)//vudel
                {
                    stringMessage += "Вкажіть номер виділу \n";
                }
                if ((arrayList[6] as TextBox).Text == string.Empty)//year
                {
                    stringMessage += "Вкажіть рік заходу \n";
                }
                if ((arrayList[7] as TextBox).Text == string.Empty)//pointNumber
                {
                    stringMessage += "Вкажіть номер точки прив'язки \n";
                }
                if ((arrayList[8] as ComboBox).Text == string.Empty)//shotPerformedFN
                {
                    stringMessage += "Вкажіть П.І.Б. особи яка виконала зйомку \n";
                }
                if ((arrayList[9] as ComboBox).Text == string.Empty)//planDrewFN
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

                    tablePlotList.Leshoz = (arrayList[1] as ComboBox).Text;
                    tablePlotList.Forestry = (arrayList[2] as ComboBox).Text;
                    tablePlotList.Felling = (arrayList[3] as ComboBox).Text;
                    tablePlotList.Kvartal = int.Parse((arrayList[4] as TextBox).Text);
                    tablePlotList.Vudel = decimal.Parse((arrayList[5] as TextBox).Text);
                    tablePlotList.Year = int.Parse((arrayList[6] as TextBox).Text);
                    tablePlotList.PointNumber = int.Parse((arrayList[7] as TextBox).Text);
                    tablePlotList.ShotPerformed = (arrayList[8] as ComboBox).Text;
                    tablePlotList.PlanDrew = (arrayList[9] as ComboBox).Text;

                    dc.GetTable<PlotList>().InsertOnSubmit(tablePlotList);
                    dc.SubmitChanges();

                    for (int i = 0; i < quantityPoint; i++)//добавление журнала сьемки
                    {
                        Journal tableJournal = new Journal();

                        tableJournal.Id_PlotList = numberElementsPlotList + 1;
                        tableJournal.Rumb = сollectin[i].Румб.ToString();
                        tableJournal.Grade = сollectin[i].Градуси;
                        tableJournal.Minutes = сollectin[i].Хвилини;
                        tableJournal.Length = decimal.Parse(сollectin[i].Довжина.ToString());

                        dc.GetTable<Journal>().InsertOnSubmit(tableJournal);
                        dc.SubmitChanges();
                    }

                    MessageBox.Show("Зйомка успішно збережена в БД");
                }
                else
                {
                    MessageBox.Show(stringMessage);//вывод строки о неуказанных данных
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка підключення до БД. \n Спробуйте ще раз.");
            }
        }
    }
}
