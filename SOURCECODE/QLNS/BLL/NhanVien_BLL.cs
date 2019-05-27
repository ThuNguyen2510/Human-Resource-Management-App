using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.DAL;
using QLNS.DTO;
namespace QLNS.BLL
{
    class NhanVien_BLL
    {
        NhanVien_DAL nvdal { get; set; }
        public NhanVien_BLL()
        {
            nvdal = new NhanVien_DAL();
        }
        public DataTable HienThiNhanVien()
        {
            return nvdal.HienthiNhanVien();
        }
        public DataTable TimKiemNV(string k)
        {
            return nvdal.TimKiemNV(k);
        }
            public DataTable LayHinhAnh(int maha)
        {
            return nvdal.LayHinhAnh(maha);
        }
        public DataTable LayMaNV()
        {
            return nvdal.LayMaNV();
        }
        public DataTable LayThongTinChoCBB()
        {
            return nvdal.LayThongTinChoCBB();
        }
        public void ThemNV(NhanVien nv)
        {
            nvdal.ThemNV(nv);
        }
        public void ThemHinhAnh(int ma, byte[] img)
        {
            nvdal.ThemHinhAnh(ma, img);
        }
        public int getma(string tablename, string Ma, string NameColumn, string k)
        {
            return nvdal.getma(tablename,Ma,NameColumn,k);
        }
        public NhanVien GetNhanVien(string m)
        {
            return nvdal.GetNhanVien(m);
        }
        public void UpdateBLL(NhanVien nv)
        {
            nvdal.Update(nv);
        }
        public void UpdateHinh(int ma, byte[] hinh)
        {
            nvdal.UpdateHinh(ma, hinh);
        }
        public void XoaNhanVien(string ms)
        {
            nvdal.XoaNhanVien_DAL(ms);
        }
        public string getten(string tablename, string columnname,string ma,int k)
        {
            return nvdal.getten(tablename, columnname, ma, k);
        }
        public DataTable ThongKeNV_BLL(string ms)
        {
            return nvdal.ThongKeNV_DAL(ms);
        }
        public DataTable SoDTkhoa(string ms)
        {
            return nvdal.sodtkhoa(ms);
        }
        public DataTable SoDTPhongBan(string ms)
        {
            return nvdal.sodtPhongban(ms);
        }
    }   
}

