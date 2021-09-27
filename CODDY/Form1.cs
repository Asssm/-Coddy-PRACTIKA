using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Внешний вид программы
using MaterialSkin.Controls;
//Подключения бд 
using System.Data.OleDb;
namespace Kursach
{
    public partial class Form1 : MaterialForm
    {
        //Путь до бд
        public static string DirectiveDB = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Kursach.mdb";
        private OleDbConnection ConnectionDB;//Подкючение бд
        public Form1()
        {
            ConnectionDB = new OleDbConnection(DirectiveDB);
            ConnectionDB.Open();
            InitializeComponent();
            this.MaximizeBox = false;//Запрещает изменять формат бд
            this.MinimizeBox = false;
            comboBox1.Items.Add("Дата");
            comboBox1.Items.Add("Группа");
            comboBox1.Items.Add("ФИО");
            comboBox1.Items.Add("Возраст");
            comboBox1.Items.Add("Класс");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursachDataSet.Изделия". При необходимости она может быть перемещена или удалена.
            this.изделияTableAdapter.Fill(this.kursachDataSet.Изделия);
        }
         
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectionDB.Close();
        }
        //Метод удаления изделия из таблицы
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(textBox1.Text);
                String query = "DELETE FROM [Изделия] WHERE [Порядковый номер] = " + ID;
                OleDbCommand command = new OleDbCommand(query, ConnectionDB);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные были удалены!");
                this.изделияTableAdapter.Fill(this.kursachDataSet.Изделия);
            }
            catch (Exception) 
            {
                MessageBox.Show("Неверно указан порядковый номер!");
            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            this.изделияTableAdapter.Fill(this.kursachDataSet.Изделия);
        }
        //Метод изменения изделия в таблице
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                String Select = comboBox1.SelectedItem.ToString();
                if (Select.Equals("Дата"))
                {
                    int ID = Convert.ToInt32(textBox1.Text);
                    String NewInfo = textBox2.Text;
                    string query = "UPDATE Изделия SET Дата = '" + NewInfo + "' WHERE [Порядковый номер] = " + ID;
                    OleDbCommand command = new OleDbCommand(query, ConnectionDB);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные были изменены!");
                    this.изделияTableAdapter.Fill(this.kursachDataSet.Изделия);
                }
                else if (Select.Equals("Группа"))
                {
                    int ID = Convert.ToInt32(textBox1.Text);
                    String NewInfo = textBox2.Text;
                    string query = "UPDATE Изделия SET [Инвентарный номер] = '" + NewInfo + "' WHERE [Порядковый номер] = " + ID;
                    OleDbCommand command = new OleDbCommand(query, ConnectionDB);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные были изменены!");
                    this.изделияTableAdapter.Fill(this.kursachDataSet.Изделия);
                }
                else if (Select.Equals("ФИО"))
                {
                    int ID = Convert.ToInt32(textBox1.Text);
                    String NewInfo = textBox2.Text;
                    string query = "UPDATE Изделия SET Название = '" + NewInfo + "' WHERE [Порядковый номер] = " + ID;
                    OleDbCommand command = new OleDbCommand(query, ConnectionDB);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные были изменены!");
                    this.изделияTableAdapter.Fill(this.kursachDataSet.Изделия);
                }
                else if (Select.Equals("Возраст"))
                {
                    int ID = Convert.ToInt32(textBox1.Text);
                    String NewInfo = textBox2.Text;
                    string query = "UPDATE Изделия SET Количество = '" + NewInfo + "' WHERE [Порядковый номер] = " + ID;
                    OleDbCommand command = new OleDbCommand(query, ConnectionDB);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные были изменены!");
                    this.изделияTableAdapter.Fill(this.kursachDataSet.Изделия);
                }
                else if (Select.Equals("класс"))
                {
                    int ID = Convert.ToInt32(textBox1.Text);
                    String NewInfo = textBox2.Text;
                    string query = "UPDATE Изделия SET Цена = '" + NewInfo + "' WHERE [Порядковый номер] = " + ID;
                    OleDbCommand command = new OleDbCommand(query, ConnectionDB);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные были изменены!");
                    this.изделияTableAdapter.Fill(this.kursachDataSet.Изделия);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно указаны данные!");
            }
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.Show();
        }
    }
}