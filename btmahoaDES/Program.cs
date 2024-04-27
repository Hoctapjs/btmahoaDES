using System;
using System.Security.Cryptography;
using System.Reflection;
using System.Text;
using System.Collections;

namespace btmahoaDES
{
    public class Program
    {
        static void Main(string[] args)
        {

            //tạo khóa
            //khoa k = new khoa();
            //Console.WriteLine("khoa k co gia tri: " + k.Khoak);
            //string binary = k.HexToBinary();
            //Console.WriteLine("khoa sau khi chuyen sang chuoi nhi phan: " + binary);
            //Console.WriteLine("k+ hoan vi theo PC-1 bo di cac bit kiem tra: " + k.hoanvitheopc_1(binary));
            //string temp = k.hoanvitheopc_1(binary);
            //Console.WriteLine("tach C0 va D0 tu k+: ");
            //CD cd0 = new CD();
            //cd0.C = temp.Substring(0, 28);
            //cd0.D = temp.Substring(28, temp.Length - 28);
            //Console.WriteLine("C0 la: " + cd0.C);
            //Console.WriteLine("D0 la: " + cd0.D);


            //danhsachCD dscd = new danhsachCD();
            //dscd.khoitao_ds_CD(cd0.C, cd0.D);
            //dscd.xuatdsCD();
            //kết thúc tạo khóa
            //xử lý văn bản M

            int chon = 0;
            string st_for_mac = "";
            do
            {
                Menu();
                Console.WriteLine("hay nhap lua chon cua ban: ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 0:
                        break;
                    case 1:
                        vanban vb = new vanban();
                        vb.ThietLapGiaTriBanRo();
                        vb.xuatbanroM();
                        danhsachLR dslr = new danhsachLR();
                        dslr.khoitaodanhsachLR(vb.L0, vb.R0);
                        st_for_mac = dslr.LayChuoi();
                        break;
                    case 2:
                        banmo bm = new banmo();
                        bm.ThietLapGiaTriBanMo();
                        bm.Xuatbanmo();
                        danhsachLR dslrnd = new danhsachLR();
                        dslrnd.NgichDaoDanhSachLR(bm.L16, bm.R16);





                        break;
                    case 3:
                        // Khóa bí mật để tạo và kiểm tra MAC (HMAC)
                        byte[] khoabimat = Encoding.UTF8.GetBytes("SecretKey123");

                        // Thông điệp cần được xác thực
                        string thongdiep = st_for_mac;
                        byte[] thongdiepBytes = Encoding.UTF8.GetBytes(thongdiep);

                        // Tạo MAC
                        byte[] mac;
                        using (HMACSHA256 hmac = new HMACSHA256(khoabimat))
                        {
                            mac = hmac.ComputeHash(thongdiepBytes);
                        }

                        // In ra MAC (chuyển sang dạng hex để dễ đọc)
                        Console.WriteLine("MAC: " + BitConverter.ToString(mac).Replace("-", ""));

                        // Xác thực MAC
                        bool kiemtra = Kiemtra_MAC(mac, thongdiepBytes, khoabimat);
                        Console.WriteLine("MAC hop le: " + kiemtra);
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            } while (chon != 0);










            Console.ReadLine();
        }

        public static void Menu()
        {
            Console.WriteLine("----------Menu----------");
            Console.WriteLine("- 1. Ma Hoa----------");
            Console.WriteLine("- 2. Giai Ma----------");
            Console.WriteLine("- 3. MAC----------");
            Console.WriteLine("- 4. Kiem tra MAC----------");
            Console.WriteLine("- 0. Thoat----------");
        }

        public static bool Kiemtra_MAC(byte[] Mac_can_kt, byte[] thongdiep, byte[] khoabimat)
        {
            using (HMACSHA256 hmac = new HMACSHA256(khoabimat))
            {
                byte[] Mac_duoc_tinhtoan = hmac.ComputeHash(thongdiep);
                // So sánh MAC tính toán với MAC cung cấp
                return StructuralComparisons.StructuralEqualityComparer.Equals(Mac_can_kt, Mac_duoc_tinhtoan);
            }
        }
    }
}