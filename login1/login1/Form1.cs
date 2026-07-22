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


namespace login1
{
    public partial class FormLogin : Form
    {
        string con = @"Server=(local);Database=LoginDB;Trusted_Connection=true;";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.BorderStyle = BorderStyle.None;
            txtPassword.BorderStyle = BorderStyle.None;

            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;

            btnLogin.BackColor = Color.FromArgb(108, 92, 231);
            btnLogin.ForeColor = Color.White;

        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
          try
          {
              SqlConnection connection = new SqlConnection(con);

              connection.Open();

               SqlCommand cmd = new SqlCommand(
                  "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p",
                 connection);

              cmd.Parameters.AddWithValue("@u", txtUsername.Text);
              cmd.Parameters.AddWithValue("@p", txtPassword.Text);

               int count = (int)cmd.ExecuteScalar();

              connection.Close();

             if (count > 0)
             {
                    MessageBox.Show("ورود موفقیت آمیز بود.");

                    MainForm frm = new MainForm();
                   frm.Show();

                  this.Hide();
                }
           else
             {
                     MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
                 }
                     }
                         catch (Exception ex)
                         {
                               MessageBox.Show(ex.Message);
                                 }
                            }


         private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            {
                btnLogin.BackColor = Color.FromArgb(90, 80, 200);
            }
         }



         private void btnLogin_MouseLeave(object sender, EventArgs e)
         {

             {
                 btnLogin.BackColor = Color.FromArgb(108, 92, 231);
             }

         }



        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister frm = new FormRegister();
            frm.Show();
            this.Hide();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegister frm = new FormRegister();
            frm.Show();
            this.Hide();
        }

        private void passshowbtn2_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

        }
    }
}
