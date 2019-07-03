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
    public partial class dashboard : Form
    {
        String email;
        DataTable dtUser;
        DataTable dtMeniuri;
        Image poza;
        public dashboard(String nume, String email, Image poza)
        {
            InitializeComponent();
            agentfullnamevieww.Text = nume;
            bunifuPictureBox1.Image = poza;
            this.poza = poza;
            this.email = email;
        }
        string stringcon = System.Configuration.ConfigurationManager.ConnectionStrings["dpr"].ConnectionString;
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
            dashboard_panel.BringToFront();

            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand("select * from users where email='" + email + "'", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtUser = ds.Tables[0];
            lbladresa.Text = dtUser.Rows[0]["adresainstitutie"].ToString();
            lbldenumire.Text = dtUser.Rows[0]["nume"].ToString();
            lbltel.Text = dtUser.Rows[0]["telefon"].ToString();
            lblemail.Text = email;
            lblnumemanager.Text = dtUser.Rows[0]["numemanager"].ToString();
            lblnumedoctor.Text = dtUser.Rows[0]["numedoctor"].ToString();
            lblnumeasistent.Text = dtUser.Rows[0]["numeasistent"].ToString();
            personaldescriprion_label.Text = dtUser.Rows[0]["descriereinstitutie"].ToString();
            pictureBox2.Image = poza;
            agentname_label.Text = dtUser.Rows[0]["nume"].ToString();
        }

        private void projectsbutton_Click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            members_panel.Visible = false;
            organizations_panel.Visible = true;
            statistics_panel.Visible = false;
            comunity_panel.Visible = false;

            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand("select denumire,micdejun,pranz,cina,gustari from meniuri", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtMeniuri = ds.Tables[0];
            
            bunifuCustomDataGrid1.DataSource = dtMeniuri;

            con = new MySqlConnection(stringcon);
            cmd = new MySqlCommand("select * from alimente", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataTable dtAlimente = ds.Tables[0];
            foreach(DataRow row in dtAlimente.Rows)
            {
                bunifuDropdown1.Items.Add(row["denumire"]);
                bunifuDropdown2.Items.Add(row["denumire"]);
                bunifuDropdown3.Items.Add(row["denumire"]);
                bunifuDropdown4.Items.Add(row["denumire"]);
                bunifuDropdown5.Items.Add(row["denumire"]);
                bunifuDropdown6.Items.Add(row["denumire"]);
                bunifuDropdown7.Items.Add(row["denumire"]);
                bunifuDropdown8.Items.Add(row["denumire"]);
                bunifuDropdown9.Items.Add(row["denumire"]);
                bunifuDropdown10.Items.Add(row["denumire"]);
                bunifuDropdown11.Items.Add(row["denumire"]);
                bunifuDropdown12.Items.Add(row["denumire"]);
                bunifuDropdown13.Items.Add(row["denumire"]);
                bunifuDropdown14.Items.Add(row["denumire"]);
                bunifuDropdown15.Items.Add(row["denumire"]);
                bunifuDropdown16.Items.Add(row["denumire"]);
                bunifuDropdown17.Items.Add(row["denumire"]);
                bunifuDropdown18.Items.Add(row["denumire"]);
                bunifuDropdown19.Items.Add(row["denumire"]);
                bunifuDropdown20.Items.Add(row["denumire"]);
            }
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

            panel1.Visible = false;
            addteammate_panel.Visible = false;
        }

        private void addteammate_button_Click(object sender, EventArgs e)
        {
            addteammate_panel.Visible = true;
            addteammate_panel.BringToFront();
            txtadresa.Text = dtUser.Rows[0]["adresainstitutie"].ToString();
            txtDenumire.Text = dtUser.Rows[0]["nume"].ToString();
            txtemail.Text = email;
            txtnumeasistent.Text = dtUser.Rows[0]["numeasistent"].ToString();
            txtnumedoctor.Text = dtUser.Rows[0]["numedoctor"].ToString();
            txtnumemanager.Text = dtUser.Rows[0]["numemanager"].ToString();
            txttel.Text = dtUser.Rows[0]["telefon"].ToString();
            txtdi.Text = dtUser.Rows[0]["descriereinstitutie"].ToString();
            pictureBox4.Image = poza;

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;


            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand("select * from meniuri", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtMeniuri = ds.Tables[0];

            foreach (DataRow row in dtMeniuri.Rows)
            {
                bunifuDropdown21.Items.Add(row["denumire"]);
                bunifuDropdown22.Items.Add(row["denumire"]);
                bunifuDropdown23.Items.Add(row["denumire"]);
                bunifuDropdown24.Items.Add(row["denumire"]);
                bunifuDropdown25.Items.Add(row["denumire"]);
            }
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

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bunifuDropdown1.SelectedIndex>0)
            {
                bunifuDropdown2.Visible = true;
                label41.Visible = true;
                bunifuMetroTextbox2.Visible = true;
                label53.Visible = true;
                label58.Visible = true;
            }
        }

        private void bunifuDropdown2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown2.SelectedIndex > 0)
            {
                bunifuDropdown3.Visible = true;
                label46.Visible = true;
                bunifuMetroTextbox3.Visible = true;
                label54.Visible = true;
                label59.Visible = true;
            }
        }

        private void bunifuDropdown3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown3.SelectedIndex > 0)
            {
                bunifuDropdown4.Visible = true;
                label50.Visible = true;
                bunifuMetroTextbox4.Visible = true;
                label55.Visible = true;
                label60.Visible = true;
            }
        }

        private void bunifuDropdown4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown4.SelectedIndex > 0)
            {
                bunifuDropdown5.Visible = true;
                label51.Visible = true;
                bunifuMetroTextbox5.Visible = true;
                label56.Visible = true;
                label61.Visible = true;
            }
        }

        private void bunifuDropdown9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown9.SelectedIndex > 0)
            {
                bunifuDropdown5.Visible = true;
                label51.Visible = true;
                bunifuMetroTextbox5.Visible = true;
                label56.Visible = true;
                label61.Visible = true;
            }
        }

        private void bunifuDropdown8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown8.SelectedIndex > 0)
            {
                bunifuDropdown10.Visible = true;
                label51.Visible = true;
                bunifuMetroTextbox5.Visible = true;
                label56.Visible = true;
                label61.Visible = true;
            }
        }

        private void bunifuDropdown7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown7.SelectedIndex > 0)
            {
                bunifuDropdown5.Visible = true;
                label51.Visible = true;
                bunifuMetroTextbox5.Visible = true;
                label56.Visible = true;
                label61.Visible = true;
            }
        }

        private void bunifuDropdown6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown6.SelectedIndex > 0)
            {
                bunifuDropdown5.Visible = true;
                label51.Visible = true;
                bunifuMetroTextbox5.Visible = true;
                label56.Visible = true;
                label61.Visible = true;
            }
        }

        private void bunifuDropdown10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown10.SelectedIndex > 0)
            {
                bunifuDropdown5.Visible = true;
                label51.Visible = true;
                bunifuMetroTextbox5.Visible = true;
                label56.Visible = true;
                label61.Visible = true;
            }
        }

        private void validateaddmember_button_Click(object sender, EventArgs e)
        {
            if (txtpswd.Text != "" && txtpswd.Text == txtrepeatpswd.Text)
            {
                Bitmap img = Properties.Resources.Cardiogram_on_a_blue_backgrounds;
                ImageConverter converter = new ImageConverter();
                var poza = (byte[])converter.ConvertTo(img, typeof(byte[]));

                MySqlConnection con = new MySqlConnection(stringcon);
                MySqlCommand cmd = new MySqlCommand("UPDATE USER SET EMAIL=@email,PAROLA=@parola,FULLNAME=@fn,TELEFON=@tel,DESCRIEREP=@dp,POZA=@poza,APARTENENTA=@apartenenta,NUMEMANAGER=@numemanager,ADRESAINSTITUTIE=@adresainstitutie,NUMEDOCTOR=@numedoctor,NUMEASTITENT=@numeasistent,DESCRIEREINSTITUTIE=@di WHERE iduser=@id", con);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@parola", txtpswd.Text);
                cmd.Parameters.AddWithValue("@fn", txtDenumire.Text);
                cmd.Parameters.AddWithValue("@tel", txttel.Text);
                cmd.Parameters.AddWithValue("@dp", txtdi.Text);
                cmd.Parameters.AddWithValue("@poza", poza);
                cmd.Parameters.AddWithValue("@apartenenta", 2);
                cmd.Parameters.AddWithValue("@numemanager", txtnumemanager.Text);
                cmd.Parameters.AddWithValue("@adresainstitutie", txtadresa.Text);
                cmd.Parameters.AddWithValue("@numedoctor", txtnumedoctor.Text);
                cmd.Parameters.AddWithValue("@numeasistent", txtnumeasistent.Text);
                cmd.Parameters.AddWithValue("@di", txtdi.Text);
                cmd.Parameters.AddWithValue("@id", dtUser.Rows[0]["iduser"]);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown21_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = alimente((Bunifu.UI.WinForms.BunifuDropdown)sender);

            double kcal = 0;
            double carbs = 0;
            foreach (DataRow row in dt.Rows)
            {
                kcal += Convert.ToDouble(row["kcal"]) * Convert.ToDouble(row["gramaj"]) / 100;
                carbs += Convert.ToDouble(row["carboh"]) * Convert.ToDouble(row["gramaj"]) / 100;
            }
            label31.Text = "Carbohidrati: " + carbs.ToString() + "g      Kcal: " + kcal.ToString();

        }

        private void bunifuDropdown22_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = alimente((Bunifu.UI.WinForms.BunifuDropdown)sender);

            double kcal = 0;
            double carbs = 0;
            foreach (DataRow row in dt.Rows)
            {
                kcal += Convert.ToDouble(row["kcal"]) * Convert.ToDouble(row["gramaj"]) / 100;
                carbs += Convert.ToDouble(row["carboh"]) * Convert.ToDouble(row["gramaj"]) / 100;
            }

            label32.Text = "Carbohidrati: " + carbs.ToString() + "g      Kcal: " + kcal.ToString();
        }

        private void bunifuDropdown23_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = alimente((Bunifu.UI.WinForms.BunifuDropdown)sender);

            double kcal = 0;
            double carbs = 0;
            foreach (DataRow row in dt.Rows)
            {
                kcal += Convert.ToDouble(row["kcal"]) * Convert.ToDouble(row["gramaj"]) / 100;
                carbs += Convert.ToDouble(row["carboh"]) * Convert.ToDouble(row["gramaj"]) / 100;
            }

            label33.Text = "Carbohidrati: " + carbs.ToString() + "g      Kcal: " + kcal.ToString();
        }

        private void bunifuDropdown24_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = alimente((Bunifu.UI.WinForms.BunifuDropdown)sender);
            double kcal = 0;
            double carbs = 0;
            foreach (DataRow row in dt.Rows)
            {
                kcal += Convert.ToDouble(row["kcal"]) * Convert.ToDouble(row["gramaj"]) / 100;
                carbs += Convert.ToDouble(row["carboh"]) * Convert.ToDouble(row["gramaj"]) / 100;
            }

            label34.Text = "Carbohidrati: " + carbs.ToString() + "g      Kcal: " + kcal.ToString();
        }

        private void bunifuDropdown25_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = alimente((Bunifu.UI.WinForms.BunifuDropdown)sender);
            double kcal = 0;
            double carbs = 0;
            foreach (DataRow row in dt.Rows)
            {
                kcal += Convert.ToDouble(row["kcal"]) * Convert.ToDouble(row["gramaj"]) / 100;
                carbs += Convert.ToDouble(row["carboh"]) * Convert.ToDouble(row["gramaj"]) / 100;
            }

            label35.Text = "Carbohidrati: " + carbs.ToString() + "g      Kcal: " + kcal.ToString();
        }

        private DataTable alimente(Bunifu.UI.WinForms.BunifuDropdown sender)
        {
            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand("select * from meniuri " +
                "LEFT OUTER JOIN meniualimente on meniu.idmeniuri = meniualimente.idmeniuri " +
                "INNER JOIN alimente on alimente.idalimente = meniualimente.id_aliment " +
                "WHERE meniu.idmeniuri = " + dtMeniuri.Rows[sender.SelectedIndex]["idmeniuri"].ToString() + "", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
