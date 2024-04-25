using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class banmo : CD
    {

        string m_thap_luc_phan;
        string m_nhi_phan;
        string m_sau_ip;
        string l0;
        string r0;

        public string M_Thap_luc_phan { get => m_thap_luc_phan; set => m_thap_luc_phan = value; }
        public string M_Nhi_phan { get => m_nhi_phan; set => m_nhi_phan = value; }
        public string M_Sau_ip { get => m_sau_ip; set => m_sau_ip = value; }
        public string L0 { get => l0; set => l0 = value; }
        public string R0 { get => r0; set => r0 = value; }

        public int[] IP_1 = new int[] { 40,8,48,16,56,24,64,32,39,7,47,15,55,23,63,31,
                                       38,6,46,14,54,22,62,30,37,5,45,13,53,21,61,29,
                                       36,4,44,12,52,20,60,28,35,3,43,11,51,19,59,27,
                                       34,2,42,10,50,18,58,26,33,1,41,9,49,17,57,25 };



        public banmo()
        {
                M_Thap_luc_phan = "0123456789ABCDEF";
                M_Nhi_phan = HexToBinary(M_Thap_luc_phan);
                M_Sau_ip = hoanvi_lai_theo_IP_1(M_Nhi_phan);
                L0 = M_Sau_ip.Substring(0, 32);
                R0 = M_Sau_ip.Substring(32, M_Sau_ip.Length - 32);
        }

        public string hoanvi_lai_theo_IP_1(string R16L16)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < IP_1.Length; i++)
            {
                int dem = IP_1[i] - 1;
                char charToAdd = R16L16[dem];
                chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
            }
            return chuoicanhoanvi;
        }
    }
}
