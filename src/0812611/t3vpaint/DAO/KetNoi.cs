using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace DAO
{
    public class KetNoi
    {
        private static OleDbConnection m_connKetNoi;

        #region Properties

        public static OleDbConnection connKetNoi
        {
            get { return m_connKetNoi; }
            set { m_connKetNoi = value; }
        }

        #endregion

        #region Dong mo ket noi

        public static void moKetNoi()
        {
            String strChuoiKetNoi = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Database.mdb";
            try
            {
                m_connKetNoi = new OleDbConnection(strChuoiKetNoi);
                m_connKetNoi.Open();
            }
            catch(Exception ex)
            {
                
            }
        }

        public static void dongKetNoi()
        {
            if(m_connKetNoi != null)
            {
                m_connKetNoi.Close();
                m_connKetNoi = null;
            }
        }

        #endregion 

        #region Xu li 

        public static DataTable thucThiTruyVan(String strQuery)
        {
            moKetNoi();
            DataTable dt = new DataTable();
            OleDbCommand oc = new OleDbCommand(strQuery, m_connKetNoi);
            OleDbDataAdapter oda = new OleDbDataAdapter(oc) ;
            oda.Fill(dt);
            dongKetNoi();
            return dt;
        }

        public static void thucThiPhiTruyVan(String strNonquery)
        {
            moKetNoi();
            OleDbCommand oc = new OleDbCommand(strNonquery, m_connKetNoi);
            oc.ExecuteNonQuery();
            dongKetNoi();
        }

        #endregion
    }
}
