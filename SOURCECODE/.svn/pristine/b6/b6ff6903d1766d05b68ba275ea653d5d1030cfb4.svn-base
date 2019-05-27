using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.DAL
{
 public  class DataHelper
    {
        public SqlConnection con { get; set; }
        public DataHelper(string str)
        {
            this.con = new SqlConnection(str);

        }
        public DataTable GetTable(string query)
        {
            SqlDataAdapter ap = new SqlDataAdapter(query, this.con);
            if(this.con.State==ConnectionState.Closed)this.con.Open();
            DataTable dt = new DataTable();
            ap.Fill(dt);
            this.con.Close();
            return dt;

        }
        public void ExcuteNonQuery(string query)
        {
            SqlCommand comm = new SqlCommand(query, this.con);
            if(con.State==ConnectionState.Closed)this.con.Open();
            comm.ExecuteNonQuery();
            this.con.Close();
        }
        public void Ex2(int ma, byte[] img)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO HinhAnh(MaHinhAnh, Hinhanh) values(@Ma, @Image)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters["@Ma"].Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@Image", SqlDbType.Image);
            cmd.Parameters["@Image"].Direction = ParameterDirection.Input;
            // Lưu trữ mảng byte vào cột Image
            cmd.Parameters["@Image"].Value = img;
            con.Open();
            cmd.ExecuteNonQuery();
        }
        public void Suaha(int ma, byte[] img)
        {
            string query = "update HinhAnh set Hinhanh=@Image where MaHinhAnh=@Ma";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters["@Ma"].Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@Image", SqlDbType.Image);
            cmd.Parameters["@Image"].Direction = ParameterDirection.Input;
            // Lưu trữ mảng byte vào cột Image
            cmd.Parameters["@Image"].Value = img;
            con.Open();
            cmd.ExecuteNonQuery();
        }

    }
}
