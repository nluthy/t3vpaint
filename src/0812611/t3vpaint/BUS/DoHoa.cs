using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
        List<Point> m_arrPoint;

        public DoHoa()
        {
            m_Pen = new Pen(Color.Black, 1);
            m_Brush = new SolidBrush(Color.Black);
            m_Font = new Font("Tahoma", 14);
            m_arrPoint = new List<Point>();
        }

        #region Properties
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

        public List<Point> M_arrPoint
        {
            get { return m_arrPoint; }
            set {m_arrPoint = value;}
        }
        #endregion

        #region Chon mau ve, net ve, xu li khac
        public void taoTay()
        {
            m_Pen.Color = Color.White;
            m_Pen.Width = 10;
        }

        public void chonMauButVe(Color col)
        {
            m_Pen.Color = col;
            m_Brush.Color = col;
        }


        public void doiNetVe(float fDoRong)
        {
            this.m_Pen.Width = fDoRong;
        }
        #endregion

        #region Cac ham xu li ve
        public void toMau()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void vietChu(String str)
        {
            try
            {
                RectangleF rectf = new RectangleF(m_p1.X, m_p1.Y, (this.m_p2.X - this.m_p1.X), (this.m_p2.Y - this.m_p1.Y));
                m_Grap.DrawString(str, m_Font, m_Brush, rectf);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void veDuongThang()
        {
            try
            {
                m_Grap.DrawLine(m_Pen, m_p1, m_p2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        public void veTamGiacVuong()
        {
            try
            {
                Point p = new Point(this.m_p1.X, this.m_p2.Y);
                Point[] arrPoint = new Point[4];
                arrPoint[0] = this.m_p1;
                arrPoint[1] = this.m_p2;
                arrPoint[2] = p;
                arrPoint[3] = this.m_p1;
                //this.arrPoint.Add(this.m_p1);
                //this.arrPoint.Add(this.m_p2);
                //this.arrPoint.Add(p);
                //this.arrPoint.Add(this.m_p1);

                this.m_Grap.DrawLines(this.m_Pen, arrPoint);
                //m_Grap.DrawPolygon(this.m_Pen, arrPoint);
 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void veTamGiacDeu()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void veHinhChuNhat()
        {
            try
            {
                Rectangle rect = new Rectangle(m_p1.X, m_p1.Y, (m_p2.X - m_p1.X), (m_p2.Y - m_p1.Y));
                m_Grap.DrawRectangle(m_Pen, rect);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void veDuongTron()
        {
            try
            {
                Rectangle rect = new Rectangle(m_p1.X, m_p1.Y, (m_p2.X - m_p1.X), (m_p2.Y - m_p1.Y));
                m_Grap.DrawEllipse(m_Pen, rect);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void veHinhThoi()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void veTuDo()
        {
            try
            {
                Point[] arrPoint = new Point[this.m_arrPoint.Count];
                for (int index = 0; index < this.m_arrPoint.Count; ++index)
                    arrPoint[index] = this.m_arrPoint[index];
                this.m_Grap.DrawLines(this.m_Pen, arrPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong khi vẽ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           // this.m_arrPoint.Clear();
        }
        #endregion



    }
}
