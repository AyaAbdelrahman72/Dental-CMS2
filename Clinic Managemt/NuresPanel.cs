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
        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
        SqlCommand command;

      

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
            try
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT patient_name,patient_accountCreation from Patients where patient_name  like @search+'%' ORDER BY patient_accountCreation DESC, patient_name";
                command.Parameters.AddWithValue("@search", textBox1.Text);
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                 da.Fill(dt);
                 PatientFromNurseView.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                con.Close();
            }
        }
       


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}