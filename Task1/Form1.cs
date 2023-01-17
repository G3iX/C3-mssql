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
//using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
//using System.Data.MySql;

namespace Task1
{
    public partial class Form1 : Form
    {
        //Server=myServerAddress; Port=1234; Database=myDataBase; Uid=myUsername; Pwd=myPassword; Port=14690;
        public static string connectionString = "Server=172.21.201.51;Database=Philosophy_mod; Uid=admin; pwd=qwerty03";
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "philosophy_modDataSet.PhyFlowTab". При необходимости она может быть перемещена или удалена.
            // list
            

            MySqlConnection Conn = new MySqlConnection(connectionString);
            string command2 = "SELECT * FROM Philosophy_mod.PhyFlowTab";
            MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
            Conn.Open();
            MySqlDataReader DR1 = Comm2.ExecuteReader();
            if (DR1.Read())
            {
                string data = DR1.GetString("Description");
                comboBox1.Items.Add(data);
                while (DR1.Read())
                {
                    data = DR1.GetString("Description");
                    comboBox1.Items.Add(data);
                }
            }
            Conn.Close();
            


        }
        // CHECK LIST 
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void philosophersTabBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.philosophersTabBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.philosophy_modDataSet);

        }

        // RADIO BUTTON
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            checkBox2.Checked = false;
            checkBox2.Enabled = true;
            textBox7.Enabled = false;
            textBox7.BackColor = System.Drawing.Color.AliceBlue;
            textBox7.Text = "";
            textBox8.Enabled = false;
            textBox8.BackColor = System.Drawing.Color.AliceBlue;
            textBox8.Text = "";
            textBox9.Enabled = false;
            textBox9.BackColor = System.Drawing.Color.AliceBlue;
            textBox9.Text = "";
            textBox10.Enabled = false;
            textBox10.BackColor = System.Drawing.Color.AliceBlue;
            textBox10.Text = "";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            if (radioButton2.Checked == true)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
            textBox7.Enabled = false;
            textBox7.BackColor = System.Drawing.Color.AliceBlue;
            textBox7.Text = "";
            textBox8.Enabled = true;
            textBox8.BackColor = System.Drawing.Color.White;
            textBox9.Enabled = true;
            textBox9.BackColor = System.Drawing.Color.White;
            textBox10.Enabled = true;
            textBox10.BackColor = System.Drawing.Color.White;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox2.Enabled = false;
            textBox7.Enabled = true;
            textBox7.BackColor = System.Drawing.Color.White;
            textBox8.Enabled = true;
            textBox8.BackColor = System.Drawing.Color.White;
            textBox9.Enabled = true;
            textBox9.BackColor = System.Drawing.Color.White;
            textBox10.Enabled = true;
            textBox10.BackColor = System.Drawing.Color.White;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox2.Enabled = false;
            textBox7.Enabled = true;
            textBox7.BackColor = System.Drawing.Color.White;
            textBox8.Enabled = false;
            textBox8.BackColor = System.Drawing.Color.AliceBlue;
            textBox8.Text = "";
            textBox9.Enabled = false;
            textBox9.BackColor = System.Drawing.Color.AliceBlue;
            textBox9.Text = "";
            textBox10.Enabled = false;
            textBox10.BackColor = System.Drawing.Color.AliceBlue;
            textBox10.Text = "";
        }

        // Commands 
        public void command_E(string command_type)
        {
            MySqlConnection Conn = new MySqlConnection(connectionString);
            if (command_type == "Add")
            {
                string FN_text = textBox8.Text.ToString();
                string MN_text = textBox9.Text.ToString();
                string SN_text = textBox10.Text.ToString();
                int PID = Int32.Parse((comboBox1.SelectedIndex + 1).ToString());
                string command1 = "insert into PhilosophersTab values(null,'" + FN_text + "','" + MN_text + "','" + SN_text + "'," + PID + ");";
                MySqlCommand Comm1 = new MySqlCommand(command1, Conn);
                Conn.Open();
                MySqlDataReader DR2 = Comm1.ExecuteReader();
                Conn.Close();
                Conn.Open();
                string command2 = "select * from PhilosophersTab\n";
                MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                MySqlDataReader DR1 = Comm2.ExecuteReader();
                if (DR1.Read())
                {
                    //richTextBox1.Text += "   ID          FirstName           MiddleName     Surname     PhyFlowID" + System.Environment.NewLine;
                    string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}\n";
                    richTextBox1.Text = text_retr;
                    while (DR1.Read())
                    {
                        richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}" + System.Environment.NewLine;
                    }
                }
                textBox1.Text = "Adding data" + System.Environment.NewLine;
                textBox1.Text += $"RecordsAffected {DR2.RecordsAffected}\n\n" + System.Environment.NewLine;
                Conn.Close();
            }
            else if (command_type == "Upd")
            {
                string FN_text = textBox8.Text.ToString();
                string MN_text = textBox9.Text.ToString();
                string SN_text = textBox10.Text.ToString();
                string data = comboBox1.Text.ToString();
                string command_for_id = "select PhyFlowID from PhyFlowTab where Description = '" + data + "'";
                MySqlCommand Comm_add = new MySqlCommand(command_for_id, Conn);
                Conn.Open();
                MySqlDataReader DR_loca = Comm_add.ExecuteReader();
                if (DR_loca.Read())
                {
                    string id_data = $"{DR_loca[0].ToString(),15}"; 
                    richTextBox1.Text = id_data;
                }
                Conn.Close();
                string PID = richTextBox1.Text; // bad, by ok for me :)
                string ID_text = textBox7.Text.ToString();
                string command1 = "update PhilosophersTab set FirstName = '"+ FN_text + "', MiddleName = '" + MN_text + "', Surname = '" + SN_text + "', PhyFlowID = " + PID + " where ID = " + ID_text + "";
                MySqlCommand Comm1 = new MySqlCommand(command1, Conn);
                Conn.Open();
                MySqlDataReader DR2 = Comm1.ExecuteReader();
                Conn.Close();
                Conn.Open();
                string command2 = "select * from PhilosophersTab\n";
                MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                MySqlDataReader DR1 = Comm2.ExecuteReader();
                if (DR1.Read())
                {
                    //richTextBox1.Text += "   ID          FirstName           MiddleName     Surname     PhyFlowID" + System.Environment.NewLine;
                    string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}\n";
                    richTextBox1.Text = text_retr;
                    while (DR1.Read())
                    {
                        richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}" + System.Environment.NewLine;
                    }
                }
                textBox1.Text = "Updating data" + System.Environment.NewLine;
                textBox1.Text += $"RecordsAffected {DR2.RecordsAffected}\n\n" + System.Environment.NewLine;
                Conn.Close();
            }
            else if (command_type == "Del")
            {
                string ID_text = textBox7.Text.ToString();
                string command1 = "delete from PhilosophersTab where ID="+ ID_text + "";
                MySqlCommand Comm1 = new MySqlCommand(command1, Conn);
                Conn.Open();
                MySqlDataReader DR2 = Comm1.ExecuteReader();
                Conn.Close();
                Conn.Open();
                string command2 = "select * from PhilosophersTab\n";
                MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                MySqlDataReader DR1 = Comm2.ExecuteReader();
                if (DR1.Read())
                {
                    //richTextBox1.Text += "   ID          FirstName           MiddleName     Surname     PhyFlowID" + System.Environment.NewLine;
                    string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}\n";
                    richTextBox1.Text = text_retr;
                    while (DR1.Read())
                    {
                        richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}" + System.Environment.NewLine;
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
        public void combobox_E(int num_c)
        {
            richTextBox1.Text = "";
            MySqlConnection Conn = new MySqlConnection(connectionString);
            string command = "select * from PhilosophersTab where PhilosophersTab.PhyFlowID = ";
            command += num_c;
            MySqlCommand Comm1 = new MySqlCommand(command, Conn);
            Conn.Open();
            MySqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}\n";// + System.Environment.NewLine;
                richTextBox1.Text += text_retr;
                while (DR1.Read())
                {
                    richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}\n";// + System.Environment.NewLine;
                }
            }
        }
        // BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {   
                if (checkBox1.Checked == true)
                {
                    if (comboBox1.Enabled)
                    {
                        MySqlConnection Conn = new MySqlConnection(connectionString);
                        string data = comboBox1.Text.ToString();
                        string command_for_id = "select PhyFlowID from PhyFlowTab where Description = '" + data + "'";

                        MySqlCommand Comm_add = new MySqlCommand(command_for_id, Conn);
                        Conn.Open();
                        MySqlDataReader DR_loca = Comm_add.ExecuteReader();
                        string id_data = "";
                        if (DR_loca.Read())
                        {
                            id_data = $"{DR_loca[0].ToString(),15}";
                            //richTextBox1.Text = id_data;
                        }
                        Conn.Close();
                        combobox_E(Int32.Parse(id_data));
                        textBox1.Text += "Retrieving data about philosophy flow " + comboBox1.Text.ToString();
                    }
                    //textBox1.Text = "Retrieving data about all philosophers by their flow  " ;
                }
                else if (checkBox2.Checked == true)
                {
                    richTextBox1.Text = "";
                    MySqlConnection Conn = new MySqlConnection(connectionString);
                    string command = "select * from PhilosophersTab\n";
                    MySqlCommand Comm1 = new MySqlCommand(command, Conn);
                    Conn.Open();
                    MySqlDataReader DR1 = Comm1.ExecuteReader();
                    if (DR1.Read())
                    {
                        //richTextBox1.Text += "   ID          FirstName           MiddleName     Surname     PhyFlowID" + System.Environment.NewLine;
                        string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}\n";
                        richTextBox1.Text += text_retr;
                        while (DR1.Read())
                        {
                            richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}\n";// + System.Environment.NewLine;
                        }
                    }
                    textBox1.Text = $"RecordsAffected {DR1.RecordsAffected}\n\n" + System.Environment.NewLine;
                    Conn.Close();
                    textBox1.Text += "Retrieving data about all philosophers by their ID";
                }
                else
                {
                    //richTextBox1.Text = "Error";
                    //textBox1.Text += "Error";
                    //checkBox1.Checked = true;
                    richTextBox1.Text = "";
                    MySqlConnection Conn = new MySqlConnection(connectionString);
                    string command = "select PhilosophersTab.ID,PhilosophersTab.FirstName,PhilosophersTab.MiddleName,PhilosophersTab.Surname,PhilosophersTab.PhyFlowID,PhyFlowTab.Description\r\nfrom PhilosophersTab\r\nINNER JOIN PhyFlowTab ON PhyFlowTab.PhyFlowID = PhilosophersTab.PhyFlowID;";
                    MySqlCommand Comm1 = new MySqlCommand(command, Conn);
                    Conn.Open();
                    MySqlDataReader DR1 = Comm1.ExecuteReader();
                    if (DR1.Read())
                    {
                        //richTextBox1.Text += "\tID       \t   FirstName           \t\tMiddleName     \t   Surname     \t     PhyFlowID" + System.Environment.NewLine;
                        string text_retr = $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}{DR1[5].ToString(),30}\n"; // + System.Environment.NewLine;
                        richTextBox1.Text += text_retr;
                        while (DR1.Read())
                        {
                            richTextBox1.Text += $"{DR1[0].ToString(),15}\t{DR1[1].ToString(),20}\t\t{DR1[2].ToString(),10}\t{DR1[3].ToString(),30}\t{DR1[4].ToString(),15}{DR1[5].ToString(),30}\n";// + System.Environment.NewLine;
                        }
                    }
                    textBox1.Text = $"RecordsAffected {DR1.RecordsAffected}\n\n" + System.Environment.NewLine;
                    Conn.Close();
                    textBox1.Text += "Retrieving data about all philosophers with their flows";
                    
                }
            }
            if (radioButton2.Checked == true)
            {
                
                try
                {
                    command_E("Add");
                }
                catch
                {
                    textBox1.Text = "Error in Adding";
                }
            }
            if (radioButton3.Checked == true)
            {
                command_E("Upd");
                /*try
                {
                    
                }
                catch
                {
                    textBox1.Text = "Error in updating";
                }*/
            }
            if (radioButton4.Checked == true)
            {
                try
                {
                    command_E("Del");
                }
                catch
                {
                    textBox1.Text += "Error in deleting";
                }
            }
        }
        // Open sub folder 
        private void button2_Click(object sender, EventArgs e)
        {

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            comboBox1.Enabled = true;
            //
            //if (comboBox1.Enabled)
            //{
            //    combobox_E(comboBox1.SelectedIndex + 1);
            //    textBox1.Text = "Retrieving data about philosophy flow " + comboBox1.Text.ToString();
            // }
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
        // TEXT BOX
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
        // Check BOX
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox1.Enabled = !checkBox2.Checked;
        }   
        //COMBOBOX
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox1.Text += comboBox1.Text.ToString();
            //textBox1.Text += comboBox1.SelectedIndex.ToString();
            //textBox1.Text += (comboBox1.SelectedIndex + 1).ToString();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
