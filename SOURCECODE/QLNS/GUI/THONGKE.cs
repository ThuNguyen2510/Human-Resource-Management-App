using QLNS.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS.GUI
{
    public partial class THONGKE : Form
    {
        NhanVien_BLL nvbll { get; set; }
        public THONGKE()
        {
            InitializeComponent();
            nvbll = new NhanVien_BLL();
        }
        private void show()
        {
            dgvThongKe.DataSource = nvbll.HienThiNhanVien();
        }
        private void showkhoa(string ms)
        {
            dgvThongKe.DataSource = nvbll.ThongKeNV_BLL(ms);
        }
        public void dem()
        {
            int tv = 0;
            foreach (DataGridViewRow i in dgvThongKe.Rows)
            {
                if (i.Cells[0].Value != null) tv += 1;
            }
            txtTong.Text = Convert.ToString(tv);
        }
        public void DienThoai(string ms,DataTable tb)
        {
            //DataTable tb = nvbll.SoDTkhoa(ms);
            txtlienhe.Text = tb.Rows[0]["SoDT"].ToString();
        }
        private void butCNTT_Click(object sender, EventArgs e)
        {
            string ms = "Công nghệ thông tin";
            showkhoa(ms);
            dem();
            DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butDIEN_Click(object sender, EventArgs e)
        {
            string ms = "Điện";
            showkhoa(ms); dem();
            DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butHoa_Click(object sender, EventArgs e)
        {
            string ms = "Hóa";
            showkhoa(ms); dem();
            DienThoai(ms,nvbll.SoDTkhoa(ms));
        }

        private void butCokhi_Click(object sender, EventArgs e)
        {
            string ms= "Cơ Khí";
            showkhoa(ms); dem();
            DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butCoKhiGT_Click(object sender, EventArgs e)
        {
            string ms = "Cơ Khí Giao Thông";
            showkhoa(ms); dem();       DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butQLDA_Click(object sender, EventArgs e)
        {
            string ms = "Quản Lí Dự Án";
            showkhoa(ms); dem();        DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butMoiTruong_Click(object sender, EventArgs e)
        {
            string ms = "Môi Trường";
            showkhoa(ms); dem();    DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butNhienDienLah_Click(object sender, EventArgs e)
        {
            string ms = "Công nghệ Nhiệt - Điện lạnh";
            showkhoa(ms); dem();    DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butDTVT_Click(object sender, EventArgs e)
        {
            string ms = "Điện Tử Viễn Thông";
            showkhoa(ms); dem();    DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butXDDanDung_Click(object sender, EventArgs e)
        {
            string ms = "Xây dựng Dân dựng và Công nghiệp";
            showkhoa(ms); dem();    DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butXDCauDuong_Click(object sender, EventArgs e)
        {
            string ms = "Xây dựng cầu đường";
            showkhoa(ms); dem();    DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butKienTruc_Click(object sender, EventArgs e)
        {
            string ms = "Kiến trúc";
            showkhoa(ms);   dem();  DienThoai(ms, nvbll.SoDTkhoa(ms));
        }

        private void butXDThuyLoi_Click(object sender, EventArgs e)
        {
            string ms= "Xây dựng thủy lợi thủy điện";
            showkhoa(ms);   DienThoai(ms, nvbll.SoDTkhoa(ms));
            dem();
        }

        private void butCSVC_Click(object sender, EventArgs e)
        {
            string ms = "Phòng Cơ sở vật chất";
            showkhoa(ms);   DienThoai(ms, nvbll.SoDTPhongBan(ms));
            dem();
        }

        private void butCTSV_Click(object sender, EventArgs e)
        {
            string ms = "Phòng Công tác sinh viên";
            showkhoa(ms);   DienThoai(ms, nvbll.SoDTPhongBan(ms));
            dem();
        }

        private void butDaoTao_Click(object sender, EventArgs e)
        {
            string ms = "Phòng Đào Tạo";
            showkhoa(ms); dem();
            DienThoai(ms, nvbll.SoDTPhongBan(ms));
        }

        private void butKeHoachTC_Click(object sender, EventArgs e)
        {
            string ms = "Phòng Kế hoạch-Tài chính";
            showkhoa(ms); dem();    DienThoai(ms, nvbll.SoDTPhongBan(ms));
        }

        private void butKhaothiDambao_Click(object sender, EventArgs e)
        {
            string ms = "Phòng Khảo thí và đảm báo chất lượng GD";
            showkhoa(ms); dem();    DienThoai(ms, nvbll.SoDTPhongBan(ms));
        }

        private void butKHCN_Click(object sender, EventArgs e)
        {
            string ms = "Phòng Khoa học công nghệ- hợp tác quốc tế";
            showkhoa(ms); dem(); DienThoai(ms, nvbll.SoDTPhongBan(ms));
        }

        private void butThanhtra_Click(object sender, EventArgs e)
        {
           string ms="Phòng Thanh tra pháp chế";
            showkhoa(ms); dem(); DienThoai(ms, nvbll.SoDTPhongBan(ms));
        }

        private void butTochucHanhchinh_Click(object sender, EventArgs e)
        {
            string ms="Phòng Tổ chức-hành chính";
            showkhoa(ms); dem(); DienThoai(ms, nvbll.SoDTPhongBan(ms));
        }

        private void butBGH_Click(object sender, EventArgs e)
        {
           string ms ="Ban Giám Hiệu";
            showkhoa(ms); dem(); DienThoai(ms, nvbll.SoDTPhongBan(ms));
        }

        private void butHienThi_Click(object sender, EventArgs e)
        {
            show();
            dem();
        }

        private void butThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int focus = -1;
        private void THONGKE_Load(object sender, EventArgs e)
        {

        }
    }
}
