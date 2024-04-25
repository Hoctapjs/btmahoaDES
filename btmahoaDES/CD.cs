using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class CD : khoa
    {
        int ma;
        string c;
        string d;
        string khoa_theo_cd;
        string khoa_sau_pc2;

        public string C { get => c; set => c = value; }
        public string D { get => d; set => d = value; }
        public int Ma { get => ma; set => ma = value; }
        public string Khoa_theo_cd { get => khoa_theo_cd; set => khoa_theo_cd = value; }
        public string Khoa_sau_pc2 { get => khoa_sau_pc2; set => khoa_sau_pc2 = value; }

        public CD()
        {

        }

        public string[] KhoaKi = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", };

        public void xuatcd()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("vong lap thu , tao C{0}, D{0}", Ma);
            Console.WriteLine("C" + Ma + " la: " + C);
            Console.WriteLine("D" + Ma + " la: " + D);
            Console.WriteLine("khoa " + Ma + " theo C" + Ma + " D" + Ma + " truoc khi qua ham hoan vi PC-2 la: " + Khoa_theo_cd);
            Console.WriteLine("khoa " + Ma + " theo C" + Ma + " D" + Ma + " sau khi qua ham hoan vi PC-2 la: " + Khoa_sau_pc2);
            Console.WriteLine("================================");
        }

        public virtual string laykhoaK(int i)
        {
            string kq = KhoaKi[i-1];
            return kq;
        }

        


    }
}
