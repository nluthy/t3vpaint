using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DTO;
namespace DAO
{
    public class NguoiDungDAO
    {
        public void themNguoiDung(NguoiDungDTO nd)
        {
            String strCommand = "Insert Into NguoiDung(TenDangNhap, MatKhau, HoTen, NgaySinh, Email, DienThoai, SoHinhVe)" 
            +" Values (?, ?, ?, ?, ?, ?, ?)";
            KetNoi.moKetNoi();
            OleDbConnection conn = KetNoi.connKetNoi;
            OleDbCommand comm = new OleDbCommand(strCommand, conn);
            comm.Parameters.Add("@TDN", OleDbType.VarChar);
            comm.Parameters.Add("@MK", OleDbType.VarChar);
            comm.Parameters.Add("@HT", OleDbType.VarChar);
            comm.Parameters.Add("@NS", OleDbType.Date);
            comm.Parameters.Add("@Email", OleDbType.VarChar);
            comm.Parameters.Add("@DT", OleDbType.VarChar);
            comm.Parameters.Add("@SHV", OleDbType.Integer);
            comm.Parameters["@TDN"].Value = nd.TenDangNhap;
            comm.Parameters["@MK"].Value = nd.MatKhau;
            comm.Parameters["@HT"].Value = nd.HoTen;
            comm.Parameters["@NS"].Value = nd.NgaySinh;
            comm.Parameters["@Email"].Value = nd.Email;
            comm.Parameters["@DT"].Value = nd.DienThoai;
            comm.Parameters["@SHV"].Value = nd.SoHinhVe;
            comm.ExecuteNonQuery();
        }

        public bool kiemTraNguoiDung(String strTenDangNhap, String strEmail)
        {
            String strCommand1 = "Select * From NguoiDung Where TenDangNhap = '" + strTenDangNhap +"'";
            DataTable dt1 = KetNoi.thucThiTruyVan(strCommand1);
            String strCommand2 = "Select * From NguoiDung Where Email = '" + strEmail + "'";
            DataTable dt2 = KetNoi.thucThiTruyVan(strCommand2);
            if(dt1.Rows.Count!=0 || dt2.Rows.Count!=0)
            {
                return true;
            }
            return false;
            
        }


        //public NguoiDungDTO LayThongTinNDTuEmail(String strEmail)
        //{
        //    String strCommand = "Select * From NguoiDung Where Email = '" + strEmail + "'";
        //    OleDbDataReader odr = KetNoi.thucThiTruyVan(strCommand);
        //    if (odr.HasRows)
        //    {
        //        NguoiDungDTO nd = new NguoiDungDTO(odr.GetString(0), odr.GetString(1), odr.GetString(2),
        //            odr.GetDateTime(3), odr.GetString(4), odr.GetString(5), odr.GetInt32(6));
        //        return nd;
        //    }
        //    else
        //    {
        //        NguoiDungDTO nd = new NguoiDungDTO();
        //        return nd;
        //    }
        //}
    }
}
