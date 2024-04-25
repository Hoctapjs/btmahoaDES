using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btmahoaDES
{
    public class Mac
    {

        public Mac() { }

        public static int TaoMac(string message, int khoabimat)
        {
            int hash = 0;
            foreach (char c in message)
            {
                hash = hash * khoabimat + c; // Nhân hash với một "seed" và cộng với giá trị ký tự
            }
            return hash;
        }
    }
}
