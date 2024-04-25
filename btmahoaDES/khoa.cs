using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class khoa
    {
        string khoak;

        public string Khoak { get => khoak; set => khoak = value; }

        public khoa()
        {
            Khoak = "133457799BBCDFF1";
        }

        //public khoa(strin)
        //{
        //    Console.WriteLine("nhap vao khoa k");
        //    Khoak = Console.ReadLine();
        //}

        public void nhapkhoak()
        {
            Console.WriteLine("nhap vao khoa k");
            Khoak = Console.ReadLine();
        }

        // Tạo mảng biểu diễn bảng PC-1 của DES
        public int[] PC1 = new int[]
        {
            57, 49, 41, 33, 25, 17, 9,
            1, 58, 50, 42, 34, 26, 18,
            10, 2, 59, 51, 43, 35, 27,
            19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15,
            7, 62, 54, 46, 38, 30, 22,
            14, 6, 61, 53, 45, 37, 29,
            21, 13, 5, 28, 20, 12, 4
        };

        // Mảng quy tắc dịch bit cho mỗi vòng trong DES
        public int[] DichBit = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        public int[] PC2 = new int[]
        {
            14, 17, 11, 24, 1,  5,
            3,  28, 15, 6,  21, 10,
            23, 19, 12, 4,  26, 8,
            16, 7,  27, 20, 13, 2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32
        };

        int[] kcong = new int[] { };

        public string ChuyenHexSangBinary()
        {
            string hex = Khoak;
            long number = Convert.ToInt64(hex, 16);
            string binary = Convert.ToString(number, 2);
            return binary;
        }

        public string HexToBinary()
        {
            string hex = Khoak;
            string binary = "";

            for (int i = 0; i < hex.Length; i++)
            {
                binary += Convert.ToString(Convert.ToInt32(hex[i].ToString(), 16), 2).PadLeft(4, '0');
            }

            return binary;
        }

        public string HexToBinary(string chuoi)
        {
            string hex = chuoi;
            string binary = "";

            for (int i = 0; i < hex.Length; i++)
            {
                binary += Convert.ToString(Convert.ToInt32(hex[i].ToString(), 16), 2).PadLeft(4, '0');
            }

            return binary;
        }

        public string hoanvitheopc_1(string khoa_bi)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < PC1.Length; i++)
            {
                int dem = PC1[i]-1;
                char charToAdd = khoa_bi[dem];
                chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
            }
            return chuoicanhoanvi;
        }

        public string hoanvitheopc_2(string khoatruocpc2)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < PC2.Length; i++)
            {
                int dem = PC2[i] - 1;
                char charToAdd = khoatruocpc2[dem];
                chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
            }
            return chuoicanhoanvi;
        }

        public string dichbit_taoCiDi(string cd, int thutuvonglap)
        {
            string chuoicanhoanvi = "";
            int sobitdich = DichBit[thutuvonglap-1];
            int i = sobitdich;
            for (int j = 0; i < 28; i++,j++)
            {
                    char charToAdd = cd[i];
                    chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
            }
            for (int z = 0; z < sobitdich; z++)
            {
                char charToAdd = cd[z];
                chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
            }
            return chuoicanhoanvi;
        }









    }
}
