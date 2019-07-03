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
        public dashboard()
        {
            InitializeComponent();
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

            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT iduser,institutie,numemanager,numedoctor,numeasistent,email FROM users where apartenenta=2 ";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt3 = new DataTable();
            MySqlDataAdapter sda2 = new MySqlDataAdapter(cmd);
            sda2.Fill(dt3);
            bunifuCustomDataGrid1.DataSource = dt3;

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
            organizations_panel.Visible = false;
            statistics_panel.Visible = true;
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
        string gender;
        int pacient_id;
        string numepacient;
        private void financialbutton_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(stringcon);
            con.Open();

            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Parameters.Clear();
            cmd2.Connection = con;
            cmd2.CommandText = "SELECT p.idpacient,p.nume,p.grad_diabet,p.varsta,p.cnp,p.descriere,p.sex FROM pacient p INNER JOIN users ON users.nume = p.nume;";
            cmd2.Parameters.AddWithValue("@em", Form1.Email);
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            DataTable dt12 = new DataTable();
            MySqlDataAdapter da12 = new MySqlDataAdapter(cmd2);

            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da12.Fill(ds2);
            da2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
            {

                materialSingleLineTextField15.Text = dr["nume"].ToString();
                bunifuDropdown1.SelectedIndex = Convert.ToInt32(dr["grad_diabet"].ToString());
                materialSingleLineTextField14.Text = dr["varsta"].ToString();
                materialSingleLineTextField9.Text = dr["cnp"].ToString();
                richTextBox3.Text = dr["descriere"].ToString();
                gender = dr["sex"].ToString();
                if(gender == "Masculin") { bunifuRadioButton1.Checked = true; } else { bunifuRadioButton2.Checked = true; }
                pacient_id = Convert.ToInt32(dr["idpacient"].ToString());
                numepacient = dr["nume"].ToString();

            }
            con.Close();


            

            MySqlCommand cmd = new MySqlCommand();





            GridGlicemie();


            dashboard_panel.Visible = false;
            members_panel.Visible = false;
            organizations_panel.Visible = true;
            statistics_panel.Visible = false;
            comunity_panel.Visible = false;
        }
        
        public void GridGlicemie()
        {
            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM glicemie ORDER BY id_glicemie DESC ";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt3 = new DataTable();
            MySqlDataAdapter sda2 = new MySqlDataAdapter(cmd);
            sda2.Fill(dt3);
            teamgrid.DataSource = dt3;
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
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //OpenFileDialog f = new OpenFileDialog();
            //f.Filter = "JPG(*JPG)|*.jpg";
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    pictureBox4.Image = Image.FromFile(f.FileName);
            //}
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string stringcon = System.Configuration.ConfigurationManager.ConnectionStrings["dpr"].ConnectionString;

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {


            MySqlConnection con = new MySqlConnection(stringcon);
            con.Open();

            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Parameters.Clear();
            cmd2.Connection = con;
            cmd2.CommandText = "select * from user where email=@em";
            cmd2.Parameters.AddWithValue("@em", Form1.Email);
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            DataTable dt12 = new DataTable();
            MySqlDataAdapter da12 = new MySqlDataAdapter(cmd2);

            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da12.Fill(ds2);
            da2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
            {

                label17.Text = dr["nume"].ToString();
                label18.Text = dr["numemanager"].ToString();
                label19.Text = dr["telefon"].ToString();
                label20.Text = dr["email"].ToString();

                label21.Text = dr["adresainstitut"].ToString();
                label22.Text = dr["numedoctor"].ToString();
                label23.Text = dr["numeasistent"].ToString();


                byte[] ap = (byte[])ds2.Tables[0].Rows[0]["poza"];
                MemoryStream ms = new MemoryStream(ap);
                pictureBox3.Image = Image.FromStream(ms);
            }
            con.Close();

            editprofile_panel.Visible = true;
            editprofile_panel.BringToFront();
        }
        string masc, fem;

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "insert into pacient(nume,grad_diabet,varsta,cnp,sex,descriere) values(@name,@gd,@var,@cnp,@sex,@des)";
            cmd.Parameters.AddWithValue("@name", materialSingleLineTextField15.Text);
            cmd.Parameters.AddWithValue("@gd", bunifuDropdown1.SelectedIndex);
            cmd.Parameters.AddWithValue("@var", materialSingleLineTextField14.Text);
            cmd.Parameters.AddWithValue("@cnp", materialSingleLineTextField9.Text);
           
            if (bunifuRadioButton1.Checked == true) {  masc = "Masculin"; } else {  masc = "Feminin"; }
            cmd.Parameters.AddWithValue("@sex", masc);
            cmd.Parameters.AddWithValue("@des", richTextBox3.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "insert into glicemie(idpacient,nume_pacient,data_recoltarii,valoare) values(@id,@nume,@dr,@val)";
            cmd.Parameters.AddWithValue("@id", pacient_id);
            cmd.Parameters.AddWithValue("@nume", numepacient);
            cmd.Parameters.AddWithValue("@dr", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            cmd.Parameters.AddWithValue("@val", bunifuMetroTextbox1.Text);

            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridGlicemie();



        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public int id_instl;
        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            id_instl = Convert.ToInt32(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["iduser"].Value.ToString());
           // idproject = Convert.ToInt32(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();


            cmd.Connection = con;
            cmd.CommandText = "select * from users where iduser=" + id_instl + "";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            da.Fill(dt);




            foreach (DataRow dr in dt.Rows)
            {
                label17.Text = dr["institutie"].ToString();
                label18.Text = dr["numemanager"].ToString();
                label19.Text = dr["telefon"].ToString();
                label20.Text = dr["email"].ToString();
                label21.Text = dr["adresainstitutie"].ToString();
                label22.Text = dr["numedoctor"].ToString();
                label23.Text = dr["numeasistent"].ToString();
                personaldescriprion_label.Text = dr["descriereinstitutie"].ToString();


                byte[] ap = (byte[])ds.Tables[0].Rows[0]["poza"];
                MemoryStream ms = new MemoryStream(ap);
                pictureBox2.Image = Image.FromStream(ms);
                panel1.BringToFront();
                panel1.Visible = true;


          }
        }

        private void addteammate_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(stringcon);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "update pacient set id_institut=@idi, nume_inst=@ni where idpacient=@idip";
            cmd.Parameters.AddWithValue("@idi", id_instl);
            cmd.Parameters.AddWithValue("@ni", label17.Text);
            cmd.Parameters.AddWithValue("@idip", pacient_id);



            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
          
        }

        private void bunifuRadioButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
