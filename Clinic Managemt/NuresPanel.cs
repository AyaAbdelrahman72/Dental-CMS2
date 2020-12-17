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
    public partial class NuresPanel : Form
    {
        public NuresPanel()
        {
            InitializeComponent();
        }
        private void updateList(string query)
        {
            SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
            SqlCommand command = con.CreateCommand();
            con.Open();
            command.CommandText="SELECT  patient_id , patient_name   from [Patients] WHERE patient_name Like @query or patient_phone Like @query order by patient_name ";
            command.Parameters.AddWithValue("@query", query + "%");
            SqlDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                
                    listBox1.Items.Add(new Patient(reader.GetInt32(0), reader.GetString(1)));
               
            }
            


            con.Close();
        }

        private void NuresPanel_Load(object sender, EventArgs e)
        {
            //to fetch every account in the database
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            New_Patient NewPatient = new New_Patient();
            NewPatient.ShowDialog();
            Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateList(textBox1.Text);
        }
    }
}