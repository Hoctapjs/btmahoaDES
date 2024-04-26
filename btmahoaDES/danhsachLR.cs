using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class danhsachLR
    {
        List<LR> dsLR = new List<LR>();
        string Str_For_Mac = "";

        public void khoitaodanhsachLR(string l0, string r0)
        {
            khoa k = new khoa();
            k.nhapkhoak();
            Console.WriteLine("khoa k co gia tri: " + k.Khoak);
            string binary = k.HexToBinary();
            Console.WriteLine("khoa sau khi chuyen sang chuoi nhi phan: " + binary);
            Console.WriteLine("k+ hoan vi theo PC-1 bo di cac bit kiem tra: " + k.hoanvitheopc_1(binary));
            string temp = k.hoanvitheopc_1(binary);
            Console.WriteLine("tach C0 va D0 tu k+: ");
            CD cd0 = new CD();
            cd0.C = temp.Substring(0, 28);
            cd0.D = temp.Substring(28, temp.Length - 28);
            Console.WriteLine("C0 la: " + cd0.C);
            Console.WriteLine("D0 la: " + cd0.D);


            danhsachCD dscd = new danhsachCD();
            dscd.khoitao_ds_CD(cd0.C, cd0.D);
            //dscd.xuatdsCD();
            string templ = l0;
            string tempr = r0;
            int sovonglap = 16;
            Console.WriteLine("danh sach LR");
            for (int i = 1; i <= sovonglap; i++)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("vong lap thu , tao L{0}, R{0}", i);
                LR lr = new LR();
                string khoak = dscd.xuatkhoatheothutu(i);
                lr.Ma = i;
                lr.L = tempr;
                Console.WriteLine("L" + i + " cua chung ta la: " + lr.L);
                lr.EofR = lr.hoanvitheo_E(tempr);
                Console.WriteLine("R" + (i - 1) + " sau khi di qua ham E: " + lr.EofR);

                lr.KxorE = lr.XorE(khoak, lr.EofR);
                Console.WriteLine("K XOR E(R" + (i - 1) + "): " + lr.KxorE);
                Console.WriteLine("ta goi K XOR E(R" + (i - 1) + ") la B: " + lr.KxorE);
                lr.ChiaK_Xor_E_Thanh_8_Phan(lr.KxorE);
                for (int j = 0; j < 8; j++)
                {
                    Console.WriteLine("mang B thu " + j + " co gia tri nhi phan la: " + lr.B[j]);
                }
                lr.TimSiBi();
                Console.WriteLine("gia tri co duoc sau khi di qua cac bang S la (thap phan): " + lr.TimSiBi());
                for (int z = 0; z < 8; z++)
                {
                    Console.WriteLine("mang SB thu " + z + " co gia tri thap phan la: " + lr.SBtp[z]);
                }
                Console.WriteLine("cac gia tri tao thanh chuoi nhi phan");
                string SiBi_ALL_NhiPhan = lr.ChuyendoiThapPhansangNhiPhan();
                Console.WriteLine("chuoi nhi phan cua SiBi voi i tu 1 den 8 la: " + lr.ChuyendoiThapPhansangNhiPhan());
                string f_func = lr.hoanvitheo_P(SiBi_ALL_NhiPhan);
                Console.WriteLine("ham f cua K" + i + " va R" + (i - 1) + " la: " + f_func);
                lr.R = lr.XorP(templ, f_func);
                Console.WriteLine("R" + i + " duoc tinh bang xor cua L" + (i - 1) + " va " + "f cua K" + i + " va R" + (i - 1) + " la: " + lr.R);
                templ = lr.L;
                tempr = lr.R;
                if (i == 16)
                {
                    string R16L16 = "";
                    string charToAdd = lr.R;
                    R16L16 = string.Format("{0}{1}", R16L16, charToAdd);
                    charToAdd = lr.L;
                    R16L16 = string.Format("{0}{1}", R16L16, charToAdd);
                    Console.WriteLine("chuoi R16-L16 cua ta la: " + R16L16);
                    string ChuoiIP1_bina = lr.hoanvitheo_IP_1(R16L16);
                    Console.WriteLine("chuoi sau khi qua IP1 (nhi phan) la: " + ChuoiIP1_bina);
                    string ChuoiIP1_hexa = lr.ChuyenNhiPhan_Sang_ThapLucPhan(ChuoiIP1_bina);
                    Console.WriteLine("chuoi sau khi qua IP1 (thap luc phan) la: " + ChuoiIP1_hexa);
                    Str_For_Mac = ChuoiIP1_hexa;
                }
            }
        }

        public string LayChuoi()
        {
            return Str_For_Mac;
        }

        public void NgichDaoDanhSachLR(string l16, string r16)
        {
            khoa k = new khoa();
            k.nhapkhoak();
            Console.WriteLine("khoa k co gia tri: " + k.Khoak);
            string binary = k.HexToBinary();
            Console.WriteLine("khoa sau khi chuyen sang chuoi nhi phan: " + binary);
            Console.WriteLine("k+ hoan vi theo PC-1 bo di cac bit kiem tra: " + k.hoanvitheopc_1(binary));
            string temp = k.hoanvitheopc_1(binary);
            Console.WriteLine("tach C0 va D0 tu k+: ");
            CD cd0 = new CD();
            cd0.C = temp.Substring(0, 28);
            cd0.D = temp.Substring(28, temp.Length - 28);
            Console.WriteLine("C0 la: " + cd0.C);
            Console.WriteLine("D0 la: " + cd0.D);


            danhsachCD dscd = new danhsachCD();
            dscd.khoitao_ds_CD(cd0.C, cd0.D);
            //dscd.xuatdsCD();
            string templ = l16;
            string tempr = r16;
            int sovonglap = 16;
            Console.WriteLine("danh sach LR");
            for (int i = sovonglap; i >= 1; i--)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("vong lap thu , tao L{0}, R{0}", i);
                LR lr = new LR();
                string khoak = dscd.xuatkhoatheothutu(i);
                lr.Ma = i;
                lr.R = templ;
                Console.WriteLine("R" + (i - 1) + " cua chung ta la: " + lr.R);
                lr.EofR = lr.hoanvitheo_E(lr.R);
                Console.WriteLine("R" + (i - 1) + " sau khi di qua ham E: " + lr.EofR);

                lr.KxorE = lr.XorE(khoak, lr.EofR);
                Console.WriteLine("K XOR E(R" + (i - 1) + "): " + lr.KxorE);
                Console.WriteLine("ta goi K XOR E(R" + (i - 1) + ") la B: " + lr.KxorE);
                lr.ChiaK_Xor_E_Thanh_8_Phan(lr.KxorE);
                for (int j = 0; j < 8; j++)
                {
                    Console.WriteLine("mang B thu " + j + " co gia tri nhi phan la: " + lr.B[j]);
                }
                lr.TimSiBi();
                Console.WriteLine("gia tri co duoc sau khi di qua cac bang S la (thap phan): " + lr.TimSiBi());
                for (int z = 0; z < 8; z++)
                {
                    Console.WriteLine("mang SB thu " + z + " co gia tri thap phan la: " + lr.SBtp[z]);
                }
                Console.WriteLine("cac gia tri tao thanh chuoi nhi phan");
                string SiBi_ALL_NhiPhan = lr.ChuyendoiThapPhansangNhiPhan();
                Console.WriteLine("chuoi nhi phan cua SiBi voi i tu 1 den 8 la: " + lr.ChuyendoiThapPhansangNhiPhan());
                string f_func = lr.hoanvitheo_P(SiBi_ALL_NhiPhan);
                Console.WriteLine("ham f cua K" + i + " va R" + (i - 1) + " la: " + f_func);
                lr.L = lr.XorP(tempr, f_func);
                Console.WriteLine("L" + (i - 1) + " duoc tinh bang xor cua R" + (i) + " va " + "f cua K" + i + " va R" + (i - 1) + " la: " + lr.L);
                templ = lr.L;
                tempr = lr.R;
                if (i == 1)
                {
                    string L1R1 = "";
                    string charToAdd = lr.L;
                    L1R1 = string.Format("{0}{1}", L1R1, charToAdd);
                    charToAdd = lr.R;
                    L1R1 = string.Format("{0}{1}", L1R1, charToAdd);
                    Console.WriteLine("chuoi da di qua IP (nhi phan) la: " + L1R1);
                    string ChuoiM_bina = lr.hoanvi_lai_theo_IP(L1R1);
                    Console.WriteLine("chuoi ban ro M (nhi phan) la: " + ChuoiM_bina);
                    string ChuoiM_hexa = lr.ChuyenNhiPhan_Sang_ThapLucPhan(ChuoiM_bina);
                    Console.WriteLine("chuoi ban ro M (thap luc phan) la: " + ChuoiM_hexa);
                    Str_For_Mac = ChuoiM_hexa;
                }
            }
        }
    }
}
