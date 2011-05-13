using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NguoiDungDTO
    {
        String m_strTenDangNhap;
        String m_strMatKhau;
        String m_strHoTen;
        DateTime m_dtNgaySinh;
        String m_strEmail;
        String m_strDienThoai;
        int m_iSoHinhVe;
        bool m_bDangNhap = false;

        public String TenDangNhap
        {
            get { return m_strTenDangNhap; }
            set { m_strTenDangNhap = value; }
        }

        public String MatKhau
        {
            get { return m_strMatKhau; }
            set { m_strMatKhau = value; }
        }

        public String HoTen
        {
            get { return m_strHoTen; }
            set { m_strHoTen = value; }
        }

        public DateTime NgaySinh
        {
            get { return m_dtNgaySinh; }
            set { m_dtNgaySinh = value; }
        }

        public String Email
        {
            get { return m_strEmail; }
            set { m_strEmail = value; }
        }

        public String DienThoai
        {
            get { return m_strDienThoai; }
            set { m_strDienThoai = value; }
        }

        public int SoHinhVe
        {
            get { return m_iSoHinhVe; }
            set { m_iSoHinhVe = value; }
        }

        public bool DangNhap
        {
            get { return m_bDangNhap; }
            set { m_bDangNhap = value; }
        }

        public NguoiDungDTO()
        {
            m_strTenDangNhap = m_strMatKhau = m_strHoTen = m_strEmail = m_strDienThoai = "";
            m_dtNgaySinh = new DateTime();
            m_iSoHinhVe = 0;
        }

        public NguoiDungDTO(String strTenDangNhap, String strMatKhau, String strHoTen, DateTime dtNgaySinh,
            String strEmail, String strDienThoai, int iSoHinhVe)
        {
            m_strTenDangNhap = strTenDangNhap;
            m_strMatKhau = strMatKhau;
            m_strHoTen = strHoTen;
            m_dtNgaySinh = dtNgaySinh;
            m_strEmail = strEmail;
            m_strDienThoai = strDienThoai;
            m_iSoHinhVe = iSoHinhVe;
        }
    }
}
