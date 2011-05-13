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
    public partial class ManHinhChinh : Form
    {
        NguoiDungDTO m_dto = new NguoiDungDTO();

        public ManHinhChinh()
        {
            InitializeComponent();
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox form = new AboutBox();
            form.Show();
        }

        private void đăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManHinhDangKi form = new ManHinhDangKi();
            form.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManHinhDangNhap form = new ManHinhDangNhap();
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Activate();
                m_dto = form.dto;
                m_dto.DangNhap = true;
                stalabDangNhap.ForeColor = Color.Blue;
                String str = "Chào mừng " + m_dto.TenDangNhap + " đã đăng nhập thành công.      ";
                stalabDangNhap.Text = str;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                OpenFileDialog form = new OpenFileDialog();
                form.Filter = "Bitmap File|*.bmp";
                form.ShowDialog();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SaveFileDialog form = new SaveFileDialog();
                form.Filter = "Bitmap File|*.bmp";
                form.ShowDialog();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PrintDialog form = new PrintDialog();
                form.ShowDialog();
            }
        }

        private bool kiemTraDangNhap()
        {
            return m_dto.DangNhap;
        }
        

        
    }
}
