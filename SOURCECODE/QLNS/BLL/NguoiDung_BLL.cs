using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.DAL;
namespace QLNS.BLL
{
    public class NguoiDung_BLL
    {
        public NguoiDung_DAL nd { get; set; }
        public NguoiDung_BLL()
        {
            this.nd = new NguoiDung_DAL();
        }
        public DataTable LayNguoidung()
        {
            return nd.LayNguoidung();

        }
    }
}
