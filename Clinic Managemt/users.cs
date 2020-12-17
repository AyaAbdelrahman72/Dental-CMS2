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
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
        SqlCommand command;
        int userID = 0;


        private void users_Load(object sender, EventArgs e)
        {
            con.Open();
            display();
        }
        public void display()
        {
           
            SqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from users ORDER BY account_Creation DESC, user_username";
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            UsersList.DataSource = dt;
            UsersList.Columns[0].Visible = false;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please check the inputs");
                return;
            }
            try
            {
                
                //Account Creation
                command = con.CreateCommand();
                command.CommandText = "INSERT INTO users (user_username,user_password,account_Creation) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "',@date)";
                command.Parameters.AddWithValue("@date", DateTime.Now);
                con.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Account was created successfully...!");
                    reset();
                }
                else
                {
                    MessageBox.Show("Failed to create the account");
                }
                display();
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message");
            }
            finally
            {
                con.Close();
            }
           
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (userID == 0)
            {
                MessageBox.Show("There is no selected row to be deleted");
            }
            else {
                if (MessageBox.Show("Do you want to remove this user", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        SqlCommand command = con.CreateCommand();
                        command.CommandText = "Delete  from users where user_id=@id";
                        command.Parameters.AddWithValue("@id", userID);
                        command.ExecuteNonQuery();


                        MessageBox.Show("Deleted Successfully");
                        reset();
                        display();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("There is an error accurred");
                    }
                    finally
                    {
                        con.Close();

                    }
                }
                else
                {
                    MessageBox.Show("The user is not removed");
                }
            } } 
        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT user_id , user_username,user_password,account_Creation from users where user_id like @search+'%' or user_username like @search+'%' ORDER BY account_Creation DESC, user_username";
            command.Parameters.AddWithValue("@search", textBox3.Text);
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            UsersList.DataSource = dt;
           
            con.Close();
        }

        private void UsersList_DoubleClick(object sender, EventArgs e)
        {
            if(UsersList.CurrentRow.Index != -1)
            {
                textBox1.Text = UsersList.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = UsersList.CurrentRow.Cells[2].Value.ToString();
                userID = Convert.ToInt32(UsersList.CurrentRow.Cells[0].Value.ToString()); 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userID == 0)
            {
                MessageBox.Show("There is no selected data to be updated----------------");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = "UPDATE users SET  user_username=@name,user_password=@pass where user_id=@id ";
                    command.Parameters.AddWithValue("@id", userID);
                    command.Parameters.AddWithValue("@name", textBox1.Text);
                    command.Parameters.AddWithValue("@pass", textBox2.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show("username and password have a limited length 20");
                }
                finally
                {
                    display();

                    con.Close();

                   
                }
            }
        }
        void reset()
        {
            textBox1.Text = textBox2.Text = "";
            userID = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
