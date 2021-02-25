using KuryeTakip.DataAccessLayer;
using KuryeTakip.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryeTakip
{
    public partial class AdminLoginPopup : Form
    {
        public AdminLoginPopup()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Kullanici admin = KullaniciService.AdminKullaniciGetir();

                if (adminUserNameTextBox.Text == admin.Username && PasswordHelper.CreateMD5(adminPasswordTextBox.Text) == admin.Password)
                    DialogResult = DialogResult.OK;
                else
                {
                    label3.Text = "Yetkili kullanıcı adı/şifre yanlış!";
                    label3.ForeColor = Color.Red;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void AdminLoginPopup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                Close();
            }
        }
    }
}
