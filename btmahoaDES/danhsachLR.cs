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

        public void khoitaodanhsachLR(string l0,string r0, string k1)
        {
            string templ = l0;
            string tempr = r0;
            Console.WriteLine("danh sach LR");
            for (int i = 1; i <= 16; i++)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("vong lap thu , tao L{0}, R{0}", i);
                LR lr = new LR();
                lr.Ma = i;
                lr.L = r0;
                lr.EofR = lr.hoanvitheo_E(r0);
                lr.KxorE = lr.Xor(k1, lr.EofR);
                lr.ChiaK_Xor_E_Thanh_8_Phan(lr.KxorE);

            }
        }
    }
}
