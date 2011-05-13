using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DTO;
using BUS;
using System.Windows.Forms;

namespace t3vpaint
{
    public partial class ManHinhDangKi : Form
    {
        public ManHinhDangKi()
        {
            InitializeComponent();
        }

        

        private void tbx_TenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '@' || e.KeyChar == '-' ||e.KeyChar == ' ')
            {
                MessageBox.Show("Tên đăng nhập không được chứa các kí tự đặc biệt: /, *, @, -, .", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void tbx_DienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar < '0' || e.KeyChar > '9')
            {
                MessageBox.Show("Số điện thoại chỉ bao gồm các kí tự số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Close();
        }


        private bool kiemTraDoDaiHopLe()
        {
            if (tbx_TenDangNhap.TextLength==0 || tbx_MatKhau.TextLength==0 || tbx_Email.TextLength==0 || 
                tbx_TenDangNhap.TextLength > 10 || tbx_MatKhau.TextLength > 10 || tbx_HoTen.TextLength > 50 
                || tbx_Email.TextLength > 50 || tbx_DienThoai.TextLength > 11)
                return false;
            return true;
        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            if (!kiemTraDoDaiHopLe())
                MessageBox.Show("Bạn mắc 1 trong các lỗi sau:\n - Bạn chưa nhập tên đăng nhập hoặc mật khẩu hoặc email.\n"
                    + " - Bạn đã nhập tên đăng nhập hoặc mật khẩu dài hơn 10 kí tự.\n - Bạn đã nhập họ tên hoặc email "
            + "dài hơn 50 kí tự.\n - Bạn đã nhập số điện thoại nhiều hơn 11 chữ số.\nVui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                String strTDN = tbx_TenDangNhap.Text;
                String strMK = tbx_MatKhau.Text;
                String strHT = tbx_HoTen.Text;
                DateTime dtNS = dtpick.Value;
                String strEmail = tbx_Email.Text;
                String strDT = tbx_DienThoai.Text;
                NguoiDungBUS bus = new NguoiDungBUS();
                if(!bus.kiemTraNguoiDung(strTDN, strMK))
                {
                    NguoiDungDTO dto = new NguoiDungDTO(strTDN, strMK, strHT, dtNS, strEmail, strDT, 0);
                    bus.themNguoiDung(dto);
                    //if (bus.kiemTraNguoiDung(strTDN, strMK))
                        MessageBox.Show("Chúc mừng "+strTDN+" đã đăng kí thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc email đã tồn tại. Vui lòng chọn lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }



        

        
    }
}
