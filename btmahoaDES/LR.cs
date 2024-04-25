using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class LR : vanban
    {
        string l;
        string r;
        string eofR;
        string kxorE;
        public LR()
        {

        }

        public string L { get => l; set => l = value; }
        public string R { get => r; set => r = value; }
        public string EofR { get => eofR; set => eofR = value; }
        public string KxorE { get => kxorE; set => kxorE = value; }

        public string[] B = new string[] { "0", "0", "0", "0", "0", "0", "0", "0" };

        public string[] SBtp = new string[] { "0", "0", "0", "0", "0", "0", "0", "0" };




        public int[] E = new int[] { 32,1,2,3,4,5,4,5,6,7,8,9,
                                     8,9,10,11,12,13,12,13,14,15,16,17,
                                     16,17,18,19,20,21,20,21,22,23,24,25,
                                     24,25,26,27,28,29,28,29,30,31,32,1 };

        //public int[] S1 = new int[]          { 14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7,
        //                                        0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8,
        //                                        4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0,
        //                                        15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13 };

        //public int[] S2 = new int[]          { 15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10,
        //                                        3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5,
        //                                        0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15,
        //                                        13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9 };

        //public int[] S3 = new int[]          { 10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8,
        //                                        13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1,
        //                                        13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7,
        //                                        1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12 };

        //public int[] S4 = new int[]          { 7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15,
        //                                        13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9,
        //                                        10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4,
        //                                        3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14 };

        //public int[] S5 = new int[]          { 2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9,14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6,4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14,11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3 };

        //public int[] S6 = new int[]          { 12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11,
        //                                        10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8,
        //                                        9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6,
        //                                        4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13 };

        //public int[] S7 = new int[]          { 4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1,
        //                                        13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6,
        //                                        1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2,
        //                                        6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12 };

        //public int[] S8 = new int[]          { 13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7,
        //                                        1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2,
        //                                        7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8,
        //                                        2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11 };

        public int[][] SArrays = new int[][]
        {
        new int[] { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7, 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8, 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0, 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 },
        new int[] { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10, 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5, 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15, 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 },
        new int[] { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8, 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1, 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7, 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 },
        new int[] { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15, 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9, 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4, 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 },
        new int[] { 2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9,14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6,4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14,11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3 },
        new int[] { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11, 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8, 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6, 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 },
        new int[] { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1, 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6, 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2, 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 },
        new int[] { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7, 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2, 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8, 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }
        };

        public int[] P = new int[] { 16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10, 2, 8, 24, 14, 32, 27, 3, 9, 19, 13, 30, 6, 22, 11, 4, 25 };

        private int[] IP_1 = new int[] { 40,8,48,16,56,24,64,32,39,7,47,15,55,23,63,31,
                                       38,6,46,14,54,22,62,30,37,5,45,13,53,21,61,29,
                                       36,4,44,12,52,20,60,28,35,3,43,11,51,19,59,27,
                                       34,2,42,10,50,18,58,26,33,1,41,9,49,17,57,25 };




        public string hoanvitheo_E(string rnhiphan)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < E.Length; i++)
            {
                int dem = E[i] - 1;
                char charToAdd = rnhiphan[dem];
                chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
            }
            return chuoicanhoanvi;
        }

        public string XorE(string ki, string eofr)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < E.Length; i++)
            {
                if (ki[i] == eofr[i])
                {
                    char charToAdd = '0';
                    chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
                }
                if (ki[i] != eofr[i])
                {
                    char charToAdd = '1';
                    chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
                }
            }
            return chuoicanhoanvi;
        }

        public string XorP(string li, string p_of_F_func)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < P.Length; i++)
            {
                if (li[i] == p_of_F_func[i])
                {
                    char charToAdd = '0';
                    chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
                }
                if (li[i] != p_of_F_func[i])
                {
                    char charToAdd = '1';
                    chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
                }
            }
            return chuoicanhoanvi;
        }

        public void ChiaK_Xor_E_Thanh_8_Phan(string kxore)
        {
            for (int i = 0; i < 8; i++)
            {
                string temp = kxore.Substring(i * 6, 6);

                B[i] = temp;
            }
        }

        public int ChuyenDoiNhiPhanSangThapPhan(string binary)
        {
            // Chuyển số nhị phân sang số thập phân
            int sothapphan = Convert.ToInt32(binary, 2);

            // Chuyển số thập phân sang hệ thập lục phân
            //string chuoithapphan = Convert.ToString(sothapphan);

            return sothapphan;
        }

        public string InB()
        {
            string kq = "";
            for (int i = 0; i < B.Length; i++)
            {
                string charToAdd = B[i];
                kq = string.Format("{0}{1}", kq, charToAdd);
            }
            return kq;
        }

        public string TimSiBi()
        {
            string kq = "";
            for (int i = 0; i < B.Length; i++)
            {
                string hang = "";
                string cot = "";
                string temp = B[i];
                // lấy 2 ký tự đầu cuối
                char charToAdd = temp[0];
                hang = string.Format("{0}{1}", hang, charToAdd);
                charToAdd = temp[5];
                hang = string.Format("{0}{1}", hang, charToAdd);
                // lấy 4 ký tự giữa
                for (int j = 1; j <= 4; j++)
                {
                    charToAdd = temp[j];
                    cot = string.Format("{0}{1}", cot, charToAdd);
                }
                // chuyển đổi từ nhị phân sang thập phân lấy vị trí
                int vitrihang = ChuyenDoiNhiPhanSangThapPhan(hang);
                int vitricot = ChuyenDoiNhiPhanSangThapPhan(cot);

                // chuyển vị trí từ hàng cột sang 1 chiều
                int vitrigiatri;
                if (vitrihang > 0)
                {
                    vitrigiatri = vitricot + vitrihang * 16;
                }
                else
                {
                    vitrigiatri = vitricot;
                }

                // lấy giá trị từ mảng có thứ tự tương ứng
                int giatri = SArrays[i][vitrigiatri];
                string chuoigiatri = giatri.ToString();
                kq = string.Format("{0}{1}", kq, chuoigiatri);
                SBtp[i] = chuoigiatri;
            }
            return kq;
        }

        public string ChuyendoiThapPhansangNhiPhan()
        {
            string kq = "";
            for (int i = 0; i < 8; i++)
            {
                int sothapphan = Convert.ToInt32(SBtp[i]);
                string giatri = Convert.ToString(sothapphan, 2).PadLeft(4, '0'); // Thêm các ký tự '0' vào đầu chuỗi số nhị phân nếu cần //Padleft() : thêm các ký tự đệm bên trái
                kq = string.Format("{0}{1}", kq, giatri);
            }
            return kq;
        }

        public string hoanvitheo_P(string SiBi)
        {
            string chuoicanhoanvi = "";
            for (int i = 0; i < P.Length; i++)
            {
                int dem = P[i] - 1;
                char charToAdd = SiBi[dem];
                chuoicanhoanvi = string.Format("{0}{1}", chuoicanhoanvi, charToAdd);
            }
            return chuoicanhoanvi;
        }

        public override string laykhoaK(int i)
        {
            return base.laykhoaK(i);
        }

        public string hoanvitheo_IP_1(string R16L16)
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

        public string ChuyenNhiPhan_Sang_ThapLucPhan(string binary)
        {
            string thapluc = "";
            int Size = 4;
            string temp = "";

            for (int i = 0; i < binary.Length; i += Size)
            {
                temp = "";
                for (int j = 0; j < Size; j++)
                {
                    char charToAdd = binary[i + j];
                    temp = string.Format("{0}{1}", temp, charToAdd);
                }
                int nhiphan = Convert.ToInt32(temp, 2);
                string tempthapluc = Convert.ToString(nhiphan, 16).ToUpper();
                thapluc = string.Format("{0}{1}", thapluc, tempthapluc);
            }
            return thapluc;
        }





    }
}
