using System;
using DTO;
using BUS;
using System.Windows.Forms;

namespace t3vpaint
{
    public partial class ManHinhDangNhap : Form
    {
        private NguoiDungDTO m_dto;

        public ManHinhDangNhap()
        {
            InitializeComponent();
        }

        #region Properties

        public NguoiDungDTO dto
        {
            get { return m_dto; }
            set { m_dto = value; }
        }
        #endregion

        #region Xu li su kien tren cac textbox

        private void tbx_TenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbx_TenDangNhap.TextLength >= 50)
            {
                MessageBox.Show("Tên đăng nhập đã đủ 10 kí tự.", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Handled = true;
            }
            if (e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '@' || e.KeyChar == '-' || e.KeyChar == ' ')
            {
                MessageBox.Show("Tên đăng nhập không được chứa các kí tự đặc biệt: /, *, @, -, .", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void tbx_MatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbx_MatKhau.TextLength >= 10)
            {
                MessageBox.Show("Mật khẩu tối đã đủ 10 kí tự.", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        #endregion

        #region Cac ham xu li khac

        private bool kiemTraDoDaiHopLe()
        {
            if (tbx_TenDangNhap.TextLength == 0 || tbx_MatKhau.TextLength == 0 || tbx_TenDangNhap.TextLength > 10 
                || tbx_MatKhau.TextLength > 10 )
                return false;
            return true;
        }

        private bool kiemTraTenDangNhap()
        {
            NguoiDungBUS bus = new NguoiDungBUS();
            return (bus.kiemTraNguoiDung(tbx_TenDangNhap.Text, ""));
        }

        private bool kiemTraMatKhau()
        {
            NguoiDungBUS bus = new NguoiDungBUS();
            return (bus.kiemTraMatKhau(tbx_TenDangNhap.Text, tbx_MatKhau.Text));
        }

        #endregion

        #region Xu li 2 button Dang nhap va huy

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (!kiemTraDoDaiHopLe())
                MessageBox.Show("Bạn chưa nhập tên đăng nhập hoặc mật khẩu.\n"
                    + "Vui lòng kiểm tra lại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!kiemTraTenDangNhap())
                    MessageBox.Show("Tên đăng nhập không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (!kiemTraMatKhau())
                        MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        NguoiDungBUS bus = new NguoiDungBUS();
                        dto = bus.layThongTinNguoiDung(tbx_TenDangNhap.Text, tbx_MatKhau.Text);
                        DialogResult = DialogResult.OK;
                    }
                }

            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        
    }
}
