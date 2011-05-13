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
    public partial class ManHinhChinh : Form
    {
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
            form.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog form = new OpenFileDialog();
            form.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog form = new SaveFileDialog();
            form.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog form = new PrintDialog();
            form.ShowDialog();
        }

        

        
    }
}
