using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace t3vpaint
{
    public partial class ManHinhKhoiDong : Form
    {
        public ManHinhKhoiDong()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;   
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
