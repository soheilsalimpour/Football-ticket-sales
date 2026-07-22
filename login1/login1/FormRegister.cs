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
    public partial class FormRegister : Form
    {
        string con = @"Server=(local);Database=LoginDB;Trusted_Connection=true;";


        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" ||
                 txtPassword.Text == "" ||
                   txtConfirmPassword.Text == "")
            {
                MessageBox.Show("همه فیلدها را پر کنید");
                return;
            }

                 if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("رمزها یکسان نیستند");
                return;
            }

                 SqlConnection connection = new SqlConnection(con);

                 connection.Open();

                 SqlCommand cmd = new SqlCommand(
                 "INSERT INTO Users(Username,Password) VALUES(@u,@p)", connection);

                 cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                 cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                 cmd.ExecuteNonQuery();

                 connection.Close();

                 MessageBox.Show("ثبت نام با موفقیت انجام شد");

                 txtUsername.Clear();
                 txtPassword.Clear();
                 txtConfirmPassword.Clear();



                  if (UserManager.Register(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("ثبت نام موفق");
            }
                   else
            {
                MessageBox.Show("این نام کاربری قبلاً ثبت شده");
            }
        }


        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            {
                btnRegister.BackColor = Color.FromArgb(90, 80, 200);
            }
        }



        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {

            {
                btnRegister.BackColor = Color.FromArgb(108, 92, 231);
            }

        }


        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void linkRegister_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void passshowbtn_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
        }
    }
}
