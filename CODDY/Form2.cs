using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Data.OleDb;
namespace Kursach
{
    public partial class Form2 : MaterialForm
    {
        public static string DirectiveDB = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Kursach.mdb";
        private OleDbConnection ConnectionDB;
        public Form2()
        {
            InitializeComponent();
            ConnectionDB = new OleDbConnection(DirectiveDB);
            ConnectionDB.Open();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        //Метод добавления изделия в таблице
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int Number = Convert.ToInt32(textBox1.Text);
                string Date = textBox2.Text;
                int InvertoryNumber = Convert.ToInt32(textBox3.Text);
                string Name = textBox4.Text;
                int colvo = Convert.ToInt32(textBox5.Text);
                string Money = textBox6.Text;
                string query = "INSERT INTO Изделия VALUES (" + Number + ", '" + Date + "', " + InvertoryNumber + ", '" + Name + "', " + colvo + ", '" + Money + "')";
                OleDbCommand command = new OleDbCommand(query, ConnectionDB);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные были добавлены!");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно указаны данные!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
