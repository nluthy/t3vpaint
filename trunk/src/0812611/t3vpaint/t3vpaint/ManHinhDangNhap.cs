﻿using System;
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
    public partial class ManHinhDangNhap : Form
    {
        private NguoiDungDTO m_dto;

        public NguoiDungDTO dto
        {
            get { return m_dto; }
            set { m_dto = value; }
        }

        public ManHinhDangNhap()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbx_TenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '@' || e.KeyChar == '-' || e.KeyChar == ' ')
            {
                MessageBox.Show("Tên đăng nhập không được chứa các kí tự đặc biệt: /, *, @, -, .", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

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

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (!kiemTraDoDaiHopLe())
                MessageBox.Show("Bạn mắc 1 trong các lỗi sau:\n - Bạn chưa nhập tên đăng nhập hoặc mật khẩu.\n"
                    + " - Bạn đã nhập tên đăng nhập hoặc mật khẩu dài hơn 10 kí tự.\nVui lòng kiểm tra lại.", "Lỗi",
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
    }
}
