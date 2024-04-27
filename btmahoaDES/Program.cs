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
            string st_mac_hex = "";
            byte[] thongdiepBytes_guidi = Encoding.UTF8.GetBytes("khoitao");
            byte[] mac_guidi = Encoding.UTF8.GetBytes("khoitao");
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
                        Console.WriteLine("nhap khoa bi mat cua ban: ");
                        string khoabm = Console.ReadLine();
                        // Khóa bí mật để tạo và kiểm tra MAC (HMAC)
                        byte[] khoabimat = Encoding.UTF8.GetBytes(khoabm);

                        // Thông điệp cần tạo mã xác thực
                        Console.WriteLine("thong diep cua ban la ban mo da duoc tao o phan ma hoa");
                        Console.WriteLine("noi dung cua thong diep: " + st_for_mac);
                        string thongdiep = st_for_mac;
                        byte[] thongdiepBytes = Encoding.UTF8.GetBytes(thongdiep);
                        thongdiepBytes_guidi = thongdiepBytes;

                        // Tạo MAC
                        byte[] mac;
                        using (HMACSHA256 hmac = new HMACSHA256(khoabimat))
                        {
                            mac = hmac.ComputeHash(thongdiepBytes);
                        }
                        mac_guidi = mac;

                        // In ra MAC (chuyển sang dạng hex để dễ đọc)
                        Console.WriteLine("MAC: " + BitConverter.ToString(mac).Replace("-", ""));
                        st_mac_hex = BitConverter.ToString(mac).Replace("-", "");

                        //// Xác thực MAC
                        //bool kiemtra = Kiemtra_MAC(mac, thongdiepBytes, khoabimat);
                        //Console.WriteLine("MAC hop le: " + kiemtra);
                        break;
                    case 4:

                        Console.WriteLine("nhap khoa bi mat cua ban: ");
                        string khoabm_cuaminh = Console.ReadLine();
                        // Khóa bí mật của chúng ta để tạo khi kiểm tra MAC (HMAC)
                        byte[] khoabimat_for_kt = Encoding.UTF8.GetBytes(khoabm_cuaminh);



                        // Thông điệp nhận được cần tạo mã xác thực
                        Console.WriteLine("qua trinh gui den thanh cong");
                        Console.WriteLine("ban da nhan duoc thong diep o dang bytes");
                        string noidung_thongdiep = st_for_mac;
                        byte[] thongdiepBytes_nhanduoc = thongdiepBytes_guidi;

                        // Tạo MAC với mục đích kiểm tra thông điệp truyền tới
                        Console.WriteLine("khoi tao MAC nham kiem tra thong diep nhan duoc");

                        byte[] mac_nhan_duoc = mac_guidi;
                        
                        // In ra MAC (chuyển sang dạng hex để dễ đọc)
                        Console.WriteLine("MAC nhan duoc: " + BitConverter.ToString(mac_nhan_duoc).Replace("-", ""));

                        // Xác thực MAC
                        bool kiemtra = Kiemtra_MAC(mac_nhan_duoc, thongdiepBytes_nhanduoc, khoabimat_for_kt);
                        Console.WriteLine("MAC hop le: " + kiemtra);
                        if (kiemtra == true)
                        {
                            Console.WriteLine("MAC da hop le, thong diep cua ban van toan ven");
                            Console.WriteLine("Bat dau giai doan giai ma thong diep duoc nhan");
                            banmo bm_nhan = new banmo();
                            bm_nhan.ThietLapGiaTriBanMo(noidung_thongdiep);
                            bm_nhan.Xuatbanmo();
                            danhsachLR dslrnd_nhan = new danhsachLR();
                            dslrnd_nhan.NgichDaoDanhSachLR(bm_nhan.L16, bm_nhan.R16);
                        }
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
                Console.WriteLine("MAC duoc tinh toan: " + BitConverter.ToString(Mac_duoc_tinhtoan).Replace("-", ""));
                // So sánh MAC tính toán với MAC cung cấp
                return StructuralComparisons.StructuralEqualityComparer.Equals(Mac_can_kt, Mac_duoc_tinhtoan);
            }
        }
    }
}