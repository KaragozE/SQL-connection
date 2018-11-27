using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public string connetionString = "Data Source=DMGM0349997\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
        

        
        
               private void button1_Click(object sender, EventArgs e)
        {
            
                string sql = "SELECT [Order Details].OrderID,Products.ProductName,[Order Details].UnitPrice,[Order Details].Quantity,[Order Details].Discount FROM Products INNER JOIN[Order Details] ON[Order Details].ProductID = Products.ProductID \n where OrderID=10249 ";
                SqlConnection connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                   SqlCommand command = new SqlCommand(sql, connection);
                   SqlDataReader  dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                         
                        MessageBox.Show(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                    }
                    dataReader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                  MessageBox.Show("Can not open connection ! ");
               }
        }
        //{
        //    string connetionString = null;
        //    SqlConnection connection;
        //    SqlCommand command;
        //    string sql = null;
        //    SqlDataReader dataReader;
        //    connetionString = "Data Source=DMGM0349997\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True ";
        //    sql = "SELECT [Order Details].OrderID,Products.ProductName,[Order Details].UnitPrice,[Order Details].Quantity,[Order Details].DiscountFROM Products INNER JOIN[Order Details] ON[Order Details].ProductID = Products.ProductID; ";
        //    connection = new SqlConnection(connetionString);
        //    try
        //    {
        //        connection.Open();
        //        command = new SqlCommand(sql, connection);
        //        dataReader = command.ExecuteReader();
        //        while (dataReader.Read())
        //        {
        //            MessageBox.Show(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
        //        }
        //        dataReader.Close();
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Can not open connection ! ");
        //    }



    }
}
