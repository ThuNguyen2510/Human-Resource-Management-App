using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.DTO;
namespace QLNS.DAL
{
 public   class NhanVien_DAL
    {
        DataHelper dh { get; set; }
       //string str = "Data Source=DESKTOP-JTU3RKR;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        //string str = @"Data Source=THUY\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        string  str= "Data Source=DESKTOP-56I34NJ;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        public NhanVien_DAL()
        {
            dh = new DataHelper(str);
        }
        public DataTable HienthiNhanVien()
        {
            string query = "select NhanVien.MaNV as 'Mã Nhân Viên',NhanVien.HoTen as'Họ Tên'," +
                "NhanVien.NgaySinh as 'Ngày sinh',NhanVien.NamDatHV as 'Năm Đạt Học Vị'," +
                "NhanVien.DienThoai as'SĐT',NhanVien.GioiTinh as'Giới tính'," +
                "NhanVien.ChuyenNganh as 'Chuyên ngành',NhanVien.QueQuan as 'Quê Quán'," +
                "NhanVien.LinhVucNghienCuu as 'Lĩnh vực nghiên cứu',Khoa.TenKhoa as 'Khoa'," +
                "PhongBan.TenPhongBan as 'Phòng ban',NhanVien.NoiSinh as 'Nơi sinh'" +
                ",HocHam.TenHocHam as 'Học hàm',HocVi.TenHocVi as 'Học vị'," +
                "NhanVien.NgoaiNgu as 'Ngoại ngữ',NhanVien.ChoOHienTai as 'Chỗ ở hiện tại'," +
                "NhanVien.TruongTN as'Trường tốt nghiệp',ChucVu.TenChucVu as 'Tên Chức Vụ'," +
                "NhanVien.MaHinhAnh as 'Mã Hình Ảnh' from Khoa " +
                "right join NhanVien on Khoa.MaKhoa = NhanVien.MaKhoa " +
                "left join PhongBan on   PhongBan.MaPhongBan = NhanVien.MaPhongBan " +
                "left join HocHam on HocHam.MaHocHam = NhanVien.MaHocHam" +
                " left join HocVi on HocVi.MaHocVi = NhanVien.MaHocVi " +
                "left join ChucVu on ChucVu.MaChucVu=NhanVien.MaChucVu";
           return dh.GetTable(query);
        }
        public void XoaNhanVien(string ms)
        {
            string query = "delete From NhanVien where MaNV='" + ms + "'";
            this.dh.ExcuteNonQuery(query);
        }
        public DataTable TimKiemNV(string s)
        {
            string query = "select NhanVien.MaNV  as 'Mã nhân viên', NhanVien.HoTen as 'Họ Tên', NhanVien.NgaySinh as 'Ngày Sinh'," +
             " NhanVien.NamDatHV as 'Năm đạt học vị' , NhanVien.DienThoai as 'Điện thoại',NhanVien.GioiTinh as 'Giới tính',NhanVien.ChuyenNganh as 'Chuyên ngành'," +
             "NhanVien.QueQuan as 'Quê quán',NhanVien.LinhVucNghienCuu as'Lĩnh vực nghiên cứu' ," +
             "Khoa.TenKhoa as 'Khoa',PhongBan.TenPhongBan as 'Phòng Ban'," +
             "NhanVien.NoiSinh as 'Nơi sinh',HocHam.TenHocHam as 'Học hàm'," +
             "HocVi.TenHocVi as 'Học vị',NhanVien.NgoaiNgu as 'Ngoại ngữ'," +
             "NhanVien.ChoOHienTai as 'Chỗ ở hiện tại'," +
             "NhanVien.TruongTN as 'Trường tốt nghiệp',NhanVien.MaHinhAnh as 'Mã hình ảnh',ChucVu.TenChucVu as 'Tên chức vụ' from Khoa " +
             "right join NhanVien on Khoa.MaKhoa = NhanVien.MaKhoa " +
             "left join PhongBan on PhongBan.MaPhongBan = NhanVien.MaPhongBan " +
             "left join HocHam on HocHam.MaHocHam = NhanVien.MaHocHam " +
             "left join HocVi on HocVi.MaHocVi = NhanVien.MaHocVi " +
             "left join ChucVu on ChucVu.MaChucVu = NhanVien.MaChucVu " +
              "where NhanVien.HoTen LIKE N'%" + s + "%' or Khoa.TenKhoa LIKE N'%" + s + "%'" +
             " or PhongBan.TenPhongBan LIKE N'%" + s + "%' or ChucVu.TenChucVu Like N'%" + s + "%'";
            return dh.GetTable(query);
        }
   
        public DataTable LayHinhAnh(int maha)
        {
            string query = "Select Hinhanh from HinhAnh where MaHinhAnh ='" + maha + "'";

            return dh.GetTable(query);

        }
        public DataTable LayMaNV()
        {
            string query = "select MaNV from NhanVien";
            return dh.GetTable(query);
        }
        
        public DataTable LayThongTinChoCBB()
        {
            string query = "select NhanVien.ChuyenNganh,NhanVien.NoiSinh," +
                 "Khoa.TenKhoa,PhongBan.TenPhongBan" +
                 ",HocHam.TenHocHam,HocVi.TenHocVi,NhanVien.NgoaiNgu,NhanVien.ChoOHienTai," +
                 "ChucVu.TenChucVu from Khoa " +
                 "right join NhanVien on Khoa.MaKhoa = NhanVien.MaKhoa " +
                 "left join PhongBan on   PhongBan.MaPhongBan = NhanVien.MaPhongBan " +
                 "left join HocHam on HocHam.MaHocHam = NhanVien.MaHocHam" +
                 " left join HocVi on HocVi.MaHocVi = NhanVien.MaHocVi " +
                 "left join ChucVu on ChucVu.MaChucVu=NhanVien.MaChucVu";
            return dh.GetTable(query);
        }
        // get mã khoa, mã phòng ban, mã học hàm, mã học vị,max chuc vu
        public int getma(string tablename, string Ma, string ColumnName, string k)
        {
            string query = "select " + Ma + " from " + tablename + " where " + ColumnName + " = N'" + k + "'";
            string x = "";
            DataTable dt = dh.GetTable(query);
            foreach(DataRow i in dt.Rows)
            {
                x = i[Ma].ToString();
            }
            if (dt.Rows.Count == 0) return -1;
            else
            return Convert.ToInt32(x);
        }
        // get ten 
        public string getten(string tablename, string columnname, string ma,int k)
        {
            string query = "select " +columnname+ " from " + tablename + " where " + ma + "='" + k + "'";
            string x = "";
            DataTable dt = dh.GetTable(query);
            foreach (DataRow i in dt.Rows)
            {
                x = i[columnname].ToString();
            }
            return x;

        }
        private void insert(NhanVien nv,string namecolumn, string x)
        {
            // khong co hoc ham
            if (nv.MaHocHam == -1)
            {
                string query11 = "Insert into NhanVien (MaNV,HoTen,GioiTinh,NgaySinh,NoiSinh,DienThoai,QueQuan,ChoOHienTai," +
"LinhVucNghienCuu," + namecolumn + ",ChuyenNganh,NamDatHV,TruongTN,MaHocVi,MaHinhAnh,NgoaiNgu," +
"MaChucVu) values ('" + nv.MaNhanVien + "',N'" + nv.HoTen + "','"
+ nv.GioiTinh + "','" + nv.NgaySinh + "',N'" + nv.NoiSinh + "','" + nv.DienThoai +
"',N'" + nv.QueQuan + "',N'" + nv.ChoOHienTai + "',N'" + nv.LinhVucNghienCuu + "','" +x+
 "',N'" + nv.ChuyenNganh + "','" + nv.NamDatHV + "',N'" + nv.TruongTN + "','" +
nv.MaHocVi + "','" + nv.MaHinhAnh + "',N'" + nv.NgoaiNgu + "','" + nv.MaChucVu + "')";
                dh.ExcuteNonQuery(query11);
            }
            // khong co hoc vi
            else if (nv.MaHocVi == -1)
            {
                string query2 = "Insert into NhanVien (MaNV,HoTen,GioiTinh,NgaySinh,NoiSinh,DienThoai,QueQuan,ChoOHienTai," +
"LinhVucNghienCuu,"+namecolumn+",ChuyenNganh,NamDatHV,TruongTN,MaHocHam,MaHinhAnh,NgoaiNgu," +
"MaChucVu) values ('" + nv.MaNhanVien + "',N'" + nv.HoTen + "','"
+ nv.GioiTinh + "','" + nv.NgaySinh + "',N'" + nv.NoiSinh + "','" + nv.DienThoai +
"',N'" + nv.QueQuan + "',N'" + nv.ChoOHienTai + "',N'" + nv.LinhVucNghienCuu + "','" +
x + "',N'" + nv.ChuyenNganh + "','" + nv.NamDatHV + "',N'" + nv.TruongTN + "','" +
nv.MaHocHam + "','" + nv.MaHinhAnh + "',N'" + nv.NgoaiNgu + "','" + nv.MaChucVu + "')";
                dh.ExcuteNonQuery(query2);
            }
        }
        public void ThemHinhAnh(int ma, byte[] img)
        {
            dh.Ex2(ma, img);
        }
        public void ThemNV(NhanVien nv)
        {
            if(nv.MaPhongBan==-1)
            {
                // khong co phong ban
                insert(nv,"MaKhoa",nv.MaKhoa.ToString());
                if (nv.MaHocHam != -1 && nv.MaHocVi != -1)
                {
                    string query2 = "Insert into NhanVien (MaNV,HoTen,GioiTinh,NgaySinh,NoiSinh,DienThoai,QueQuan,ChoOHienTai," +
"LinhVucNghienCuu,MaKhoa,ChuyenNganh,NamDatHV,TruongTN,MaHocVi,MaHinhAnh,NgoaiNgu," +
"MaChucVu,MaHocHam) values ('" + nv.MaNhanVien + "',N'" + nv.HoTen + "','"
+ nv.GioiTinh + "','" + nv.NgaySinh + "',N'" + nv.NoiSinh + "','" + nv.DienThoai +
"',N'" + nv.QueQuan + "',N'" + nv.ChoOHienTai + "',N'" + nv.LinhVucNghienCuu + "','" +
nv.MaKhoa + "',N'" + nv.ChuyenNganh + "','" + nv.NamDatHV + "',N'" + nv.TruongTN + "','" +
nv.MaHocVi + "','" + nv.MaHinhAnh + "',N'" + nv.NgoaiNgu + "','" + nv.MaChucVu + "','" + nv.MaHocHam + "')";
                    dh.ExcuteNonQuery(query2);
                }
             }
           else if(nv.MaKhoa==-1)
            { // khong co khoa
                insert(nv,"MaPhongBan",nv.MaPhongBan.ToString());
                if(nv.MaHocVi!=-1 && nv.MaHocHam!=-1)
                {
                    string query2 = "Insert into NhanVien (MaNV,HoTen,GioiTinh,NgaySinh,NoiSinh,DienThoai,QueQuan,ChoOHienTai," +
      "LinhVucNghienCuu,MaPhongBan,ChuyenNganh,NamDatHV,TruongTN,MaHocVi,MaHinhAnh,NgoaiNgu," +
      "MaChucVu,MaHocHam) values ('" + nv.MaNhanVien + "',N'" + nv.HoTen + "','"
+ nv.GioiTinh + "','" + nv.NgaySinh + "',N'" + nv.NoiSinh + "','" + nv.DienThoai +
"',N'" + nv.QueQuan + "',N'" + nv.ChoOHienTai + "',N'" + nv.LinhVucNghienCuu + "','" +
nv.MaPhongBan + "',N'" + nv.ChuyenNganh + "','" + nv.NamDatHV + "',N'" + nv.TruongTN + "','" +
nv.MaHocVi + "','" + nv.MaHinhAnh + "',N'" + nv.NgoaiNgu + "','" + nv.MaChucVu + "','" + nv.MaHocHam + "')";
                    dh.ExcuteNonQuery(query2);

                }
  
            }

            else // co khoa co phong
            {// k co hoc vi
                if(nv.MaHocVi==-1)
                {
                    string query = "Insert into NhanVien (MaNV,HoTen,GioiTinh,NgaySinh,NoiSinh,DienThoai,QueQuan,ChoOHienTai," +
     "LinhVucNghienCuu,MaPhongBan,ChuyenNganh,NamDatHV,TruongTN,MaHinhAnh,NgoaiNgu," +
     "MaChucVu,MaHocHam,MaKhoa) values ('" + nv.MaNhanVien + "',N'" + nv.HoTen + "','"
+ nv.GioiTinh + "','" + nv.NgaySinh + "',N'" + nv.NoiSinh + "','" + nv.DienThoai +
"',N'" + nv.QueQuan + "',N'" + nv.ChoOHienTai + "',N'" + nv.LinhVucNghienCuu + "','" +
nv.MaPhongBan + "',N'" + nv.ChuyenNganh + "','" + nv.NamDatHV + "',N'" + nv.TruongTN + "','"
+ nv.MaHinhAnh + "',N'" + nv.NgoaiNgu + "','" + nv.MaChucVu + "','" + nv.MaHocHam +"','"+nv.MaKhoa+ "')";
                    dh.ExcuteNonQuery(query);
                }
                // khong co hoc ham
                else if(nv.MaHocHam==-1)
                {
                    string query11 = "Insert into NhanVien (MaNV,HoTen,GioiTinh,NgaySinh,NoiSinh,DienThoai,QueQuan,ChoOHienTai," +
    "LinhVucNghienCuu,MaPhongBan,ChuyenNganh,NamDatHV,TruongTN,MaHinhAnh,NgoaiNgu," +
    "MaChucVu,MaHocVi,MaKhoa) values ('" + nv.MaNhanVien + "',N'" + nv.HoTen + "','"
+ nv.GioiTinh + "','" + nv.NgaySinh + "',N'" + nv.NoiSinh + "','" + nv.DienThoai +
"',N'" + nv.QueQuan + "',N'" + nv.ChoOHienTai + "',N'" + nv.LinhVucNghienCuu + "','" +
nv.MaPhongBan + "',N'" + nv.ChuyenNganh + "','" + nv.NamDatHV + "',N'" + nv.TruongTN + "','"
+ nv.MaHinhAnh + "',N'" + nv.NgoaiNgu + "','" + nv.MaChucVu + "','" + nv.MaHocVi + "','" + nv.MaKhoa + "')";
                    dh.ExcuteNonQuery(query11);

                }
                // ca phong ca khoa,ca hoc ham ca hoc vi
                else if (nv.MaHocHam!=-1 && nv.MaHocVi!=-1)
                    {
                  
                    string query2 = "Insert into NhanVien values ('" + nv.MaNhanVien + "',N'" + nv.HoTen + "','"
                + nv.GioiTinh + "','" + nv.NgaySinh + "',N'" + nv.NoiSinh + "','" + nv.MaPhongBan + "','" + nv.DienThoai +
                "',N'" + nv.QueQuan + "',N'" + nv.ChoOHienTai + "',N'" + nv.LinhVucNghienCuu + "','" +
                nv.MaKhoa + "',N'" + nv.ChuyenNganh + "','" + nv.NamDatHV + "',N'" + nv.TruongTN + "','" +
                nv.MaHocVi + "','" + nv.MaHinhAnh + "',N'" + nv.NgoaiNgu + "','" + nv.MaChucVu + "','" + nv.MaHocHam + "')";
                    dh.ExcuteNonQuery(query2);
                }

            }

        }
        public NhanVien GetNhanVien(string mnv)
        {
            string query = "select NhanVien.MaNV,NhanVien.HoTen,NhanVien.NgaySinh,NhanVien.NamDatHV," +
                "NhanVien.DienThoai,NhanVien.GioiTinh,NhanVien.ChuyenNganh,NhanVien.QueQuan," +
                "NhanVien.LinhVucNghienCuu ,Khoa.TenKhoa,PhongBan.TenPhongBan,NhanVien.NoiSinh" +
                ",HocHam.TenHocHam,HocVi.TenHocVi,NhanVien.NgoaiNgu,NhanVien.ChoOHienTai," +
                "NhanVien.TruongTN,NhanVien.MaHinhAnh,ChucVu.TenChucVu from Khoa " +
                "right join NhanVien on Khoa.MaKhoa = NhanVien.MaKhoa " +
                "left join PhongBan on   PhongBan.MaPhongBan = NhanVien.MaPhongBan " +
                "left join HocHam on HocHam.MaHocHam = NhanVien.MaHocHam" +
                " left join HocVi on HocVi.MaHocVi = NhanVien.MaHocVi " +
                "left join ChucVu on ChucVu.MaChucVu=NhanVien.MaChucVu where MaNV='" + mnv + "'";
            DataTable dt = dh.GetTable(query);
            return new NhanVien
            {
                MaNhanVien = Convert.ToInt32(mnv),
                HoTen = dt.Rows[0]["HoTen"].ToString(),
                DienThoai = dt.Rows[0]["DienThoai"].ToString(),
                NgaySinh = Convert.ToDateTime(dt.Rows[0]["NgaySinh"]),
                GioiTinh = Convert.ToBoolean(dt.Rows[0]["GioiTinh"]),
                NoiSinh = dt.Rows[0]["NoiSinh"].ToString(),
                MaPhongBan = getma("PhongBan","MaPhongBan","TenPhongBan", dt.Rows[0]["TenPhongBan"].ToString()),
                QueQuan = dt.Rows[0]["QueQuan"].ToString(),
                ChoOHienTai = dt.Rows[0]["ChoOHienTai"].ToString(),
                LinhVucNghienCuu = dt.Rows[0]["LinhVucNghienCuu"].ToString(),
                MaKhoa = getma("Khoa", "MaKhoa", "TenKhoa", dt.Rows[0]["TenKhoa"].ToString()),
                ChuyenNganh = dt.Rows[0]["ChuyenNganh"].ToString(),
                NamDatHV = dt.Rows[0]["NamDatHV"].ToString(),
                TruongTN = dt.Rows[0]["TruongTN"].ToString(),
                MaHocVi = getma("HocVi", "MaHocVi", "TenHocVi", dt.Rows[0]["TenHocVi"].ToString()),
                MaHocHam = getma("HocHam", "MaHocHam", "TenHocHam", dt.Rows[0]["TenHocHam"].ToString()), 
                MaHinhAnh = Convert.ToInt32(dt.Rows[0]["MaHinhAnh"]),
                NgoaiNgu = dt.Rows[0]["NgoaiNgu"].ToString(),
                MaChucVu = getma("ChucVu", "MaChucVu", "TenChucVu", dt.Rows[0]["TenChucVu"].ToString()),
            };
        }
        public void Update(NhanVien nv)
        {
            bool gt;
            if (nv.GioiTinh)
            {
                gt = true;
            }
            else
            {
                gt = false;
            }
            string query = "";
            if(nv.MaKhoa==-1)
            {
                if(nv.MaHocHam==-1)
                {
                    query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan='" + nv.MaPhongBan + "'" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '', MaHocVi = '" + nv.MaHocVi + "', MaKhoa = ''," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";
                   
                }
                else if(nv.MaHocVi==-1)
                {
                    query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan='" + nv.MaPhongBan + "'" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '" + nv.MaHocHam + "', MaHocVi = '', MaKhoa = ''," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";

                }
                else
                {
                    query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan='" + nv.MaPhongBan + "'" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '" + nv.MaHocHam + "', MaHocVi = '"+nv.MaHocVi+"', MaKhoa = ''," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";

                }
            }
            else if(nv.MaPhongBan==-1)
            {
                if(nv.MaHocHam==-1)
                {
                    query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan=''" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '', MaHocVi = '" + nv.MaHocVi + "', MaKhoa = '" + nv.MaKhoa + "'," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";
                    //dh.ExcuteNonQuery(query3);
                }
                else if(nv.MaHocVi==-1)
                {
                    query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan=''" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '" + nv.MaHocHam + "', MaHocVi = '', MaKhoa = '" + nv.MaKhoa + "'," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";

                }
                else
                {
                    query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan=''" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '" + nv.MaHocHam + "', MaHocVi = '"+nv.MaHocVi+"', MaKhoa = '" + nv.MaKhoa + "'," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";

                }
            }
            else if(nv.MaKhoa!=-1&&nv.MaPhongBan!=-1&&nv.MaHocHam==-1)
            {
                query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan='" + nv.MaPhongBan + "'" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '', MaHocVi = '" + nv.MaHocVi + "', MaKhoa = '" + nv.MaKhoa + "'," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";
            }
            else if (nv.MaKhoa != -1 && nv.MaPhongBan != -1 && nv.MaHocVi == -1)
            {
                query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan='" + nv.MaPhongBan + "'" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '" + nv.MaHocHam + "', MaHocVi = '', MaKhoa = '" + nv.MaKhoa + "'," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";
            }
            else
            {
                query = "update NhanVien set HoTen=N'" + nv.HoTen + "', GioiTinh='" + gt + "',NgaySinh='" + nv.NgaySinh + "'" +
                    ",LinhVucNghienCuu=N'" + nv.LinhVucNghienCuu + "',NoiSinh=N'" + nv.NoiSinh + "',MaPhongBan='"+nv.MaPhongBan+"'" +
                    ", MaChucVu = '" + nv.MaChucVu + "', MaHocHam = '" + nv.MaHocHam + "', MaHocVi = '"+nv.MaHocVi+"', MaKhoa = '" + nv.MaKhoa + "'," +
                    " NamDatHV = '" + nv.NamDatHV + "', QueQuan = N'" + nv.QueQuan + "', ChoOHienTai = N'" + nv.ChoOHienTai + "'," +
                    " ChuyenNganh = N'" + nv.ChuyenNganh + "',NgoaiNgu= N'" + nv.NgoaiNgu + "', TruongTN = N'" + nv.TruongTN + "'," +
                    "DienThoai='" + nv.DienThoai + "', MaHinhAnh='" + nv.MaHinhAnh + "' where MaNV = '" + nv.MaNhanVien + "'";
            }

            dh.ExcuteNonQuery(query);
        }
        public void UpdateHinh(int ma, byte[] hinh)
        {
            dh.Suaha(ma, hinh);
        }
        public void XoaNhanVien_DAL(string ms)
        {
            string query = " DELETE from NhanVien where NhanVien.MaNV = '" + ms + "'";
            string query2 = " DELETE from HinhAnh where HinhAnh.MaHinhAnh = '" + ms + "'";
            this.dh.ExcuteNonQuery(query);
            this.dh.ExcuteNonQuery(query2);
        }
        public DataTable ThongKeNV_DAL(string ms)
        {

            string query = "select NhanVien.MaNV  as 'Mã nhân viên', NhanVien.HoTen as 'Họ Tên', NhanVien.NgaySinh as 'Ngày Sinh'," +
               " NhanVien.NamDatHV as 'Năm đạt học vị' , NhanVien.DienThoai as 'Điện thoại',NhanVien.GioiTinh as 'Giới tính',NhanVien.ChuyenNganh as 'Chuyên ngành'," +
               "NhanVien.QueQuan as 'Quê quán',NhanVien.LinhVucNghienCuu as'Lĩnh vực nghiên cứu' ," +
               "Khoa.TenKhoa as 'Khoa',PhongBan.TenPhongBan as 'Tên Phòng Ban'," +
               "NhanVien.NoiSinh as 'Nơi sinh',HocHam.TenHocHam as 'Tên học hàm'," +
               "HocVi.TenHocVi as 'Tên học vị',NhanVien.NgoaiNgu as 'Ngoại ngữ'," +
               "NhanVien.ChoOHienTai as 'Chỗ ở hiện tại'," +
               "NhanVien.TruongTN as 'Trường tốt nghiệp',NhanVien.MaHinhAnh as 'Mã hình ảnh'," +
               "ChucVu.TenChucVu as 'Tên chức vụ' from Khoa " +
               "right join NhanVien on Khoa.MaKhoa = NhanVien.MaKhoa " +
               "left join PhongBan on PhongBan.MaPhongBan = NhanVien.MaPhongBan " +
               "left join HocHam on HocHam.MaHocHam = NhanVien.MaHocHam " +
               "left join HocVi on HocVi.MaHocVi = NhanVien.MaHocVi " +
               "left join ChucVu on ChucVu.MaChucVu = NhanVien.MaChucVu " +
               "where Khoa.TenKhoa LIKE N'" + ms + "'" +
               " or PhongBan.TenPhongBan LIKE N'" + ms + "'";
            // this.dh.ExcuteNonQuery(query);
            return dh.GetTable(query);
        }
        public DataTable sodtkhoa(string ms)
        {
            string query = "select SoDT from Khoa where TenKhoa = N'" + ms + "'";
            return dh.GetTable(query);
        }
        public DataTable sodtPhongban(string ms)
        {
            string query = "select SoDT from PhongBan where TenPhongBan = N'" + ms + "'";
            return dh.GetTable(query);
        }
    }
}
