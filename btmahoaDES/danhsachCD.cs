using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class danhsachCD
    {
        List<CD> dsCD = new List<CD>();

        public void khoitao_ds_CD(string c0, string d0)
        {
            string tempc = c0;
            string tempd = d0;
            Console.WriteLine("danh sach CD");
            for (int i = 1; i <= 16; i++)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("vong lap thu , tao C{0}, D{0}", i);
                CD cd = new CD();
                cd.Ma = i;
                cd.C = cd.dichbit_taoCiDi(tempc, i);
                cd.D = cd.dichbit_taoCiDi(tempd, i);
                Console.WriteLine("C" + i + " la: " + cd.C);
                Console.WriteLine("D" + i + " la: " + cd.D);
                cd.Khoa_theo_cd = cd.C;
                cd.Khoa_theo_cd = string.Format("{0}{1}", cd.Khoa_theo_cd, cd.D);
                cd.Khoa_sau_pc2 = cd.hoanvitheopc_2(cd.Khoa_theo_cd);
                Console.WriteLine("khoa " + i + " theo C" + i + " D" + i + " truoc khi qua ham hoan vi PC-2 la: " + cd.Khoa_theo_cd);
                Console.WriteLine("khoa " + i + " theo C" + i + " D" + i + " sau khi qua ham hoan vi PC-2 la: " + cd.Khoa_sau_pc2);
                dsCD.Add(cd);
                tempc = cd.C;
                tempd = cd.D;
                Console.WriteLine("================================");
            }
        }

        public void xuatdsCD()
        {
            Console.WriteLine("xuat danh sach cd");
            for (int i = 0; i < dsCD.Count(); i++)
            {
                dsCD[i].xuatcd();
            }
        }

        public string xuatkhoatheothutu(int I_of_K)
        {
            return dsCD[I_of_K - 1].Khoa_sau_pc2;
        }
    }
}
