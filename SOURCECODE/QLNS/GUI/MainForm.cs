using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QLNS.BLL;
using QLNS.DTO;
using Excel = Microsoft.Office.Interop.Excel;
namespace QLNS.GUI
{
    public partial class MainForm : Form
    {
        NhanVien_BLL nvbll { get; set; }

        public MainForm()
        {
            InitializeComponent();
            nvbll = new NhanVien_BLL();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            Loadcbb();

        }

        private void contextMenuBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadadd2(NhanVien nv)
        {
            if (cbbNgoaiNgu.FindStringExact(nv.NgoaiNgu) < 0) cbbNgoaiNgu.Items.Add(nv.NgoaiNgu);
            if (cbbNoisinh.FindStringExact(nv.NoiSinh) < 0) cbbNoisinh.Items.Add(nv.NoiSinh);
            if (cbbChuyenNganh.FindStringExact(nv.ChuyenNganh) < 0) cbbChuyenNganh.Items.Add(nv.ChuyenNganh);
            if (cbbDiaChi.FindStringExact(nv.ChoOHienTai) < 0) cbbDiaChi.Items.Add(nv.ChoOHienTai);
        }
        private void Loadcbb()
        {
            DataTable db = nvbll.LayThongTinChoCBB();
            foreach (DataRow i in db.Rows)
            {
                if (cbbNoisinh.FindStringExact(i["NoiSinh"].ToString()) < 0
                    && i["NoiSinh"].ToString() != "")
                {
                    cbbNoisinh.Items.Add(i["NoiSinh"].ToString());
                }

                if (cbbDiaChi.FindStringExact(i["ChoOHienTai"].ToString()) < 0
                    && i["ChoOHienTai"].ToString() != "")
                {
                    cbbDiaChi.Items.Add(i["ChoOHienTai"].ToString());
                }

                if (cbbNgoaiNgu.FindStringExact(i["NgoaiNgu"].ToString()) < 0
                    && i["NgoaiNgu"].ToString() != "")
                {
                    cbbNgoaiNgu.Items.Add(i["NgoaiNgu"].ToString());
                }
                if (cbbTenCV.FindStringExact(i["TenChucVu"].ToString()) < 0
                    && i["TenChucVu"].ToString() != "")
                {
                    cbbTenCV.Items.Add(i["TenChucVu"].ToString());
                }
                if (cbbTenPhBan.FindStringExact(i["TenPhongBan"].ToString()) < 0
                    && i["TenPhongBan"].ToString() != "")
                {
                    cbbTenPhBan.Items.Add(i["TenPhongBan"].ToString());
                }
                if (cbbTenKhoa.FindStringExact(i["TenKhoa"].ToString()) < 0
                    && i["TenKhoa"].ToString() != "")
                {
                    cbbTenKhoa.Items.Add(i["TenKhoa"].ToString());
                }
                if (cbbChuyenNganh.FindStringExact(i["ChuyenNganh"].ToString()) < 0
                    && i["ChuyenNganh"].ToString() != "")
                {
                    cbbChuyenNganh.Items.Add(i["ChuyenNganh"].ToString());
                }
                if (cbbHHam.FindStringExact(i["TenHocHam"].ToString()) < 0
                    && i["TenHocHam"].ToString() != "")
                {
                    cbbHHam.Items.Add(i["TenHocHam"].ToString());
                }
                if (cbbHVi.FindStringExact(i["TenHocVi"].ToString()) < 0
                    && i["TenHocVi"].ToString() != "")
                {
                    cbbHVi.Items.Add(i["TenHocVi"].ToString());
                }
            }
        }

        private void bttracuu_Click(object sender, EventArgs e)
        {
            panel1.Show();
            butThem.Visible = false;
            butSua.Visible = false;
            butXoa.Visible = false;
            butTimKiem.Visible = true;
            txtTimKiem.Visible = true;
        }

        private void butTacVuCapNhap_Click(object sender, EventArgs e) // but
        {
            panel1.Show();
            butTimKiem.Visible = false;
            txtTimKiem.Visible = false;
            butThem.Visible = true;
            butSua.Visible = true;
            butXoa.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void butHienThi_Click(object sender, EventArgs e)
        {
            //dgv.DataSource = nvbll.HienThiNhanVien();
            loadDataWorker.RunWorkerAsync();
        }
        private void show()
        {
            dgv.DataSource = nvbll.HienThiNhanVien();
        }
        private byte[] convertimagetobyte()
        {
            FileStream fs = new FileStream(path1.Text, FileMode.Open, FileAccess.Read);
            byte[] img = new byte[fs.Length];
            fs.Read(img, 0, (int)(fs.Length));
            return img;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose Image (*.jpg;*.png;*.gif)|*.jpg;*.png;*gif";
            op.FilterIndex = 1;
            op.RestoreDirectory = true;
            if (op.ShowDialog() == DialogResult.OK)
            {
                image.ImageLocation = op.FileName;
                path1.Text = op.FileName;
            }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            string ms;
            if (MessageBox.Show("Bạn có muốn xóa nhân viên đã chọn?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow i in dgv.SelectedRows)
                {
                    ms = i.Cells["Mã Nhân Viên"].Value.ToString();
                    nvbll.XoaNhanVien(ms);
                }
                MessageBox.Show("Xóa thành công!");
                show();
            }
            //dgv.DataSource = nvbll.HienThiNhanVien();

        }

        private void butThem_Click(object sender, EventArgs e)
        {
            AddForm ad = new AddForm();
            ad.them = new AddForm.Them(show);
            ad.mf = new AddForm.maf(loadadd2);
            ad.Show();
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string mnv = dgv.SelectedRows[0].Cells["Mã Nhân Viên"].Value.ToString();
            string tenkhoa = dgv.SelectedRows[0].Cells["Khoa"].Value.ToString();
            string tenpb = dgv.SelectedRows[0].Cells["Phòng ban"].Value.ToString();
            string hham = dgv.SelectedRows[0].Cells["Học hàm"].Value.ToString();
            string hvi = dgv.SelectedRows[0].Cells["Học vị"].Value.ToString();
            string tencv = dgv.SelectedRows[0].Cells["Tên Chức Vụ"].Value.ToString();
            Showdetail(tenpb, hham, hvi, tencv, tenkhoa, nvbll.GetNhanVien(mnv));
        }
        private void Showdetail(string tenpb, string hham, string hvi, string tencv, string tenkhoa, NhanVien nv)
        {
            txtMaNV.Text = nv.MaNhanVien.ToString();
            txtTenNV.Text = nv.HoTen;
            txtQueQuan.Text = nv.QueQuan;
            txtSDT.Text = nv.DienThoai;
            txtTruongTN.Text = nv.TruongTN;
            cbbDiaChi.SelectedIndex = cbbDiaChi.FindStringExact(nv.ChoOHienTai);
            cbbHHam.SelectedIndex = cbbHHam.FindStringExact(hham);
            cbbHVi.SelectedIndex = cbbHVi.FindStringExact(hvi);
            cbbTenCV.SelectedIndex = cbbTenCV.FindStringExact(tencv);
            cbbTenKhoa.SelectedIndex = cbbTenKhoa.FindStringExact(tenkhoa);
            cbbTenPhBan.SelectedIndex = cbbTenPhBan.FindStringExact(tenpb);
            cbbChuyenNganh.SelectedIndex = cbbChuyenNganh.FindStringExact(nv.ChuyenNganh);
            cbbNgoaiNgu.SelectedIndex = cbbNgoaiNgu.FindStringExact(nv.NgoaiNgu);
            cbbNoisinh.SelectedIndex = cbbNoisinh.FindStringExact(nv.NoiSinh);
            byte[] MyData = new byte[0];
            DataRow myRow;
            myRow = nvbll.LayHinhAnh(nv.MaHinhAnh).Rows[0];
            MyData = (byte[])myRow["Hinhanh"];
            MemoryStream stream = new MemoryStream(MyData);
            image.Image = new Bitmap(stream);
            if (nv.GioiTinh)
            {
                radMale.Checked = true;
            }
            else
            {
                radFemale.Checked = true;
            }
            txtNamDatHV.Text = nv.NamDatHV;
            txtLinhVucNC.Text = nv.LinhVucNghienCuu;
            dateTimePicker1.Value = nv.NgaySinh;

        }
        private void butSua_Click(object sender, EventArgs e)
        {
            DataTable manv = nvbll.LayMaNV();
            if (MessageBox.Show("Bạn có chắc muốn sửa nhân viên đã chọn?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int mapb = cbbTenPhBan.SelectedItem == null ? -1 : nvbll.getma("PhongBan", "MaPhongBan", "TenPhongBan", cbbTenPhBan.SelectedItem.ToString());
                int makhoa = cbbTenKhoa.SelectedItem == null ? -1 : nvbll.getma("Khoa", "MaKhoa", "TenKhoa", cbbTenKhoa.SelectedItem.ToString());
                int mahh = cbbHHam.SelectedItem == null ? -1 : nvbll.getma("HocHam", "MaHocHam", "TenHocHam", cbbHHam.SelectedItem.ToString());
                int mahv = cbbHVi.SelectedItem == null ? -1 : nvbll.getma("HocVi", "MaHocVi", "TenHocVi", cbbHVi.SelectedItem.ToString());
                int macv = cbbTenCV.SelectedItem == null ? -1 : nvbll.getma("ChucVu", "MaChucVu", "TenChucVu", cbbTenCV.SelectedItem.ToString());
                try
                {
                    NhanVien nv = new NhanVien
                    {

                        MaNhanVien = Convert.ToInt32(txtMaNV.Text),
                        MaChucVu = macv,
                        MaPhongBan = mapb,
                        MaKhoa = makhoa,
                        MaHocHam = mahh,
                        MaHocVi = mahv,
                        LinhVucNghienCuu = txtLinhVucNC.Text,
                        HoTen = txtTenNV.Text,
                        NgaySinh = dateTimePicker1.Value,
                        GioiTinh = radMale.Checked,
                        ChoOHienTai = cbbDiaChi.SelectedItem.ToString(),
                        QueQuan = txtQueQuan.Text,
                        DienThoai = txtSDT.Text,
                        ChuyenNganh = cbbChuyenNganh.SelectedItem.ToString(),
                        TruongTN = txtTruongTN.Text,
                        NamDatHV = txtNamDatHV.Text,
                        NgoaiNgu = cbbNgoaiNgu.Text,
                        NoiSinh = cbbNoisinh.SelectedItem.ToString(),
                        MaHinhAnh = Convert.ToInt32(txtMaNV.Text),
                        //HinhAnh = img
                    };
                    if (p != 0)
                    {
                        nvbll.UpdateHinh(nv.MaHinhAnh, convertimagetobyte());
                        p = 0;
                    }
                    nvbll.UpdateBLL(nv);
                    show();
                    MessageBox.Show("Sửa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LIENHE lh = new LIENHE();
            lh.Show();
        }

        private void butTimKiem_Click(object sender, EventArgs e)
        {
            dgv.DataSource = nvbll.TimKiemNV(txtTimKiem.Text);
        }

        private void butTHONGKE_Click(object sender, EventArgs e)
        {
            THONGKE tk = new THONGKE();
            tk.Show();
        }

        private void butExport_Click(object sender, EventArgs e)
        {
            //fsave.Filter = "(Các tệp excel)|*.xlsx";
            //fsave.ShowDialog();
            //if (fsave.FileName != "")
            //{
           
                ExportWorker.RunWorkerAsync();
                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\Arial.TTF", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font textFontVLC = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font textFontHeader = new iTextSharp.text.Font(bf, 25, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font textFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                Paragraph para = new Paragraph("ĐẠI HỌC BÁCH KHOA ĐẠI HỌC ĐÀ NẴNG \n", textFontVLC);
                Paragraph header = new Paragraph("THÔNG TIN NHÂN SỰ", textFontHeader);
                header.Alignment = 1;
                string gtinh = "Nam";
                if (radFemale.Checked) gtinh = "Nữ";
                string thongtin = @"Mã nhân viên: " + txtMaNV.Text + "\n" +
                    "Tên nhân viên: " + txtTenNV.Text + "\n" + "Ngày sinh: " + dateTimePicker1.Value.ToString() + "\n" +
                    "Giới tính: " + gtinh + "\n" + "Nơi sinh: " + cbbNoisinh.SelectedItem + "\n" +
                    "Địa chỉ: " + cbbDiaChi.SelectedItem + "\n" + "Quê quán: " + txtQueQuan.Text + "\n" +
                    "Khoa: " + cbbTenKhoa.SelectedItem + "\n" + "Phòng ban:" + cbbTenPhBan.SelectedItem + "\n" + "Chức vụ: " +
                    cbbTenCV.SelectedItem + "\n" + "Số điện thoại: " + txtSDT.Text + "\n" +
                    "Ngoại ngữ: " + cbbNgoaiNgu.SelectedItem + "\n" + "Chuyên ngành: " + cbbChuyenNganh.SelectedItem + "\n"
                    + "Trường tốt nghiệp: " + txtTruongTN.Text + "\n" + "Học Hàm: " + cbbHHam.SelectedItem + "\n" + "Học vị: "
                    + cbbHVi.SelectedItem + "\n" + "Lĩnh vực nghiên cứu: " + txtLinhVucNC.Text + "\n";
                Paragraph pdf = new Paragraph(thongtin, textFont);
                var saveDia = new SaveFileDialog();
                saveDia.FileName = "TTNS" + txtMaNV.Text;
                saveDia.DefaultExt = ".pdf";
            //chép
            
                if (saveDia.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fstream = new FileStream(saveDia.FileName, FileMode.Create))
                    {
                        Document pdoc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
                        PdfWriter wri = PdfWriter.GetInstance(pdoc, fstream);
                        pdoc.Open();
                        pdoc.Add(para);
                        pdoc.Add(header);
                        pdoc.Add(pdf);
                        pdoc.Close();
                    }
                    Process.Start(saveDia.FileName);
                }
             
            //}
        }
        int p = 0;
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            p = 1;
        }

        private void loadDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Noi dung cong viec can lam
            butHienThi.Invoke(new Action(() =>
            {
                butHienThi.Enabled = false;
            }));
            dgv.Invoke(new Action(show));
        }

        private void loadDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butHienThi.Invoke(new Action(() =>
            {
                butHienThi.Enabled = true;
            }));
        }

        private void ExportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            labXuat.Invoke(new Action(() =>
            {
                labXuat.Visible = true;
            }));
            butExport.Invoke(new Action(() => { butExport.Enabled = false; }));
            
        }

        private void ExportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labXuat.Invoke(new Action(() =>
            {
                labXuat.Visible = false;
            }));
            butExport.Invoke(new Action(() => { butExport.Enabled = true; }));

        }
    }
}
