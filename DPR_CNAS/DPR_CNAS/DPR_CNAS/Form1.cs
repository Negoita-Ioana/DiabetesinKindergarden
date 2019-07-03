using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace DPR_CNAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void watchpassbutton_MouseEnter(object sender, EventArgs e)
        {
            passwordtextbox.UseSystemPasswordChar = false;
        }

        private void watchpassbutton_MouseLeave(object sender, EventArgs e)
        {
            passwordtextbox.UseSystemPasswordChar = true;

        }
        string stringcon = System.Configuration.ConfigurationManager.ConnectionStrings["dpr"].ConnectionString;
        public static string Email = "";

        private void loginbutton_Click(object sender, EventArgs e)
        {

            Email = emailtextbox.Text;
            MySqlConnection con = new MySqlConnection(stringcon); //CONNECTION

            string pass = passwordtextbox.Text.Trim();
            MySqlCommand cmd = new MySqlCommand("select * from users where email=@LEMAIL and password=@Lpassword", con);
//            MySqlCommand cmd2 = new MySqlCommand();
            cmd.Parameters.AddWithValue("@LEMAIL", emailtextbox.Text);
            cmd.Parameters.AddWithValue("@Lpassword", passwordtextbox.Text);

            MySqlDataAdapter dt = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dt.Fill(ds);

            int count = ds.Tables[0].Rows.Count;
            if (count == 1)
            {

                if (pass == ds.Tables[0].Rows[0]["password"].ToString())
                {
                    var appform = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Form1);
                    if (appform != null)
                    {
                        dashboard appforms = new dashboard();
                        this.Hide();
                        appforms.Show();
                        emailtextbox.Text = String.Empty;
                        passwordtextbox.Text = String.Empty;
                    }
                    else
                    {
                        Form1 appforms = new Form1();
                        this.Hide();
                        appforms.Show();
                        emailtextbox.Text = String.Empty;
                        passwordtextbox.Text = String.Empty;
                    }
                }
             
            }
   
        }
        

        private void minimizebutton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
