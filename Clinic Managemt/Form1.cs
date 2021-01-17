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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   //to fetch connection
            string connectionString = Clinic_Managemt.Properties.Resources.ConnectionString;
            // to create connection object
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = con.CreateCommand();
            command.CommandText = "select user_id FROM [users] WHERE user_username=@username AND user_password=@password";
            command.Parameters.AddWithValue("@username",textBox1.Text);
            command.Parameters.AddWithValue("@password",textBox2.Text);
            con.Open();
            var result = command.ExecuteScalar();
            con.Close();
            if (result != null)
            {
                //Authenticated
                if (textBox1.Text == "Doctor")
                {
                    //Doctor Panel
                    Hide();
                    Doctor_Panel DoctorPanel = new Doctor_Panel();
                    DoctorPanel.ShowDialog();
                    Show();
                }
                else
                {  //nursePanel
                    Hide();
                    NuresPanel NursePanel = new NuresPanel();
                    NursePanel.ShowDialog();
                    Show();
                }
            }
            else
            {
                MessageBox.Show("Authentication Failed");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
