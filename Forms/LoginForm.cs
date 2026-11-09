using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace dps.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object? sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;



            if (username == "guru" && password == "12345")
            {
                MessageBox.Show("Login Berhasil", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                GuruForm menu = new GuruForm();
                menu.Show();
                this.Hide();
            }

            if (username == "siswa" && password == "12345")
            {
                MessageBox.Show("Login Berhasil", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                SiswaForm menu = new SiswaForm();
                menu.Show();
                this.Hide();
            }
          

            if (username == "admin" && password == "12345")
            {
                MessageBox.Show("Login Berhasil", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminForm menu = new AdminForm();
                menu.Show();
                this.Hide();
            }
            if(username != "guru" && username != "siswa" && username != "admin" || password != "12345")
            {
                MessageBox.Show("Username atau Password salah", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {

                MessageBox.Show("Username Belum Diisi");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password Belum Diisi");
                txtPassword.Focus();
                return;
            }
        }

        private void btnShowPassword_Click(object? sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnShowPassword.Text = txtPassword.UseSystemPasswordChar ? "Lihat" : "Sembunyikan";
            txtPassword.Focus();
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
