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
namespace Clinic_Managemt
{
    public partial class New_Patient : Form
    {
        string Gendar = "";
        string payment = "";
        public New_Patient()
        {
            InitializeComponent();
        }

        private void New_Patient_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
        SqlCommand command;
        private void button1_Click(object sender, EventArgs e)
        {
            Insert();
            
        }
        public void Insert()
        {
            if (textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Please check the inputs");
                return;
            }
            //Account Creation
            command = con.CreateCommand();
            command.CommandText = "INSERT INTO Patients (patient_name ,patient_phone,patient_accountCreation,patient_DateOfBirth,medications,Visit_Doctor_Before,smoking,Address,[payment issue],Gendar,Tranquillizers,Diseas,dateoflastVisit) VALUES (@name,@phone,@date,@birth,@medications,@visit,@smoking,@address,@payment,@gendar,@tranqu,@diseas,@datevisit)";
            command.Parameters.AddWithValue("@name", textBox8.Text);
            command.Parameters.AddWithValue("@phone", textBox9.Text);

            command.Parameters.AddWithValue("@date", DateTime.Now);
            command.Parameters.AddWithValue("@birth", dateTimePicker1.Value);

            command.Parameters.AddWithValue("@datevisit", dateTimePicker2.Value);
            command.Parameters.AddWithValue("@medications", textBox11.Text);
            command.Parameters.AddWithValue("@visit", checkBox1.Checked);
            command.Parameters.AddWithValue("@smoking", checkBox2.Checked);
            command.Parameters.AddWithValue("@tranqu", checkBox3.Checked);
            command.Parameters.AddWithValue("@address", textBox1.Text);

            command.Parameters.AddWithValue("@gendar", Gendar);
            string s = "";

            command.Parameters.AddWithValue("@payment", payment);

            if (checkBox4.Checked)
            {
                s = checkBox4.Text + ',' + s;
            }
            if (checkBox5.Checked)
            {
                s = checkBox5.Text + ',' + s;
            }
            if (checkBox6.Checked)
            {
                s = checkBox6.Text + ',' + s;
            }
            if (checkBox7.Checked)
            {
                s = checkBox7.Text + ',' + s;
            }
            if (checkBox8.Checked)
            {
                s = checkBox8.Text + ',' + s;
            }
            if (checkBox9.Checked)
            {
                s = checkBox9.Text + ',' + s;
            }
            if (checkBox10.Checked)
            {
                s = checkBox10.Text + ',' + s;
            }
            if (checkBox11.Checked)
            {
                s = checkBox11.Text + ',' + s;
            }
            if (checkBox12.Checked)
            {
                s = checkBox12.Text + ',' + s;
            }
            if (checkBox13.Checked)
            {
                s = checkBox13.Text + ',' + s;
            }
            if (checkBox14.Checked)
            {
                s = checkBox14.Text + ',' + s;
            }
            if (checkBox15.Checked)
            {
                s = checkBox15.Text + ',' + s;
            }
            if (checkBox16.Checked)
            {
                s = checkBox16.Text + ',' + s;
            }
            if (checkBox17.Checked)
            {
                s = checkBox17.Text + ',' + s;
            }
            if (checkBox18.Checked)
            {
                s = checkBox18.Text + ',' + s;
            }
            if (checkBox19.Checked)
            {
                s = checkBox19.Text + ',' + s;
            }
            if (checkBox20.Checked)
            {
                s = checkBox20.Text + ',' + s;
            }
            if (checkBox21.Checked)
            {
                s = checkBox21.Text + ',' + s;
            }
            if (checkBox22.Checked)
            {
                s = checkBox22.Text + ',' + s;
            }
            if (checkBox23.Checked)
            {
                s = checkBox23.Text + ',' + s;
            }

            command.Parameters.AddWithValue("@diseas", s);


            con.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Account was created successfully...!");
            }
            else
            {
                MessageBox.Show("Failed to create the account");
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diseas diseas = new Diseas();
            diseas.ShowDialog();
            Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gendar = "Female";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gendar = "Male";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            payment = "Insured";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            payment = "private";
        }
    }
    }

