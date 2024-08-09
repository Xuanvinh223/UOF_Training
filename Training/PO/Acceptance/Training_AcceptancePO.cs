using System;
using System.Data;


namespace Training.Acceptance.PO
{
    internal class Training_AcceptancePO :Ede.Uof.Utility.Data.BasePersistentObject
    {
        internal DataTable GetData(string RKNO)
        {

            string connStr = Training.Properties.Settings.Default.LYV_ERP.ToString();
            this.m_db = new Ede.Uof.Utility.Data.DatabaseHelper(connStr);
            string cmdTxt = @"SELECT ROW_NUMBER() OVER(ORDER BY KCRKS.CLBH) AS Seq, KCRKS.CLBH, CLZL.YWPM, CLZL.DWBH,
                                CONVERT(float, KCRKS.Qty)as Qty, CONVERT(float,isnull(KCRKS.USPrice, KCRKS.VNPrice ) ) as USPrice, CONVERT(float,isnull(KCRKS.USACC, KCRKS.VNACC )) USACC , KCRK.ZSNO, ZSZL.ZSYWJC, KCRKS.RKNO FROM KCRKS 
                                LEFT JOIN KCRK ON KCRK.RKNO = KCRKS.RKNO
                                LEFT JOIN CLZL ON CLZL.CLDH = KCRKS.CLBH 
                                LEFT JOIN ZSZL ON KCRK.ZSBH = ZSZL.ZSDH
                                WHERE KCRKS.RKNO = @RKNO";

            this.m_db.AddParameter("@RKNO", RKNO);

            DataTable dt = new DataTable();

            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;

        }
    }
}
