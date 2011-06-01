using System;
using System.Drawing;
using System.Drawing.Printing;
using DTO;
using BUS;
using System.Windows.Forms;

namespace t3vpaint
{
    public partial class ManHinhChinh : Form
    {
        NguoiDungDTO m_dto;
        DoHoa m_DoHoa;
        int m_iChucNang = 0;
        bool m_bLuuHinh = false;

        public ManHinhChinh()
        {
            InitializeComponent();
            m_dto = new NguoiDungDTO();     
        }

        private void ManHinhChinh_Shown(object sender, EventArgs e)
        {
            ManHinhKhoiDong form = new ManHinhKhoiDong();
            if (form.ShowDialog() == DialogResult.OK)
                this.đăngNhậpToolStripMenuItem_Click(sender, e);
            else
            {
                if (form.DialogResult == DialogResult.Yes)
                    this.đăngKíToolStripMenuItem_Click(sender, e);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            //base.OnClosed(e);
            this.exitToolStripMenuItem_Click(this, e);
            
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.picbox.Visible == true && this.m_bLuuHinh == false)
            {
                DialogResult dr = MessageBox.Show("Hình vẽ chưa được lưu. Bạn có muốn lưu hình trước khi thoát chương trình không?", "Thông báo",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    this.saveToolStripMenuItem_Click(sender, e);
                    this.Dispose();
                }
                else
                    if (dr == DialogResult.No)
                        this.Dispose();

            }
            else
                this.Dispose();
            
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
                DialogResult dr = form.ShowDialog();
                String strTenTapTin = form.FileName;
                if(dr == DialogResult.OK)
                {
                    Image image = new Bitmap(strTenTapTin);
                    Graphics grap = Graphics.FromImage(image);
                    this.m_DoHoa = new DoHoa(grap);
                    this.picbox.Image = image;
                    this.picbox.Visible = true;
                    this.stalabLuuHinh.ForeColor = Color.Blue;
                    this.stalabLuuHinh.Text = "Đã lưu hình " + strTenTapTin;
                    this.stalabLuuHinh.Visible = true;
                }
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
                if (this.m_bLuuHinh == false)
                {
                    if (this.picbox.Image != null)
                    {
                        SaveFileDialog form = new SaveFileDialog();
                        form.Filter = "Bitmap File|*.bmp";
                        DialogResult dr = form.ShowDialog();
                        String strTenTapTin = form.FileName;
                        if (dr == DialogResult.OK)
                        {
                            String strTenLuu = strTenTapTin.Substring(0, strTenTapTin.Length - 4);
                            strTenLuu = strTenLuu + "_" + this.m_dto.TenDangNhap + "_" + (m_dto.SoHinhVe + 1).ToString() + ".bmp";
                            this.picbox.Image.Save(strTenLuu);
                            this.m_bLuuHinh = true;
                            this.m_dto.SoHinhVe++;
                            this.stalabLuuHinh.ForeColor = Color.Blue;
                            this.stalabLuuHinh.Text = "Đã lưu hình " + strTenLuu;
                        }
                    }
                    else
                        MessageBox.Show("Không có hình vẽ để lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    String strTenLuu = this.stalabLuuHinh.Text.Substring(12);
                    this.picbox.Image.Save(strTenLuu);
                }
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
                if (this.picbox.Image != null)
                {
                    PrintDialog form = new PrintDialog();
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        form.Document = new System.Drawing.Printing.PrintDocument();
                        form.Document.PrintPage += new PrintPageEventHandler(this.inHinh);
                        form.Document.Print();
                    }
                }
                else
                    MessageBox.Show("Không có hình để in.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        void inHinh(object o, PrintPageEventArgs e)
        {
            Image image = this.picbox.Image;
            Point p = new Point(0, 0);
            e.Graphics.DrawImage(image, p);
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
                Image image = new Bitmap(this.picbox.Width, this.picbox.Height);
                Graphics grap = Graphics.FromImage(image);
                this.picbox.Image = image;
                this.m_DoHoa = new DoHoa(grap);
                this.picbox.Visible = true;
                this.stalabKichThuoc.Text = "Kích thước hình :  " + picbox.Width.ToString() + " x " +
                    this.picbox.Height.ToString() + "   ";
                this.stalabKichThuoc.Visible = true;
                this.stalabLuuHinh.ForeColor = Color.Red;
                this.stalabLuuHinh.Text = "Hình vẽ chưa được lưu.";
                this.stalabLuuHinh.Visible = true;
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
                    this.picbox.Visible = false;
                    this.stalabKichThuoc.Visible = false;
                    this.stalab_ViTriChuot.Visible = false;
                    this.stalabLuuHinh.Visible = false;
                    this.btn_DangNhap.Enabled = true;
                    this.đăngNhậpToolStripMenuItem.Enabled = true;
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
                this.m_iChucNang = 0;
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
                this.m_DoHoa.taoTay();
                this.m_iChucNang = 1;

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
                this.m_iChucNang = 2;
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
                this.m_iChucNang = 3;
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
                this.m_iChucNang = 4;
            }
        }

        private void btn_TamGiacVuong_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.m_iChucNang = 5;
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
                this.m_iChucNang = 6;
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
                this.m_iChucNang = 7;
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
                this.m_iChucNang = 8;
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



       

      

        private void picbox_SizeChanged(object sender, EventArgs e)
        {
            stalabKichThuoc.Text = "Kích thước hình :  " + picbox.Width.ToString() + " x " +
                    picbox.Height.ToString() + "   ";

            //stalabKichThuoc.Text = "Kích thước hình : " + picbox.Size.ToString();
            //Image image = new Bitmap(this.picbox.Width, this.picbox.Height);
            //image = this.picbox.Image;
            //this.picbox.Image = image;
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
                btn_MauHienTai.BackColor = Color.Black;
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
                btn_MauHienTai.BackColor = Color.White;
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
                btn_MauHienTai.BackColor = Color.Gray;
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
                btn_MauHienTai.BackColor = Color.Red;
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
                btn_MauHienTai.BackColor = Color.Brown;
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
                btn_MauHienTai.BackColor = Color.Orange;
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
                btn_MauHienTai.BackColor = Color.Yellow;
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
                btn_MauHienTai.BackColor = Color.Green;
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
                btn_MauHienTai.BackColor = Color.Blue;
            }
        }

        

        private void cbx_NetVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                switch (this.cbx_NetVe.SelectedIndex)
                {
                    case 1:
                        this.m_DoHoa.doiNetVe(1);
                        break;
                    case 2:
                        this.m_DoHoa.doiNetVe(3);
                        break;
                    case 3:
                        this.m_DoHoa.doiNetVe(5);
                        break;
                    case 4:
                        this.m_DoHoa.doiNetVe(7);
                        break;
                    default:
                        this.m_DoHoa.doiNetVe((float)0.5);
                        break;
                }
            }
        }

        private void cbx_NetVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn không được thay đổi các giá trị ở đây.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void picbox_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            m_DoHoa.M_p1 = p;
            //Point p2 = new Point(p.X + 1, p.Y + 1);
            //m_DoHoa.M_p2 = p2;
            //if (m_iChucNang == 0 || m_iChucNang == 1)
            //    this.m_DoHoa.veDuongThang();
        }

        private void picbox_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            m_DoHoa.M_p2 = p;
            switch (this.m_iChucNang)
            {
                case 4:
                    this.m_DoHoa.veDuongThang();
                    break;
                case 5:
                    this.m_DoHoa.veTamGiacVuong();
                    break;
                case 6:
                    this.m_DoHoa.veTamGiacDeu();
                    break;
                case 7:
                    this.m_DoHoa.veHinhChuNhat();
                    break;
                case 8:
                    this.m_DoHoa.veDuongTron();
                    break;
                case 9:
                    this.m_DoHoa.veHinhThoi();
                    break;
            }
            this.picbox.Refresh();
        }

        private void picbox_MouseMove(object sender, MouseEventArgs e)
        {
            this.stalab_ViTriChuot.Visible = true;
            Point p = e.Location;
            this.stalab_ViTriChuot.Text = "Vị trí chuột : " + p.X.ToString() + " x " + p.Y.ToString();
            //if (m_iChucNang == 0 || m_iChucNang == 1)
            //    this.m_DoHoa.veDuongThang();
           
        }

        private void btn_HinhThoi_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.m_iChucNang = 9;
            }
        }

        private void picbox_MouseLeave(object sender, EventArgs e)
        {
            this.stalab_ViTriChuot.Visible = false;
        }

        private void btn_MauHong_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.m_DoHoa.chonMauButVe(this.btn_MauHong.BackColor);
                this.btn_MauHienTai.BackColor = this.btn_MauHong.BackColor;
            }
        }

        private void btn_MauHongDam_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.m_DoHoa.chonMauButVe(this.btn_MauHongDam.BackColor);
                this.btn_MauHienTai.BackColor = this.btn_MauHongDam.BackColor;
            }
        }

        private void btn_MauTim_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.m_DoHoa.chonMauButVe(this.btn_MauTim.BackColor);
                this.btn_MauHienTai.BackColor = this.btn_MauTim.BackColor;
            }
        }

        private void ManHinhChinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.m_iChucNang == 3)
            {
                this.m_DoHoa.vietChu(e.KeyChar.ToString());
                MessageBox.Show(e.KeyChar.ToString(), "nó nè", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void btn_TaoMoi_Click(object sender, EventArgs e)
        //{
        //    this.newToolStripMenuItem_Click(sender, e);
        //}

        //private void btn_MoHinh_Click(object sender, EventArgs e)
        //{
        //    this.openToolStripMenuItem_Click(sender, e);
        //}

        //private void btn_LuuHinh_Click(object sender, EventArgs e)
        //{
        //    this.saveToolStripMenuItem_Click(sender, e);
        //}

        //private void btn_InHinh_Click(object sender, EventArgs e)
        //{
        //    this.printToolStripMenuItem_Click(sender, e);
        //}

        //private void btn_DangNhap1_Click(object sender, EventArgs e)
        //{

        //}

      
        


        
        

        
    }
}
