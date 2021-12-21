using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
        SqlConnection cod = new SqlConnection();
        SqlCommand cmt = new SqlCommand();
        int КодЗаказа;
        public Form3(int Заказы)
        {
            InitializeComponent();
            КодЗаказа = Заказы;
            cod.ConnectionString = constr;
            cmt.Connection = cod;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cod.Open();
            cmt.CommandText = "update [Заказы] set КодСотрудника = '" + textBox1.Text + "', КодТовара = '" + textBox2.Text + "', ДатаИсполнения = '" + textBox3.Text + "', КодКлиента = '" + textBox4.Text + "' where [КодЗаказа]= " + КодЗаказа;
            cmt.ExecuteNonQuery();
            cod.Close();
            MessageBox.Show("Измененно");
            Close();
        }
    }
}
