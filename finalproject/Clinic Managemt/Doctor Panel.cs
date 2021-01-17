using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Managemt
{
    public partial class Doctor_Panel : Form
    {
        
        public Doctor_Panel()
        {
            InitializeComponent();
            
        }

        private void Doctor_Panel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Manage_Patient ManagePatient = new Manage_Patient();
            ManagePatient.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            users Manageusers = new users();
            Manageusers.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 welcome = new Form1();
            this.Hide();
            Program.f1.Show();
        }
    }
}
