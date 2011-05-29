using System;
using System.Drawing;
using DTO;
using BUS;
using System.Windows.Forms;

namespace t3vpaint
{
    public partial class ManHinhChinh : Form
    {
        NguoiDungDTO m_dto;
        DoHoa m_DoHoa;

        public ManHinhChinh()
        {
            InitializeComponent();
            m_dto = new NguoiDungDTO();
            m_DoHoa = new DoHoa(this.picbox.CreateGraphics());
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
                this.đăngNhậpToolStripMenuItem.Enabled = false;
                this.btn_DangNhap.Enabled = false;
                MessageBox.Show("Bạn đã đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                picbox.Visible = true;
                stalabKichThuoc.Text = "Kích thước hình :  " + picbox.Height.ToString() + " " + "x" + " " +
                    picbox.Width.ToString();
                stalabKichThuoc.Visible = true;
                stalabLuuHinh.Visible = true;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult dr = MessageBox.Show("Nếu đăng xuất bạn sẽ không thể tiếp tục sử dụng các chức năng của chương trình.\n"
                    + "Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    m_dto = new NguoiDungDTO();
                    MessageBox.Show("Bạn đã đăng xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stalabDangNhap.ForeColor = Color.Red;
                    stalabDangNhap.Text = "Bạn chưa đăng nhập.";
                }
            }
        }

        private void btn_ButVe_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
            }
        }

        private void btn_Tay_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.taoTay();
            }
        }

        private void btn_ToMau_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
            }
        }

        private void btn_VietChu_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
            }
        }

        private void btn_DuongThang_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.veDuongThang();
            }
        }

        private void btn_DuongCong_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
            }
        }

        private void btn_TamGiac_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
            }
        }

        private void btn_ChuNhat_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
            }
        }

        private void btn_DuongTron_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
            }
        }

        private void btn_Elip_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
            }
        }

        private void btn_TaoTrangVe_Click(object sender, EventArgs e)
        {
            this.newToolStripMenuItem_Click(sender, e);
        }

        private void btn_MoHinhVe_Click(object sender, EventArgs e)
        {
            this.openToolStripMenuItem_Click(sender, e);
        }

        private void btn_LuuHinhVe_Click(object sender, EventArgs e)
        {
            this.saveToolStripMenuItem_Click(sender, e);
        }

        private void btn_InHinhVe_Click(object sender, EventArgs e)
        {
            this.printToolStripMenuItem_Click(sender, e);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này chưa được xây dựng hoàn chỉnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            this.đăngNhậpToolStripMenuItem_Click(sender, e);
        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            this.đăngKíToolStripMenuItem_Click(sender, e);
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            this.đăngXuấtToolStripMenuItem_Click(sender, e);
        }



        private void TestGraphic()
        {
            Pen pen = new Pen(Color.Red);
            pen.Width = 5;
            Graphics grap = this.picbox.CreateGraphics();
            grap.DrawLine(pen, 0, 0, 100, 100);
        }

        private Point LayViTriChuot()
        {
            Point KetQua = MousePosition;
            KetQua.X += 183;
            KetQua.Y += 51;
            return KetQua;
        }

        private void picbox_SizeChanged(object sender, EventArgs e)
        {
            stalabKichThuoc.Text = "Kích thước hình :  " + picbox.Height.ToString() + " " + "x" + " " +
                    picbox.Width.ToString();
        }

        private void btn_MauDen_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.Black);
            }
        }

        private void btn_MauTrang_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.White);
            }
        }

        private void btn_MauXam_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.Gray);
            }
        }

        private void btn_MauDo_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.Red);
            }
        }

        private void btn_MauNau_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.Brown);
            }
        }

        private void btn_MauCam_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.Orange);
            }
        }

        private void btn_MauVang_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.Yellow);
            }
        }

        private void btn_MauLuc_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.Green);
            }
        }

        private void btn_MauLam_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m_DoHoa.chonMauButVe(Color.Blue);
            }
        }

        private void ManHinhChinh_MouseDown(object sender, MouseEventArgs e)
        {
            Point p1 = MousePosition;
            p1.X += 183;
            p1.Y += 51;
            m_DoHoa.M_p1 = p1;
            
        }

        private void ManHinhChinh_MouseUp(object sender, MouseEventArgs e)
        {
            Point p1 = MousePosition;
            p1.X += 183;
            p1.Y += 51;
            m_DoHoa.M_p2 = p1;
        }

        


        
        

        
    }
}
