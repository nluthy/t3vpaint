using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace BUS
{
    public class DoHoa
    {
        Pen m_Pen;
        SolidBrush m_Brush;
        Graphics m_Grap;
        Font m_Font;
        Point m_p1;
        Point m_p2;

        public Point M_p1
        {
            get { return m_p1; }
            set { m_p1 = value; }
        }

        public Point M_p2
        {
            get { return m_p2; }
            set { m_p2 = value; }
        }

        public DoHoa(Graphics grap)
        {
            m_Pen = new Pen(Color.Black, 1);
            m_Brush = new SolidBrush(Color.Black);
            m_Grap = grap;
            m_Font = new Font("Tahoma", 14);
        }



        public void taoTay()
        {
            m_Pen.Color = Color.White;
            m_Pen.Width = 10;
        }

        public void chonMauButVe(Color col)
        {
            m_Pen.Color = col;
        }

        public void chonNetVe(float fNet)
        {
            m_Pen.Width = fNet;
        }

        public void toMau()
        {
        }

        public void vietChu(String str, RectangleF rectf)
        {
            m_Grap.DrawString(str, m_Font, m_Brush, rectf);
        }



        public void veDuongThang()
        {
            m_Grap.DrawLine(m_Pen, m_p1, m_p2);
        }

        public void veDuongCong()
        {
        }


        public void veTamGiac()
        {
        }

        public void veHinhChuNhat(Rectangle rect)
        {
            m_Grap.DrawRectangle(m_Pen, rect);
        }

        public void veDuongTron(Rectangle rect)
        {
            m_Grap.DrawEllipse(m_Pen, rect);
        }

        public void veHinhThoi(Point[] arrPoint)
        {
            m_Grap.DrawCurve(m_Pen, arrPoint);
        }
    }
}
