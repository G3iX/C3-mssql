using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task1
{
    public partial class Form2 : Form
    {
        public static string connectionString = "Server=172.21.201.51;Database=Philosophy_mod;Uid=admin;Pwd=qwerty03";
        public static string UndoString = "";
        public static string UndoData = "";
        public static int clicker = 0;
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += Form2_FormClosing;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "philosophy_modDataSet.PhyFlowTab". При необходимости она может быть перемещена или удалена.
            this.phyFlowTabTableAdapter.Fill(this.philosophy_modDataSet.PhyFlowTab);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "philosophy_modDataSet.PhilosophersTab". При необходимости она может быть перемещена или удалена.
            this.philosophersTabTableAdapter.Fill(this.philosophy_modDataSet.PhilosophersTab);
            //this.phyFlowTabTableAdapter.Fill(this.philosophy_modDataSet.PhyFlowTab);
        }

        private void Form2_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show(this, "Are you sure?", "Do you still want to exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Form1 f1 = new Form1();
            f1.Show();
            //this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // RADIOBUTTON
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //richTextBox1.Text = "";
            textBox7.Enabled = false;
            textBox7.BackColor = System.Drawing.Color.AliceBlue;
            textBox7.Text = "";
            textBox11.BackColor = System.Drawing.Color.AliceBlue;
            textBox11.Enabled = false;
            textBox11.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //richTextBox1.Text = "";
            textBox7.Enabled = true;
            textBox7.BackColor = System.Drawing.Color.White;
            textBox11.BackColor = System.Drawing.Color.AliceBlue;
            textBox11.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Enabled = true;
            textBox7.BackColor = System.Drawing.Color.White;
            textBox11.BackColor = System.Drawing.Color.White;
            textBox11.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Enabled = false;
            textBox7.BackColor = System.Drawing.Color.AliceBlue;
            textBox7.Text = "";
            textBox11.BackColor = System.Drawing.Color.White;
            textBox11.Enabled = true;
        }

        //CMDS
        public void command_E(string command_type)
        {
            MySqlConnection Conn = new MySqlConnection(connectionString);
            if (command_type == "Add")
            {
                string DE_text = textBox7.Text.ToString();
                string PID = textBox11.Text.ToString();
                string command1 = "insert into PhyFlowTab values(null,'" + DE_text + "')";
                MySqlCommand Comm1 = new MySqlCommand(command1, Conn);
                Conn.Open();
                MySqlDataReader DR2 = Comm1.ExecuteReader();
                Conn.Close();
                Conn.Open();
                string command2 = "select * from [Philosophy_mod].[dbo].PhyFlowTab\n";
                MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                MySqlDataReader DR1 = Comm2.ExecuteReader();
                if (DR1.Read())
                {
                    string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}" + System.Environment.NewLine;
                    richTextBox1.Text = text_retr;
                    while (DR1.Read())
                    {
                        richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}" + System.Environment.NewLine;
                    }
                }
                textBox1.Text = "Adding data" + System.Environment.NewLine;
                textBox1.Text += $"RecordsAffected {DR2.RecordsAffected}\n\n" + System.Environment.NewLine;
                Conn.Close();
            }
            else if (command_type == "Upd")
            {
                string DE_text = textBox7.Text.ToString();
                string PID = textBox11.Text.ToString();
                string command1 = "update PhyFlowTab set Description = '"+ DE_text + "' where PhyFlowID = " + PID + "";
                MySqlCommand Comm1 = new MySqlCommand(command1, Conn);
                Conn.Open();
                MySqlDataReader DR2 = Comm1.ExecuteReader();
                Conn.Close();
                Conn.Open();
                string command2 = "select * from [Philosophy_mod].[dbo].PhyFlowTab\n";
                MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                MySqlDataReader DR1 = Comm2.ExecuteReader();
                if (DR1.Read())
                {
                    //richTextBox1.Text += "   ID          FirstName           MiddleName     Surname     PhyFlowID" + System.Environment.NewLine;
                    string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}" + System.Environment.NewLine;
                    richTextBox1.Text = text_retr;
                    while (DR1.Read())
                    {
                        richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}" + System.Environment.NewLine;
                    }
                }
                textBox1.Text = "Updating data" + System.Environment.NewLine;
                textBox1.Text += $"RecordsAffected {DR2.RecordsAffected}\n\n" + System.Environment.NewLine;
                Conn.Close();
            }
            else if (command_type == "Del")
            {
                string ID_text = textBox11.Text.ToString();
                string command1 = "delete from PhyFlowTab where PhyFlowID=" + ID_text + "";
                MySqlCommand Comm1 = new MySqlCommand(command1, Conn);
                Conn.Open();
                MySqlDataReader DR2 = Comm1.ExecuteReader();
                Conn.Close();
                Conn.Open();
                string command2 = "select * from [Philosophy_mod].[dbo].PhyFlowTab\n";
                MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                MySqlDataReader DR1 = Comm2.ExecuteReader();
                if (DR1.Read())
                {
                    //richTextBox1.Text += "   ID          FirstName           MiddleName     Surname     PhyFlowID" + System.Environment.NewLine;
                    string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}" + System.Environment.NewLine;
                    richTextBox1.Text = text_retr;
                    while (DR1.Read())
                    {
                        richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}" + System.Environment.NewLine;
                    }
                }
                textBox1.Text = "Deleting data" + System.Environment.NewLine;
                textBox1.Text += $"RecordsAffected {DR2.RecordsAffected}\n\n" + System.Environment.NewLine;
                Conn.Close();
            }
            else
            {
                textBox1.Text = "ERR/0X004";
            }
            //textBox1.Text += "Retrieving data about all philosophers by their flow";
        }


        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                clicker += 1;
                richTextBox1.Text = "";
                MySqlConnection Conn = new MySqlConnection(connectionString);
                string command = "select * from PhyFlowTab";
                MySqlCommand Comm1 = new MySqlCommand(command, Conn);
                Conn.Open();
                MySqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}" + System.Environment.NewLine;
                    richTextBox1.Text += text_retr;
                    while (DR1.Read())
                    {
                        richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}" + System.Environment.NewLine;
                    }
                }
                Conn.Close();
                textBox1.Text = "Retrieving all pilosophy flows data";

            }
            if (radioButton2.Checked == true)
            {
                command_E("Add");

            }
            if (radioButton3.Checked == true)
            {
                command_E("Upd");

            }
            if (radioButton4.Checked == true)
            {
                command_E("Del");
                /*try
                {
                    
                }
                catch
                {
                    textBox1.Text += "Error in deleting";
                }*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // open back forst form
            //this.FormClosing += Form2_FormClosing;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void philosophersTabBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.philosophersTabBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.philosophy_modDataSet);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
