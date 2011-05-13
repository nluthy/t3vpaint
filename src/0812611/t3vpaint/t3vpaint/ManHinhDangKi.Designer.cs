namespace t3vpaint
{
    partial class ManHinhDangKi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_TenDangNhap = new System.Windows.Forms.TextBox();
            this.tbx_MatKhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_HoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_Email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_DienThoai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpick = new System.Windows.Forms.DateTimePicker();
            this.btn_DangKi = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập ";
            // 
            // tbx_TenDangNhap
            // 
            this.tbx_TenDangNhap.BackColor = System.Drawing.Color.AliceBlue;
            this.tbx_TenDangNhap.Location = new System.Drawing.Point(136, 20);
            this.tbx_TenDangNhap.Name = "tbx_TenDangNhap";
            this.tbx_TenDangNhap.Size = new System.Drawing.Size(199, 20);
            this.tbx_TenDangNhap.TabIndex = 0;
            this.tbx_TenDangNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_TenDangNhap_KeyPress);
            // 
            // tbx_MatKhau
            // 
            this.tbx_MatKhau.BackColor = System.Drawing.Color.AliceBlue;
            this.tbx_MatKhau.Location = new System.Drawing.Point(136, 56);
            this.tbx_MatKhau.Name = "tbx_MatKhau";
            this.tbx_MatKhau.Size = new System.Drawing.Size(199, 20);
            this.tbx_MatKhau.TabIndex = 1;
            this.tbx_MatKhau.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu           ";
            // 
            // tbx_HoTen
            // 
            this.tbx_HoTen.BackColor = System.Drawing.Color.AliceBlue;
            this.tbx_HoTen.Location = new System.Drawing.Point(136, 93);
            this.tbx_HoTen.Name = "tbx_HoTen";
            this.tbx_HoTen.Size = new System.Drawing.Size(199, 20);
            this.tbx_HoTen.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Họ tên               ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày sinh";
            // 
            // tbx_Email
            // 
            this.tbx_Email.BackColor = System.Drawing.Color.AliceBlue;
            this.tbx_Email.Location = new System.Drawing.Point(136, 163);
            this.tbx_Email.Name = "tbx_Email";
            this.tbx_Email.Size = new System.Drawing.Size(199, 20);
            this.tbx_Email.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email";
            // 
            // tbx_DienThoai
            // 
            this.tbx_DienThoai.BackColor = System.Drawing.Color.AliceBlue;
            this.tbx_DienThoai.Location = new System.Drawing.Point(136, 202);
            this.tbx_DienThoai.Name = "tbx_DienThoai";
            this.tbx_DienThoai.Size = new System.Drawing.Size(199, 20);
            this.tbx_DienThoai.TabIndex = 5;
            this.tbx_DienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_DienThoai_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Điện thoại";
            // 
            // dtpick
            // 
            this.dtpick.CalendarMonthBackground = System.Drawing.Color.AliceBlue;
            this.dtpick.Location = new System.Drawing.Point(135, 126);
            this.dtpick.Name = "dtpick";
            this.dtpick.Size = new System.Drawing.Size(200, 20);
            this.dtpick.TabIndex = 3;
            // 
            // btn_DangKi
            // 
            this.btn_DangKi.BackColor = System.Drawing.SystemColors.Window;
            this.btn_DangKi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DangKi.Image = global::t3vpaint.Properties.Resources.Symbol_Check;
            this.btn_DangKi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DangKi.Location = new System.Drawing.Point(129, 262);
            this.btn_DangKi.Name = "btn_DangKi";
            this.btn_DangKi.Size = new System.Drawing.Size(85, 36);
            this.btn_DangKi.TabIndex = 6;
            this.btn_DangKi.Text = "Đăng kí";
            this.btn_DangKi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_DangKi.UseVisualStyleBackColor = false;
            this.btn_DangKi.Click += new System.EventHandler(this.btn_DangKi_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.BackColor = System.Drawing.SystemColors.Window;
            this.btn_Huy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Huy.Image = global::t3vpaint.Properties.Resources.Symbol_Delete;
            this.btn_Huy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Huy.Location = new System.Drawing.Point(250, 262);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(85, 36);
            this.btn_Huy.TabIndex = 7;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Huy.UseVisualStyleBackColor = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // ManHinhDangKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(373, 314);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_DangKi);
            this.Controls.Add(this.dtpick);
            this.Controls.Add(this.tbx_DienThoai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbx_Email);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_HoTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_MatKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_TenDangNhap);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ManHinhDangKi";
            this.Text = "Đăng kí tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_TenDangNhap;
        private System.Windows.Forms.TextBox tbx_MatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_HoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_Email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_DienThoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpick;
        private System.Windows.Forms.Button btn_DangKi;
        private System.Windows.Forms.Button btn_Huy;
    }
}