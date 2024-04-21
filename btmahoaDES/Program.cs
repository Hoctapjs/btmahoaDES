using System;
using System.Reflection;

namespace btmahoaDES
{
    public class Program
    {
        static void Main(string[] args)
        {

            // tạo khóa
            khoa k = new khoa();
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
            dscd.xuatdsCD();
            // kết thúc tạo khóa
            // xử lý văn bản M
            vanban vb = new vanban();
            vb.xuatbanroM();
            

            



            Console.ReadLine();
        }
    }
}