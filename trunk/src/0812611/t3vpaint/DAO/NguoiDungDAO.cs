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
            KetNoi.dongKetNoi();
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

        public bool kiemTraMatKhau(String strTDN, String strMK)
        {
            KetNoi.moKetNoi();
            String strCommand = "Select MatKhau From NguoiDung Where TenDangNhap ='"+strTDN+"'";
            OleDbCommand comm = new OleDbCommand(strCommand, KetNoi.connKetNoi);
            String MK = (String)comm.ExecuteScalar();
            KetNoi.dongKetNoi();
            return(MK.Equals(strMK));
        }

        public NguoiDungDTO layThongTinNguoiDung(String strTDN, String strMK)
        {
            NguoiDungDTO dto = new NguoiDungDTO();
            KetNoi.moKetNoi();
            String strCommand = "Select TenDangNhap, MatKhau, HoTen, NgaySinh, Email, DienThoai, SoHinhVe" + 
            " From NguoiDung Where TenDangNhap = '"+strTDN+"' And MatKhau = '"+strMK+"'";
            OleDbCommand comm = new OleDbCommand(strCommand, KetNoi.connKetNoi);
            OleDbDataReader odr = comm.ExecuteReader();
            while (odr.Read())
            {
                dto.TenDangNhap = odr.GetString(0);
                dto.MatKhau = odr.GetString(1);
                dto.HoTen = odr.GetString(2);
                dto.NgaySinh = odr.GetDateTime(3);
                dto.Email = odr.GetString(4);
                dto.DienThoai = odr.GetString(5);
                dto.SoHinhVe = odr.GetInt32(6);
            }
            KetNoi.dongKetNoi();
            return dto;
        }




        
    }
}
