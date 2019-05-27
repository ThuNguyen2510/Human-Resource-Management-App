using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel= Microsoft.Office.Interop.Excel;
using QLNS.DTO;
using QLNS.BLL;
using System.Data.OleDb;
namespace QLNS.GUI
{
    public partial class AddForm2 : Form
    {
        NhanVien_BLL nvbll { get; set; }
        public AddForm2()
        {
            InitializeComponent();
            nvbll = new NhanVien_BLL();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Open(this.label1.Text);
                try
                {
                    // mo sheet
                    Excel.Worksheet sheet = wb.Sheets[Convert.ToInt32(this.txtsheetname.Text)];
                    // tham chieu ca vung dl
                    Excel.Range range = sheet.UsedRange;
                    // doc du lieu
                    int rs = range.Rows.Count;
                    int cs = range.Columns.Count;
                    // doc tao tieu de
                    DataTable dt = new DataTable();
                    DataRow dr;
                    for (int c = 1; c <= cs; c++)
                    {
                        string tencot = range.Cells[1, c].Value.ToString();// dong 1, cot thu c
                        dt.Columns.Add(tencot);
                    }
                    // du lieu
                    for (int i = 2; i <= rs; i++) // hang 
                    {
                        dr = dt.NewRow();
                        for (int j = 1; j <= cs; j++)
                        {
                            dr[j - 1] = sheet.Cells[i, j].Value;
                        }
                        dt.Rows.Add(dr);
                    }
                    dgv2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cần chọn sheet hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception eq)
            {
                MessageBox.Show("Chọn file import trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        NhanVien nv = new NhanVien();
        public delegate void ad(string k, NhanVien nv);// truyen ve addform
        public ad a2;

        private void btChon_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 1)
            {
                nv.MaNhanVien = Convert.ToInt32(dgv2.SelectedRows[0].Cells["Mã Nhân Viên"].Value);
                nv.HoTen = dgv2.SelectedRows[0].Cells["Họ Tên"].Value.ToString();
                nv.ChoOHienTai = dgv2.SelectedRows[0].Cells["Chỗ ở hiện tại"].Value.ToString();
                nv.ChuyenNganh = dgv2.SelectedRows[0].Cells["Chuyên ngành"].Value.ToString();
                nv.DienThoai = dgv2.SelectedRows[0].Cells["SĐT"].Value.ToString();
                nv.GioiTinh = dgv2.SelectedRows[0].Cells["Giới tính"].Value.ToString() == "1" ? true : false;
                nv.LinhVucNghienCuu = dgv2.SelectedRows[0].Cells["Lĩnh vực nghiên cứu"].Value.ToString();
                int mapb = dgv2.SelectedRows[0].Cells["Phòng ban"].Value == System.DBNull.Value ? -1 : nvbll.getma("PhongBan", "MaPhongBan", "TenPhongBan", dgv2.SelectedRows[0].Cells["Phòng ban"].Value.ToString());
                int makhoa = dgv2.SelectedRows[0].Cells["Khoa"].Value == System.DBNull.Value ? -1 : nvbll.getma("Khoa", "MaKhoa", "TenKhoa", dgv2.SelectedRows[0].Cells["Khoa"].Value.ToString());
                int mahh = dgv2.SelectedRows[0].Cells["Học hàm"].Value == System.DBNull.Value ? -1 : nvbll.getma("HocHam", "MaHocHam", "TenHocHam", dgv2.SelectedRows[0].Cells["Học hàm"].Value.ToString());
                int mahv = dgv2.SelectedRows[0].Cells["Học vị"].Value == System.DBNull.Value ? -1 : nvbll.getma("HocVi", "MaHocVi", "TenHocVi", dgv2.SelectedRows[0].Cells["Học vị"].Value.ToString());
                int macv = dgv2.SelectedRows[0].Cells["Tên Chức Vụ"].Value == System.DBNull.Value ? -1 : nvbll.getma("ChucVu", "MaChucVu", "TenChucVu", dgv2.SelectedRows[0].Cells["Tên Chức Vụ"].Value.ToString());
                nv.MaChucVu = macv;
                nv.MaHinhAnh = nv.MaNhanVien;
                nv.MaPhongBan = mapb;
                nv.MaKhoa = makhoa;
                nv.MaHocHam = mahh;
                nv.MaHocVi = mahv;
                nv.NamDatHV = dgv2.SelectedRows[0].Cells["Năm đạt học vị"].Value.ToString();
                nv.NgaySinh = Convert.ToDateTime(dgv2.SelectedRows[0].Cells["Ngày sinh"].Value);
                nv.NgoaiNgu = dgv2.SelectedRows[0].Cells["Ngoại ngữ"].Value.ToString();
                nv.NoiSinh = dgv2.SelectedRows[0].Cells["Nơi sinh"].Value.ToString();
                nv.QueQuan = dgv2.SelectedRows[0].Cells["Quê Quán"].Value.ToString();
                nv.TruongTN = dgv2.SelectedRows[0].Cells["Trường tốt nghiệp"].Value.ToString();
                a2(dgv2.SelectedRows[0].Cells["DuongdanluuHinh"].Value.ToString(), nv);
                this.Close();
            }
            else
            {
                MessageBox.Show("bạn cần chọn 1 nhân viên để thêm");
            }


        }

        private void AddForm2_Load(object sender, EventArgs e)
        {

        }

        private void bt2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "(Các tệp excel)|*.xlsx";
            op.ShowDialog();
            if (op.FileName != "")
            {
                this.label1.Text = op.FileName;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn file cần import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
