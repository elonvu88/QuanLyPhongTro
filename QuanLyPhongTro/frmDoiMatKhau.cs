using MyWork.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWork
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            //string password = SecurityMethod.MD5Encrypt(txtMatKhau.Text.Trim());
            //MyWorkEntities ctx = new MyWorkEntities();
            //var user = ctx.Users.Where(c => c.UserID == Connection.idDangNhap).FirstOrDefault();
            //if (user != null)
            //{
            //    user.Password = password;
            //    ctx.SaveChanges();
            //    MessageBox.Show("Cập nhật mật khẩu thành công!");
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật mật khẩu thất bại!");
            //}
            //this.Close();
        }
    }
}
