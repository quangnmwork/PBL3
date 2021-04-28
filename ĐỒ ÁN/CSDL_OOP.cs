using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CSDL_OOP();
                return _Instance;
            }
            private set { }
        }
        private CSDL_OOP() { }
        public KHU GetKhu(DataRow i)
        {
            return new KHU
            {
                IdKhu = i["IdKhu"].ToString(),
                TenKhu = i["TenKhu"].ToString()
            };
        }
        public List<KHU> GetAllKhu()
        {
            string Query = "select * from KHU";
            List<KHU> data = new List<KHU>();
            foreach (DataRow i in DBHelper.Instance.GetRecord(Query).Rows)
            {
                data.Add(GetKhu(i));
            }
            return data;
        }
        public PHONGHOC GetPhongHoc(DataRow i)
        {
            return new PHONGHOC
            {
                IdPhong = i["IdPhong"].ToString(),
                IdKhu = i["IdKhu"].ToString(),
                STTPH = Convert.ToInt32(i["STTPH"].ToString()),
                X = Convert.ToInt32(i["X"].ToString()),
                Y = Convert.ToInt32(i["Y"].ToString()),
                Z = Convert.ToInt32(i["Z"].ToString()),
            };
        }
        public List<PHONGHOC> GetAllPhongHoc()
        {
            string Query = "select * from PHONGHOC";
            List<PHONGHOC> data = new List<PHONGHOC>();
            foreach (DataRow i in DBHelper.Instance.GetRecord(Query).Rows)
            {
                data.Add(GetPhongHoc(i));
            }
            return data;
        }
        public CAUTHANG GetCauThang(DataRow i)
        {
            return new CAUTHANG
            {
                IdCauThang = i["IdCauThang"].ToString(),
                IdKhu = i["IdKhu"].ToString(),
                STTCT = Convert.ToInt32(i["STTCT"].ToString()),
                X = Convert.ToInt32(i["X"].ToString()),
                Y = Convert.ToInt32(i["Y"].ToString()),
                Z = Convert.ToInt32(i["Z"].ToString()),
            };
        }
        public List<CAUTHANG> GetAllCauThang()
        {
            string Query = "select * from CauThang";
            List<CAUTHANG> data = new List<CAUTHANG>();
            foreach (DataRow i in DBHelper.Instance.GetRecord(Query).Rows)
            {
                data.Add(GetCauThang(i));
            }
            return data;
        }
        public Node ConverNodeFromPhongHoc(int Id, PHONGHOC i)
        {
            return new Node()
            {
                IdNode = Id,
                STT = i.STTPH,
                name = i.IdPhong,
                x = i.X,
                y = i.Y,
                z = i.Z,
                visited = false,
                edges = new List<Edge>()
            };
        }
        public Node ConverNodeFromCauThang(int Id, CAUTHANG i)
        {
            return new Node()
            {
                IdNode = Id,
                STT = i.STTCT,
                name = i.IdCauThang,
                x = i.X,
                y = i.Y,
                z = i.Z,
                visited = false,
                edges = new List<Edge>()
            };
        }
        public List<string> GetNameKhu()
        {
            List<string> data = new List<string>();
            foreach (KHU i in GetAllKhu())
                data.Add(i.TenKhu);
            return data;
        }
    }
}
