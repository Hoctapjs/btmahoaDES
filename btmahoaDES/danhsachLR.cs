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

        public void khoitaodanhsachLR(string l0, string r0, string k1)
        {
            string templ = l0;
            string tempr = r0;
            int sovonglap = 1;
            Console.WriteLine("danh sach LR");
            for (int i = 1; i <= sovonglap; i++)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("vong lap thu , tao L{0}, R{0}", i);
                LR lr = new LR();
                lr.Ma = i;
                lr.L = tempr;
                Console.WriteLine("L" + i + " cua chung ta la: " + lr.L);
                lr.EofR = lr.hoanvitheo_E(r0);
                Console.WriteLine("R0 sau khi di qua ham E: " + lr.EofR);
                lr.KxorE = lr.XorE(k1, lr.EofR);
                Console.WriteLine("K XOR E(R0): " + lr.KxorE);
                Console.WriteLine("ta goi K XOR E(R0) la B: " + lr.InB());
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
                //lr.R = lr.Xor(templ, f_func);
                //Console.WriteLine("R" + i + " duoc tinh bang xor cua L" + (i-1) + " va " + "f cua K" + i + " va R" + (i - 1) + " la: " + lr.R);
            }
        }
    }
}
