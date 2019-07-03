using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace DPR_CNAS
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            Profilpictandname();

            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select grad_diabet from pacient where grad_diabet=1";
            cmd.Connection = con;
            MySqlDataAdapter dt = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataSet ds12 = new DataSet();
            dt.Fill(ds);
            con.Open();

             int value1=2; int value2 = 1; int value3 = 3;
            statistic1.Series["Series1"].Points.AddXY("Predispusi la diabet", value1);
            statistic1.Series["Series1"].Points.AddXY("Diabet de gradul I", value2);
            statistic1.Series["Series1"].Points.AddXY("Diabet de gradul II", value3);
            con.Close();

            int value4 = 20; int value5 = 4;
            statistic2.Series["Series1"].Points.AddXY("Institutii cu diabetici", value4);
            statistic2.Series["Series1"].Points.AddXY("Institutii fara diabetici", value5);

            int value6 = 2; int value7 = 1; int value8 = 3; int value9 = 9; int value10 = 3;
            chart1.Series["Series1"].Points.AddXY("2 ani", value6);
            chart1.Series["Series1"].Points.AddXY("3 ani", value7);
            chart1.Series["Series1"].Points.AddXY("4 ani", value8);
            chart1.Series["Series1"].Points.AddXY("5 ani", value9);
            chart1.Series["Series1"].Points.AddXY("6 ani", value10);

            int value11 = 20; int value12 = 4;
            chart2.Series["Series1"].Points.AddXY("Insulion-dependenti", value11);
            chart2.Series["Series1"].Points.AddXY("Nu depind de insulina", value12);
        }

        private void currenttimeanddate_Tick(object sender, EventArgs e)
        {
            string currenttime = DateTime.Now.ToLongTimeString();
            string currentdate = DateTime.Now.ToShortDateString();
            dateandtime.Text = currenttime + " - " + currentdate;
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            members_panel.Visible = true;
            organizations_panel.Visible = false;
            statistics_panel.Visible = false;
            comunity_panel.Visible = false;
        }

        private void teambutton_Click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = true;
            members_panel.Visible = false;
            organizations_panel.Visible = false;
            statistics_panel.Visible = false;
            comunity_panel.Visible = false;
        }

        private void projectsbutton_Click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            members_panel.Visible = false;
            organizations_panel.Visible = true;
            statistics_panel.Visible = false;
            comunity_panel.Visible = false;
        }

        private void statisticsbutton_Click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            members_panel.Visible = false;
            organizations_panel.Visible = false;
            statistics_panel.Visible = true;
            comunity_panel.Visible = false;
        }

        private void financialbutton_Click(object sender, EventArgs e)
        {

            dashboard_panel.Visible = false;
            members_panel.Visible = false;
            organizations_panel.Visible = false;
            statistics_panel.Visible = false;
            comunity_panel.Visible = true;
        }

        private void minimize_button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            Form1 loginform = new Form1();
            this.Hide();
            loginform.Show();
            
        }

        private void teamlist_button_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            addteammate_panel.Visible = false;
        }

        private void addteammate_button_Click(object sender, EventArgs e)
        {
            addteammate_panel.Visible = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = true;
            panel5.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(*JPG)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(f.FileName);
            }
        }
        public void Profilpictandname()
        {
            string agentname;// take this from database
            string agentpremane;// take this from database

            MySqlConnection con = new MySqlConnection(stringcon);

            MySqlCommand cmd = new MySqlCommand("select poza from users where email=@EMAIL", con);
            MySqlCommand cmd2 = new MySqlCommand("select nume from users where email=@EMAIL", con);
            MySqlCommand cmd3 = new MySqlCommand("select rol from users where email=@EMAIL", con);

            cmd.Parameters.AddWithValue("@EMAIL", Form1.Email);
            cmd2.Parameters.AddWithValue("@EMAIL", Form1.Email);
            cmd3.Parameters.AddWithValue("@EMAIL", Form1.Email);

            MySqlDataAdapter dt = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataSet ds12 = new DataSet();
            dt.Fill(ds);
            con.Open();
         
            Object temp_dash = cmd2.ExecuteScalar();
            agentfullnamevieww.Text = temp_dash.ToString();
            label312.Text = "Bun venit, " + temp_dash.ToString() +" !";


            Object temp_dash1 = cmd3.ExecuteScalar();
            label319.Text = "Functia ocupata: " + temp_dash1.ToString() + " !";

            con.Close();
            byte[] ap = (byte[])ds.Tables[0].Rows[0]["poza"];
            MemoryStream ms = new MemoryStream(ap);
            bunifuPictureBox1.Image = Image.FromStream(ms);
            //show datagridview columns
            con.Open();
        }

        string stringcon = System.Configuration.ConfigurationManager.ConnectionStrings["dpr"].ConnectionString;


        private void validateaddmember_button_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox4.Image.Save(ms, pictureBox4.Image.RawFormat);
            byte[] a = ms.GetBuffer();
            ms.Close();


            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO users(nume,email,password,telefon,rol,descrierep,POZA,Apartenenta) VALUES(@n,@e,@p,@t,@rol,@desc,@poza,@a)";

            cmd.Parameters.AddWithValue("@n", firstname_textbox.Text +" "+ lastname_textbox.Text);
            cmd.Parameters.AddWithValue("@t", phone_textbox.Text);
            cmd.Parameters.AddWithValue("@e", email_textbox.Text);
         //   DateTime.Now.ToString("dd-MM-yyyy HH: mm:ss")
            cmd.Parameters.AddWithValue("@rol", role_dropbox.selectedValue);
            cmd.Parameters.AddWithValue("@p", repeatpassword_textbox.Text);
            cmd.Parameters.AddWithValue("@poza", a);
            cmd.Parameters.AddWithValue("@desc", richTextBox1.Text);
            cmd.Parameters.AddWithValue("a", 1);

            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

            firstname_textbox.Text = string.Empty;
            lastname_textbox.Text = string.Empty;
            email_textbox.Text = string.Empty;
            phone_textbox.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            password_textbox.Text = string.Empty;
            repeatpassword_textbox.Text = string.Empty;
        }
    }
}
