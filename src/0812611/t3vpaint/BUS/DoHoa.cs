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

        public Graphics M_Grap
        {
            get { return m_Grap; }
            set { m_Grap = value; }
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


        public void doiNetVe(float fDoRong)
        {
            this.m_Pen.Width = fDoRong;
        }


        public void toMau()
        {
        }

        public void vietChu(String str)
        {
            RectangleF rectf = new RectangleF(m_p1.X, m_p1.Y, (this.m_p2.X - this.m_p1.X), (this.m_p2.Y - this.m_p1.Y));
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
            Point p1 = new Point((m_p1.X + m_p2.X) / 2, m_p1.Y);
            Point p2 = new Point(m_p1.X, this.m_p2.Y);
            Point[] arrPoint = new Point[4];
            arrPoint[0] = p1;
            arrPoint[1] = m_p2;
            arrPoint[2] = p2;
            arrPoint[3] = p1;
            m_Grap.DrawLines(m_Pen, arrPoint);
        }

        public void veHinhChuNhat()
        {
            Rectangle rect = new Rectangle(m_p1.X, m_p1.Y, (m_p2.X - m_p1.X), (m_p2.Y - m_p1.Y));
            m_Grap.DrawRectangle(m_Pen, rect);
            
        }

        public void veDuongTron()
        {
            Rectangle rect = new Rectangle(m_p1.X, m_p1.Y, (m_p2.X - m_p1.X), (m_p2.Y - m_p1.Y));
            m_Grap.DrawEllipse(m_Pen, rect);
        }

        public void veHinhThoi()
        {
            Point p1 = new Point((m_p1.X + m_p2.X) / 2, m_p1.Y);
            Point p2 = new Point(m_p2.X, (this.m_p1.Y + this.m_p2.Y) / 2);
            Point p3 = new Point((m_p1.X + m_p2.X) / 2, m_p2.Y);
            Point p4 = new Point(m_p1.X, (this.m_p1.Y + this.m_p2.Y) / 2);
            Point[] arrPoint = new Point[5];
            arrPoint[0] = p1;
            arrPoint[1] = p2;
            arrPoint[2] = p3;
            arrPoint[3] = p4;
            arrPoint[4] = p1;
            m_Grap.DrawLines(m_Pen, arrPoint);
        }


        
    }
}
