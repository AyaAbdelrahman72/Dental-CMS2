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
    public partial class Manage_Patient : Form
    {
        string Gendar = "";
        string payment = "";
        public Manage_Patient()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
        SqlCommand command;
        int patientID = 0;
      

        private void Manage_Patient_Load(object sender, EventArgs e)
        {
            con.Open();
            display();
        }
      

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            searchPatient();
        }
        public void  searchPatient()
        {
            try
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT patient_id,patient_name,patient_accountCreation from Patients where patient_name  like @search+'%' ORDER BY patient_accountCreation DESC, patient_name";
                command.Parameters.AddWithValue("@search", textBox1.Text);
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                PatientsForm.DataSource = dt;
                PatientsForm.Columns[0].Visible = false;
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
       
       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            New_Patient NewPatient = new New_Patient();
            NewPatient.ShowDialog();
            Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (patientID == 0)
            {
                MessageBox.Show("There is no selected data to be updated----------------");
            }
            else if (textBox8.Text == "" )
            {
                MessageBox.Show("Please check the inputs");
                return;
            }
           
            else
            {
                try
                {
                    con.Open();
                    command = con.CreateCommand();
                    command.CommandText = "UPDATE Patients SET patient_name=@name,patient_phone=@phone,Visit_Doctor_Before=@visitbefore,[payment issue]=@payment,smoking=@smoking,medications=@medications,patient_DateOfBirth=@birthdate,Gendar=@gendar,Address=@address,dateoflastVisit=@dlastvisit,reasonoflastVisit=@reason,Tranquillizers=@tranq , Diseas=@diseas WHERE patient_id=@id";
                    command.Parameters.AddWithValue("@id", patientID);
                    command.Parameters.AddWithValue("@name", textBox8.Text);
                    command.Parameters.AddWithValue("@phone", textBox9.Text);
                    command.Parameters.AddWithValue("@visitbefore", checkBox1.Checked);
                    command.Parameters.AddWithValue("@payment", payment);
                    command.Parameters.AddWithValue("@smoking", checkBox2.Checked);
                    command.Parameters.AddWithValue("@medications", textBox11.Text);
                    command.Parameters.AddWithValue("@birthdate", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@gendar", Gendar);
                    command.Parameters.AddWithValue("@address", textBox3.Text);
                    command.Parameters.AddWithValue("@dlastvisit", dateTimePicker2.Value);
                    command.Parameters.AddWithValue("@reason", textBox2.Text);
                    command.Parameters.AddWithValue("@tranq", checkBox3.Checked);
                    string s = "";
                    

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
                  

                    command.ExecuteNonQuery();
                    MessageBox.Show("Account updated Successfully");
                    display();
                  
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update");
                }
                finally
                {
                    con.Close();
                    reset();
                }

            }
        }
        public void display()
        {   
        
            SqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT patient_name,patient_phone,patient_accountCreation from Patients ORDER BY patient_accountCreation DESC,patient_name";
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            PatientsForm.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (patientID == 0)
            {
                MessageBox.Show("There is no selected data to be deleted");
            }
            else
            {

                if (MessageBox.Show("Do you want to remove this patient", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        SqlCommand command = con.CreateCommand();
                        command.CommandText = "Delete  from Patients where patient_id='" + patientID + "'";
                        command.ExecuteNonQuery();

                        MessageBox.Show("Deleted Successfully");
                        reset();
                        display();
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
                else
                {
                    MessageBox.Show("Patient is not removed");
                }
            }
        }

        private void PatientsForm_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (PatientsForm.CurrentRow.Index != -1)
                {
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                    checkBox8.Checked = false;
                    checkBox9.Checked = false;
                    checkBox10.Checked = false;
                    checkBox11.Checked = false;
                    checkBox12.Checked = false;
                    checkBox13.Checked = false;
                    checkBox14.Checked = false;
                    checkBox15.Checked = false;
                    checkBox16.Checked = false;
                    checkBox17.Checked = false;
                    checkBox18.Checked = false;
                    checkBox19.Checked = false;
                    checkBox20.Checked = false;


                    command = con.CreateCommand();
                    patientID = Convert.ToInt32(PatientsForm.CurrentRow.Cells[0].Value.ToString());
                    command.CommandText = "SELECT patient_name,patient_phone,patient_accountCreation,patient_DateOfBirth,medications,Visit_Doctor_Before,smoking,Address,[payment issue],Gendar,Tranquillizers,Diseas,dateoflastVisit,reasonoflastVisit FROM Patients WHERE patient_id=@patientID";
                    command.Parameters.AddWithValue("@patientID", patientID);

                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.Read())
                    {

                        textBox8.Text = reader.GetString(0);
                        DateTime dob = new DateTime();
                        if (DateTime.TryParse(reader.GetValue(3).ToString(), out dob)) ;
                        dateTimePicker1.Value = dob;
                        DateTime dlastvisit = new DateTime();
                        if (DateTime.TryParse(reader.GetValue(12).ToString(), out dlastvisit)) ;
                        dateTimePicker2.Value = dlastvisit;

                        textBox3.Text= reader.GetValue(7).ToString();
                        textBox5.Text = reader.GetValue(2).ToString();
                        textBox9.Text = reader.GetInt32(1).ToString();
                        textBox2.Text = reader.GetValue(12).ToString();

                        if (reader.GetValue(9).ToString() == "Female")
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                        if (reader.GetValue(8).ToString() == "Insured")
                        {
                            radioButton3.Checked = true;
                        }
                        else
                        {
                            radioButton4.Checked = true;
                        }


                        textBox11.Text = reader.GetString(4);
                        if (reader.GetInt32(6) == 1)
                        {
                            checkBox2.Checked = true;
                        }
                        if (reader.GetInt32(5) == 1)
                        {
                            checkBox1.Checked = true;
                        }
                        if (reader.GetInt32(10) == 1)
                        {
                            checkBox3.Checked = true;
                        }
                        string diseasList = reader["Diseas"].ToString();
                        string[] diseas = diseasList.Split(',');
                       
                        foreach (Control cc in this.Controls)
                        {
                            if (cc is CheckBox)
                            {
                                CheckBox b = (CheckBox)cc;
                                for (int i = 0; i < diseas.Length; i++)
                                {
                                    if (diseas[i].ToString() == b.Text)
                                    {
                                        b.Checked = true;
                                    }

                                }
                               

                            }
                        }
                       
                    }
                }
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
        void reset()
        {
          
            textBox8.Text= textBox9.Text = textBox11.Text= textBox3.Text = textBox2.Text="";
            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = false;
           
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;


            dateTimePicker1.CustomFormat = dateTimePicker2.CustomFormat = " ";



            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            New_Patient patient = new New_Patient();
            patient.Insert();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}
