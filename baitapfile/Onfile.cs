using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace baitapfile
{
    public class Onfile
    {
        public static void TaovaGhi(string path)
        {
            StreamWriter nguoighi = new StreamWriter(path);
            nguoighi.WriteLine("a");
            nguoighi.WriteLine("b");
            nguoighi.WriteLine("c");
            nguoighi.WriteLine("d");
            nguoighi.WriteLine("e");
            nguoighi.WriteLine("f");
            nguoighi.Close();

            StreamReader nguoidoc = new StreamReader(path);
            string dong1="";
            int vitri = 1;
            while((dong1 = nguoidoc.ReadLine())!=null)
            {
                if(vitri%2 !=0)
                {
                    Console.WriteLine($"Dong{vitri}: {dong1} la dong le");
                }
                vitri++;
            }
            nguoidoc.Close();
            

        }
        
    }
}
