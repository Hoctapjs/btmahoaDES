using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class vanban : CD
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

        public int[] IP = new int[] { 58,50,42,34,26,18,10,2,60,52,44,36,28,20,12,4,
                                       62,54,46,38,30,22,14,6,64,56,48,40,32,24,16,8,
                                       57,49,41,33,25,17,9,1,59,51,43,35,27,19,11,3,
                                       61,53,45,37,29,21,13,5,63,55,47,39,31,23,15,7 };

        public vanban()
        {
            M_Thap_luc_phan = "0123456789ABCDEF";
            M_Nhi_phan = HexToBinary(M_Thap_luc_phan);
            M_Sau_ip = hoanvitheo_IP(M_Nhi_phan);
            L0 = M_Sau_ip.Substring(0, 32);
            R0 = M_Sau_ip.Substring(32, M_Sau_ip.Length - 32);
        }

        public void xuatbanroM()
        {
            Console.WriteLine("dang thap luc phan cua M: " + M_Thap_luc_phan);
            Console.WriteLine("dang nhi phan cua M: " + M_Nhi_phan);
            Console.WriteLine("M sau khi di qua bang hoan vi dau vao IP: " + M_Sau_ip);
            Console.WriteLine("L0 la: " + L0);
            Console.WriteLine("R0 la: " + R0);
        }

        public string hoanvitheo_IP(string mnhiphan)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < IP.Length; i++)
            {
                int dem = IP[i] - 1;
                char charToAdd = mnhiphan[dem];
                chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
            }
            return chuoicanhoanvi;
        }

    }
}
