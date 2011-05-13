using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;

namespace BUS
{
    public class NguoiDungBUS
    {
        public void themNguoiDung(NguoiDungDTO dto)
        {
            NguoiDungDAO dao = new NguoiDungDAO();
            dao.themNguoiDung(dto);
        }

        public bool kiemTraNguoiDung(String strTenDangNhap, String strEmail)
        {
            NguoiDungDAO dao = new NguoiDungDAO();
            return (dao.kiemTraNguoiDung(strTenDangNhap, strEmail));
                
        }
    }
}
