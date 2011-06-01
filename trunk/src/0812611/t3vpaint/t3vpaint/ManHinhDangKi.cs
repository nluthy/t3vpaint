using System;
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
            if ( tbx_TenDangNhap.TextLength >= 50)
            {
                MessageBox.Show("Tên đăng nhập đã đủ 10 kí tự.", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Handled = true;
            }
            if (e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '@' || e.KeyChar == '-' ||e.KeyChar == ' ')
            {
                MessageBox.Show("Tên đăng nhập không được chứa các kí tự đặc biệt: /, *, @, -, .", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void tbx_DienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (tbx_DienThoai.TextLength >= 11)
            {
                MessageBox.Show("Số điện thoại đã đủ 11 kí tự.", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Handled = true;
            }
            if (e.KeyChar < '0' || e.KeyChar > '9' )
            {
             MessageBox.Show("Số điện thoại phải gồm các kí tự số.", "Lỗi", MessageBoxButtons.OK, 
                 MessageBoxIcon.Error);
             e.Handled = true;
            }
         }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private bool kiemTraDoDaiHopLe()
        {
            if (tbx_TenDangNhap.TextLength==0 || tbx_MatKhau.TextLength==0 || tbx_Email.TextLength==0 )
                return false;
            return true;
        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            if (!kiemTraDoDaiHopLe())
                MessageBox.Show("Bạn mắc 1 trong các lỗi sau:\n - Bạn chưa nhập tên đăng nhập.\n"
                    + " - Bạn chưa nhập mật khẩu.\n - Bạn chưa nhập email.\n"
            + "Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tbx_MatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbx_MatKhau.TextLength >= 10)
            {
                MessageBox.Show("Mật khẩu tối đã đủ 10 kí tự.", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void tbx_HoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbx_HoTen.TextLength >= 50)
            {
                MessageBox.Show("Họ tên đã đủ 50 kí tự.", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void tbx_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbx_Email.TextLength >= 50)
            {
                MessageBox.Show("Email đã đủ 50 kí tự.", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Handled = true;
            }
        }



        

        
    }
}
