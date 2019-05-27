using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.BLL;
using QLNS.GUI;

namespace QLNS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ndbll = new NguoiDung_BLL();
        }

        public NguoiDung_BLL ndbll;
        private void btDN_Click(object sender, EventArgs e)
        {
            DataTable dt = ndbll.LayNguoidung();
            string ten = dt.Rows[0]["TenDangNhap"].ToString();
            string mk = dt.Rows[0]["MatKhau"].ToString();
            if (txtTenDN.Text == "" || txtMK.Text == "")
                MessageBox.Show("Moi nhap day du thong tin");
            else if (txtTenDN.Text.Equals(ten) == true || txtMK.Text.Equals(mk) == true)
            {
                DialogResult = DialogResult.OK;
                //MainForm mf = new MainForm();
                //mf.Show();
                //this.Hide();
            }
            else if (txtTenDN.Text != ten || txtMK.Text != mk)
            {
                MessageBox.Show("Ten Dang Nhap hoac Mat khau sai, Xin moi kiem tra lai!");
            }

        }
        private void btHuy_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
