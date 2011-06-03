using System;
using System.Drawing;
using System.Drawing.Printing;
using DTO;
using BUS;
using System.Windows.Forms;



// Vẽ tự do
// Xử lý khi new thì hỏi save cái cũ chưa lưu
// Text
// Tô màu
// Doc: giao diện chính, sơ đồ lớp
//  Kiện điểm XDPM
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
            m_DoHoa = new DoHoa();
        }

        #region Xu li cac su kien cua form Man hinh chinh

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

        private void ManHinhChinh_FormClosing(object sender, FormClosingEventArgs e)
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
                    {
                        this.Dispose();
                    }
                    else
                        e.Cancel = true;
            }
            else
                this.Dispose();
        }

        #endregion

        #region Xu li Menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == true && this.m_bLuuHinh == false)
                {
                    DialogResult dr = MessageBox.Show("Hình vẽ chưa được lưu. Bạn có muốn lưu hình trước khi tạo trang vẽ mới không?", "Thông báo",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.saveToolStripMenuItem_Click(sender, e);
                        this.taoTrangVeMoi();
                    }
                    else
                        if (dr == DialogResult.No)
                        {
                            this.taoTrangVeMoi();
                        }
                }
                else
                    this.taoTrangVeMoi();

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                OpenFileDialog form = new OpenFileDialog();
                form.Filter = "Bitmap File|*.bmp";
                DialogResult dr = form.ShowDialog();
                String strTenTapTin = form.FileName;
                if (dr == DialogResult.OK)
                {
                    Image image = new Bitmap(strTenTapTin);
                    Graphics grap = Graphics.FromImage(image);
                    this.m_DoHoa.M_Grap = grap;
                    this.picbox.Image = image;
                    this.picbox.Visible = true;
                    this.stalabLuuHinh.ForeColor = Color.Blue;
                    this.stalabLuuHinh.Text = "Đã lưu hình " + strTenTapTin;
                    this.stalabLuuHinh.Visible = true;
                    this.Text = "t3vpaint - " + strTenTapTin;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
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
                            this.stalabLuuHinh.Text = "Đã lưu hình.";
                            this.Text = "t3vpaint - " + strTenLuu;
                        }
                    }
                    else
                        MessageBox.Show("Không có hình vẽ để lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    String strTenLuu = this.Text.Substring(11);
                    this.picbox.Image.Save(strTenLuu);
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
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
                    {
                        this.Dispose();
                    }
            }
            else
                this.Dispose();

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

        private void đăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManHinhDangKi form = new ManHinhDangKi();
            form.Show();

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
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

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.thongBaoChuaHoanChinh();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox form = new AboutBox();
            form.Show();
        }

        #endregion

        #region Cac ham xu li khac

        private void inHinh(object o, PrintPageEventArgs e)
        {
            Image image = this.picbox.Image;
            Point p = new Point(0, 0);
            e.Graphics.DrawImage(image, p);
        }

        private bool kiemTraDangNhap()
        {
            return m_dto.DangNhap;
        }

        private void taoTrangVeMoi()
        {
            Image image = new Bitmap(this.picbox.Width, this.picbox.Height);
            Graphics grap = Graphics.FromImage(image);
            this.picbox.Image = image;
            this.m_DoHoa.M_Grap = grap;
            this.picbox.Visible = true;
            this.stalabKichThuoc.Text = "Kích thước hình :  " + picbox.Width.ToString() + " x " +
                this.picbox.Height.ToString() + "   ";
            this.stalabKichThuoc.Visible = true;
            this.stalabLuuHinh.ForeColor = Color.Red;
            this.stalabLuuHinh.Text = "Hình vẽ chưa được lưu.";
            this.stalabLuuHinh.Visible = true;
            this.m_bLuuHinh = false;
        }

        #endregion        

        #region Cac Thong Bao
        private void thongBaoChuaDangNhap()
        {
            MessageBox.Show(" - Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng chương trình.\n "
                    + "- Nếu bạn chưa có tài khoản, hãy đăng kí 1 tài khoản ở Menu 'Người dùng'.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void thongBaoTaoTrangVe()
        {
            MessageBox.Show("Không có trang vẽ để thao tác.\nVui lòng tạo trang vẽ mới hoặc mở 1 hình vẽ để bắt đầu thao tác.\n "
                    , "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void thongBaoChuaHoanChinh()
        {
            MessageBox.Show("Chức năng này chưa được xây dựng hoàn chỉnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Xu li cac button Cong cu
        private void btn_ButVe_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 0;
                }
            }
        }

        private void btn_Tay_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_DoHoa.taoTay();
                    this.m_iChucNang = 1;
                }

            }
        }

        private void btn_ToMau_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 2;
                    this.thongBaoChuaHoanChinh();
                }
            }
        }

        private void btn_VietChu_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 3;
                    thongBaoChuaHoanChinh();
                }
            }
        }

        #endregion

        #region Xu li cac button ve hinh co ban
        private void btn_DuongThang_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 4;
                }
            }
        }

        private void btn_TamGiacVuong_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 5;
                }
            }
        }

        private void btn_TamGiac_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 6;
                }
            }
        }

        private void btn_ChuNhat_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 7;
                }
            }
        }

        private void btn_DuongTron_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 8;
                }
            }
        }

        private void btn_HinhThoi_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                if (this.picbox.Visible == false)
                    this.thongBaoTaoTrangVe();
                else
                {
                    this.m_iChucNang = 9;
                }
            }
        }

        #endregion

        #region Xu li Toolbar

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

        #endregion

        #region Xu li cac button chon mau ve
        private void btn_MauDen_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.Black);
                this.label_MauHienTai.ForeColor = this.btn_MauDen.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauDen.BackColor;
            }
        }

        private void btn_MauTrang_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.White);
                this.label_MauHienTai.ForeColor = this.btn_MauTrang.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauTrang.BackColor;
            }
        }

        private void btn_MauXam_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.Gray);
                this.label_MauHienTai.ForeColor = this.btn_MauXam.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauXam.BackColor;
            }
        }

        private void btn_MauDo_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.Red);
                this.label_MauHienTai.ForeColor = this.btn_MauDo.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauDo.BackColor;
            }
        }

        private void btn_MauNau_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.Brown);
                this.label_MauHienTai.ForeColor = this.btn_MauNau.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauNau.BackColor;
            }
        }

        private void btn_MauCam_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.Orange);
                this.label_MauHienTai.ForeColor = this.btn_MauCam.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauCam.BackColor;
            }
        }

        private void btn_MauVang_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.Yellow);
                this.label_MauHienTai.ForeColor = this.btn_MauVang.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauVang.BackColor;
            }
        }

        private void btn_MauLuc_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.Green);
                this.label_MauHienTai.ForeColor = this.btn_MauLuc.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauLuc.BackColor;
            }
        }

        private void btn_MauLam_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                m_DoHoa.chonMauButVe(Color.Blue);
                this.label_MauHienTai.ForeColor = this.btn_MauLam.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauLam.BackColor;
            }
        }

        private void btn_MauHong_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                this.m_DoHoa.chonMauButVe(this.btn_MauHong.BackColor);
                this.label_MauHienTai.ForeColor = this.btn_MauHong.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauHong.BackColor;
            }
        }

        private void btn_MauHongDam_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                this.m_DoHoa.chonMauButVe(this.btn_MauHongDam.BackColor);
                this.label_MauHienTai.ForeColor = this.btn_MauHongDam.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauHongDam.BackColor;
            }
        }

        private void btn_MauTim_Click(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
            else
            {
                this.m_DoHoa.chonMauButVe(this.btn_MauTim.BackColor);
                this.label_MauHienTai.ForeColor = this.btn_MauTim.BackColor;
                this.label_MauHienTai.BackColor = this.btn_MauTim.BackColor;
            }
        }

        #endregion

        #region Xu li combobox chon net ve
        private void cbx_NetVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!kiemTraDangNhap())
                thongBaoChuaDangNhap();
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

        #endregion

        #region Xu li picturebox

        private void picbox_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            m_DoHoa.M_p1 = p;
            this.m_DoHoa.M_arrPoint.Add(p);
        }

        private void picbox_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            m_DoHoa.M_p2 = p;
            switch (this.m_iChucNang)
            {
                case 0:
                case 1:
                    this.m_DoHoa.M_arrPoint.Add(p);
                    this.m_DoHoa.veTuDo();
                    this.m_DoHoa.M_arrPoint.Clear();
                    break;
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
            if ((this.m_iChucNang == 0 || this.m_iChucNang == 1) && e.Button == MouseButtons.Left)
            {
                this.m_DoHoa.M_arrPoint.Add(p);
                this.m_DoHoa.veTuDo();
            }
        }

        private void picbox_SizeChanged(object sender, EventArgs e)
        {
            stalabKichThuoc.Text = "Kích thước hình :  " + picbox.Width.ToString() + " x " +
                    picbox.Height.ToString() + "   ";
        }
        

        private void picbox_MouseLeave(object sender, EventArgs e)
        {
            this.stalab_ViTriChuot.Visible = false;
        }

        #endregion

        

        

       
      
        


        
        

        
    }
}
