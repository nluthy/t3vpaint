namespace t3vpaint
{
    partial class ManHinhKhoiDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManHinhKhoiDong));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.btn_DangKi = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Để sử dụng chương trình bạn phải đăng nhập.\r\n  - Nếu bạn chưa có tài khoản hãy đă" +
                "ng kí cho mình 1 tài khoản.\r\n  - Nếu bạn đã có tài khoản hãy đăng nhập để bắt đầ" +
                "u sử dụng chương trình.";
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.SystemColors.Window;
            this.btn_DangNhap.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_DangNhap.FlatAppearance.BorderSize = 0;
            this.btn_DangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DangNhap.Image = global::t3vpaint.Properties.Resources.Login;
            this.btn_DangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DangNhap.Location = new System.Drawing.Point(43, 98);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(98, 36);
            this.btn_DangNhap.TabIndex = 3;
            this.btn_DangNhap.Text = "     Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_DangKi
            // 
            this.btn_DangKi.BackColor = System.Drawing.SystemColors.Window;
            this.btn_DangKi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DangKi.Image = global::t3vpaint.Properties.Resources.my_docs_Bagg_s;
            this.btn_DangKi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DangKi.Location = new System.Drawing.Point(168, 98);
            this.btn_DangKi.Name = "btn_DangKi";
            this.btn_DangKi.Size = new System.Drawing.Size(98, 36);
            this.btn_DangKi.TabIndex = 7;
            this.btn_DangKi.Text = "     Đăng kí";
            this.btn_DangKi.UseVisualStyleBackColor = false;
            this.btn_DangKi.Click += new System.EventHandler(this.btn_DangKi_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.BackColor = System.Drawing.SystemColors.Window;
            this.btn_Huy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Huy.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Huy.FlatAppearance.BorderSize = 0;
            this.btn_Huy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Huy.Image = global::t3vpaint.Properties.Resources.Symbol_Stop;
            this.btn_Huy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Huy.Location = new System.Drawing.Point(435, 98);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(98, 36);
            this.btn_Huy.TabIndex = 8;
            this.btn_Huy.Text = "      Hủy";
            this.btn_Huy.UseVisualStyleBackColor = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // ManHinhKhoiDong
            // 
            this.AcceptButton = this.btn_DangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(587, 158);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_DangKi);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManHinhKhoiDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông báo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Button btn_DangKi;
        private System.Windows.Forms.Button btn_Huy;
    }
}