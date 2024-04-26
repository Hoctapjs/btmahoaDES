using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class banmo : CD
    {

        string ban_mo_thap_luc_phan;
        string ban_mo_nhi_phan;
        string ban_mo_sau_ip;
        string bientam;
        string r16;
        string l16;
        string khoa_giai_ma;


        public string L16 { get => l16; set => l16 = value; }
        public string R16 { get => r16; set => r16 = value; }
        public string Ban_mo_thap_luc_phan { get => ban_mo_thap_luc_phan; set => ban_mo_thap_luc_phan = value; }
        public string Ban_mo_nhi_phan { get => ban_mo_nhi_phan; set => ban_mo_nhi_phan = value; }
        public string Ban_mo_sau_ip { get => ban_mo_sau_ip; set => ban_mo_sau_ip = value; }
        public string Bientam { get => bientam; set => bientam = value; }
        public string Khoa_giai_ma { get => khoa_giai_ma; set => khoa_giai_ma = value; }

        public int[] IP_1 = new int[] { 40,8,48,16,56,24,64,32,39,7,47,15,55,23,63,31,
                                       38,6,46,14,54,22,62,30,37,5,45,13,53,21,61,29,
                                       36,4,44,12,52,20,60,28,35,3,43,11,51,19,59,27,
                                       34,2,42,10,50,18,58,26,33,1,41,9,49,17,57,25 };



        public banmo()
        {
            Ban_mo_thap_luc_phan = "85E813540F0AB405";
            Ban_mo_nhi_phan = HexToBinary(Ban_mo_thap_luc_phan);
            Ban_mo_sau_ip = hoanvi_lai_theo_IP_1(Ban_mo_nhi_phan);
            Bientam = Ban_mo_sau_ip;
            R16 = Bientam.Substring(0, 32);
            L16 = Bientam.Substring(32, Bientam.Length - 32);
            Khoa_giai_ma = "133457799BBCDFF1";
        }

        public void Xuatbanmo()
        {
            Console.WriteLine("ban mo dang thap luc phan la: " + Ban_mo_thap_luc_phan);
            Console.WriteLine("ban mo dang nhi phan la: " + Ban_mo_nhi_phan);
            Console.WriteLine("ban mo sau ip-1 la: " + Ban_mo_sau_ip);
            Console.WriteLine("R16 la: " + R16);
            Console.WriteLine("L16 la: " + L16);
        }

        public string hoanvi_lai_theo_IP_1(string banmo_truoc_ip)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < IP_1.Length; i++)
            {
                for (int j = 0; j < IP_1.Length; j++)
                {
                    int dem = IP_1[j] - 1;
                    if (dem == i)
                    {
                        char charToAdd = banmo_truoc_ip[j];
                        chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
                    }
                }

            }
            return chuoicanhoanvi;
        }
    }
}
