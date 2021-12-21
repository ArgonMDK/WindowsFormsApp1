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
    public partial class Form1 : Form
    {
        static string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
        SqlConnection cod = new SqlConnection();
        SqlCommand cmt = new SqlCommand();
        public Form1()
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            InitializeComponent();
            cod.ConnectionString = constr;
            cmt.Connection = cod;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ortoDataSet.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.ortoDataSet.Заказы);
            string connecionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
            //string sql = "SELECT * FROM Заказы";
            string sql = "SELECT Заказы.КодЗаказа, Сотрудники.ФамилияСотрудника, Товары.НаименованиеТовара, Заказы.ДатаИсполнения, Клиенты.ФамилияКлиента FROM Заказы JOIN Сотрудники on Сотрудники.КодСотрудника = Заказы.КодСотрудника JOIN Товары on Товары.КодТовара = Заказы.КодТовара JOIN Клиенты on Клиенты.КодКлиента = Заказы.КодКлиента";
            using (SqlConnection connection = new SqlConnection(connecionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 230;
                dataGridView1.Columns[4].Width = 130;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            cod.Open();
            cmt.CommandText = "insert into Заказы values ( '" + textBox1.Text + "','" + textBox2.Text + "', '" + Convert.ToString(textBox3.Text) + "', '" + textBox4.Text + "' )";
            cmt.ExecuteNonQuery();
            cod.Close();
            MessageBox.Show("Запись добавлена", "Добавлено");
        }

        private void button6_Click(object sender, EventArgs e)
        {
                string connecionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
                string sql = "SELECT Заказы.КодЗаказа, Сотрудники.ФамилияСотрудника, Товары.НаименованиеТовара, Заказы.ДатаИсполнения, Клиенты.ФамилияКлиента FROM Заказы JOIN Сотрудники on Сотрудники.КодСотрудника = Заказы.КодСотрудника JOIN Товары on Товары.КодТовара = Заказы.КодТовара JOIN Клиенты on Клиенты.КодКлиента = Заказы.КодКлиента";
                using (SqlConnection connection = new SqlConnection(connecionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[1].Width = 130;
                    dataGridView1.Columns[2].Width = 230;
                    dataGridView1.Columns[4].Width = 130;
            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connecionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
            string sql = "SELECT * FROM Клиенты";
            using (SqlConnection connection = new SqlConnection(connecionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void поставкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connecionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
            string sql = "SELECT * FROM Поставка";
            using (SqlConnection connection = new SqlConnection(connecionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void поставщикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connecionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
            string sql = "SELECT * FROM Поставщик";
            using (SqlConnection connection = new SqlConnection(connecionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connecionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
            string sql = "SELECT * FROM Сотрудники";
            using (SqlConnection connection = new SqlConnection(connecionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connecionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
            string sql = "SELECT * FROM Товары";
            using (SqlConnection connection = new SqlConnection(connecionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox7.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                        dataGridView1.Rows[i].Selected = false;

                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            f3.ShowDialog();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connecionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
            string sql = "SELECT Заказы.КодЗаказа, Сотрудники.ФамилияСотрудника, Товары.НаименованиеТовара, Заказы.ДатаИсполнения, Клиенты.ФамилияКлиента FROM Заказы JOIN Сотрудники on Сотрудники.КодСотрудника = Заказы.КодСотрудника JOIN Товары on Товары.КодТовара = Заказы.КодТовара JOIN Клиенты on Клиенты.КодКлиента = Заказы.КодКлиента";
            using (SqlConnection connection = new SqlConnection(connecionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 230;
                dataGridView1.Columns[4].Width = 130;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string sql = "DELETE from Заказы where КодЗаказа= " + dataGridView1.CurrentRow.Cells[0].Value;
                    string constring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=orto;Integrated Security=True";
                    using (SqlConnection col = new SqlConnection(constring))
                    {
                        col.Open();
                        SqlCommand cmdd = new SqlCommand(sql, col);
                        sql = "SELECT * from Заказы";
                        cmdd.ExecuteNonQuery();
                        DataSet ds = new DataSet();
                        SqlDataAdapter ad = new SqlDataAdapter(sql, constring);
                        ad.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        col.Close();
                    }
                }

            }
        }
    }
}
