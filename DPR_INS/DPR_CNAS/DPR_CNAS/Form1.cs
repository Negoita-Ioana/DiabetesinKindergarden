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

        public static string Email = "";
        string stringcon = System.Configuration.ConfigurationManager.ConnectionStrings["dpr"].ConnectionString;


        public void Login()
        { 

            Email = emailtextbox.Text;

            string pass = passwordtextbox.Text.Trim();
            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand("select * from users where email=@LEMAIL and password=@LPAROLA", con);
            cmd.Parameters.AddWithValue("@LEMAIL", emailtextbox.Text);
            cmd.Parameters.AddWithValue("@LPAROLA", passwordtextbox.Text);

            MySqlDataAdapter dt = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dt.Fill(ds);

            int count = ds.Tables[0].Rows.Count;
            if (count == 1)
            {

                if (pass == ds.Tables[0].Rows[0]["password"].ToString())
                {
                    var data = (Byte[])ds.Tables[0].Rows[0]["poza"];
                    var stream = new MemoryStream(data);
                    Image poza = Image.FromStream(stream);
                    dashboard appforms = new dashboard(ds.Tables[0].Rows[0]["nume"].ToString(), Email, poza);
                    this.Hide();
                    appforms.Show();
                    emailtextbox.Text = String.Empty;
                    passwordtextbox.Text = String.Empty;
                }
                else
                    emailerror.Visible = true;
            }
        }
        private void Register()
        {
            if(emailtextbox.Text != "" && passwordtextbox.Text != "")
            {
                Bitmap img = Properties.Resources.Cardiogram_on_a_blue_backgrounds;
                ImageConverter converter = new ImageConverter();
                var poza = (byte[])converter.ConvertTo(img, typeof(byte[]));
                MySqlConnection con = new MySqlConnection(stringcon);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO USERs (EMAIL,password,nume,TELEFON,DESCRIEREP,POZA,APARTENENTA,NUMEMANAGER,ADRESAINSTITUTIE,NUMEDOCTOR,NUMEASTITENT,DESCRIEREINSTITUTIE) VALUES(@email,@parola,@fn,@tel,@dp,@poza,@apartenenta,@numemanager,@adresainstitutie,@numedoctor,@numeasistent,@di)", con);
                cmd.Parameters.AddWithValue("@email", emailtextbox.Text);
                cmd.Parameters.AddWithValue("@parola", passwordtextbox.Text);
                cmd.Parameters.AddWithValue("@fn", "N/A");
                cmd.Parameters.AddWithValue("@tel", "N/A");
                cmd.Parameters.AddWithValue("@dp", "");
                cmd.Parameters.AddWithValue("@poza", poza);
                cmd.Parameters.AddWithValue("@apartenenta", 2);
                cmd.Parameters.AddWithValue("@numemanager", "N/A");
                cmd.Parameters.AddWithValue("@adresainstitutie", "N/A");
                cmd.Parameters.AddWithValue("@numedoctor", "N/A");
                cmd.Parameters.AddWithValue("@numeasistent", "N/A");
                cmd.Parameters.AddWithValue("@di", "");
                con.Open();
                cmd.ExecuteNonQuery();
                dashboard appforms = new dashboard("N/A", emailtextbox.Text, img);
                this.Hide();
                appforms.Show();
                emailtextbox.Text = String.Empty;
                passwordtextbox.Text = String.Empty;
            }
        }
        private void loginbutton_Click(object sender, EventArgs e)
        {
            if(!inreg)
            {
                
                Login();

                //dashboard appforms = new dashboard();
                //this.Hide();
                //appforms.Show();
                //emailtextbox.Text = String.Empty;
                //passwordtextbox.Text = String.Empty;
            }
            else
            {
                Register();
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

        private void exitlabel_MouseEnter(object sender, EventArgs e)
        {
            exitlabel.ForeColor = System.Drawing.Color.Red;
        }

        private void exitlabel_MouseLeave(object sender, EventArgs e)
        {
            exitlabel.ForeColor = System.Drawing.Color.Black;
        }
        public bool inreg = false;
        private void exitlabel_Click(object sender, EventArgs e)
        {
            
            if (inreg == false)
            {
                inreg = true;
                welcomelabel.Text = "Inregistrare ca INSTITUȚIE";
                loginbutton.Text = "Inregistrare cont INSTITUȚIE";
                exitlabel.Text = "RENUNȚĂ";
            }
            else
            {
                welcomelabel.Text = "Autentificare in cont INSTITUȚIE";
                loginbutton.Text = "AUTENTIFICARE IN CONT INSTITUȚIE";
                exitlabel.Text = "INREGISTRARE";
                inreg = false;

            }
        }
    }
}
