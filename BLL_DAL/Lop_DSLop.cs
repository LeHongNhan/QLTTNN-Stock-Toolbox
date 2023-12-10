using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class Lop_DSLop
    {
        public int maLop;
        string tenLop;
        public Lop_DSLop(int MaLop) 
        {
            SQLHelper h = new SQLHelper();
            DbDataReader dr = h.getDataReader("Select LopID, TenLop from Lop where LopID = '" + MaLop + "'");
            while (dr.Read())
            {
                maLop = dr.GetInt32(0);
                tenLop = dr.GetString(1);
            }
            dr.Close();
            h.close();
        }
        public Lop_DSLop(int maLop, string tenLop)
        {
            this.maLop = maLop;
            this.tenLop = tenLop;
        }
        public override string ToString()
        {
            return maLop + "";
        }
    }
}
