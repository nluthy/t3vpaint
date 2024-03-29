﻿using System;
using DAO;
using DTO;

namespace BUS
{
    public class NguoiDungBUS
    {

        #region Xu li nghiep vu
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

        public bool kiemTraMatKhau(String strTDN, String strMK)
        {
            NguoiDungDAO dao = new NguoiDungDAO();
            return (dao.kiemTraMatKhau(strTDN, strMK));
        }

        public NguoiDungDTO layThongTinNguoiDung(String strTDN, String strMK)
        {
            NguoiDungDAO dao = new NguoiDungDAO();
            NguoiDungDTO dto = dao.layThongTinNguoiDung(strTDN, strMK);
            return dto;
        }
        #endregion
    }
}
