using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            string x = null;

            switch (comboBox.Name)
            {
                case "leshoz":
                    x = "Leshoz";
                    break;
                case "felling":
                    x = "Felling";
                    break;
                case "shotPerformedFN":
                    x = "Employe";
                    break;
                case "planDrewFN":
                    x = "Employe";
                    break;
                default:
                    break;
            }

            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка відкриття БД");
            }
           
            string strSQL = $"SELECT * FROM {x}";
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

        public void ComboBox_Opened(ComboBox leshoz, ComboBox forestry)//обновление содержимого выпадающего списка при его открытие
        {
            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка відкриття БД");
            }

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

        public void ComboBox_Opened(ComboBox sender, Label shotPerformed, Label planDrew)//зависимость Label от выбора в ComboBox таблица Employee
        {
            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка відкриття БД");
            }

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
    }
}
