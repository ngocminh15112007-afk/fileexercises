using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace baitapfile
{
    public class Baitapslides
    {
        static void Main()
        {
            Onfile.TaovaGhi("duyetchanle");

        }
        static void CreateBlankFile(string path)
        {
            FileStream fs = File.Create(path);
            { }
            fs.Close();
            Console.WriteLine($"1. Created a blank file: {path}");
        }
        static void RemoveFile(string path)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine($"Da xoa file {path}");
            }
            else
            {
                Console.WriteLine("File khong ton tai");
            }
        }
        static void CreateAddText(string path, string text)
        {
            File.WriteAllText(path, text);
            Console.WriteLine("Da tao va ghi van ban vao file");
           
        }
        static void CreateRead (string path, string text)
        {
            File.WriteAllText(path, text);
            string content = File.ReadAllText(path);
            Console.WriteLine($"Noi dung dc tao la: {content}");
        }
        static void WriteArrayLines (string path, string[] lines)
        {
            StreamWriter nguoiGhi = new StreamWriter(path);
            for (int i = 0; i<lines.Length; i++)
            {
                nguoiGhi.WriteLine(lines[i]);
            }
            nguoiGhi.Close();
            Console.WriteLine("5. Da ghi mang vao chuoi file");
        }
        static void AppendText(string path, string text)
        {
            StreamWriter nguoighinoi = new StreamWriter(path, true);
            nguoighinoi.WriteLine(text);
            nguoighinoi.Close();
            Console.WriteLine("5. Da noi them van ban vao cuoi file");
        }
        static void CopyDisplay(string sourcepath, string destpath)
        {
            File.Copy(sourcepath, destpath, true);
            StreamReader nguoidoc = new StreamReader(destpath);
            string noidungdoc = nguoidoc.ReadToEnd();
            nguoidoc.Close();
            Console.WriteLine($"Noi dung file copy la: {noidungdoc}");
        }
        static void MoveFile(string sourcepath, string destpath)
        {
            if (File.Exists(destpath)==true)
            {
                File.Delete(destpath);
            }
            File.Move(sourcepath, destpath);
            Console.WriteLine($"8. Da di chuyen/doitenfilesang {destpath}");
        }
        static void ReadFirstLine(string path)
        {
            StreamReader nguoidoc = new StreamReader(path);
            string dong1 = nguoidoc.ReadLine();
            nguoidoc.Close();
            Console.WriteLine($"9.Dongdautien {dong1}");
        }
        static void ReadLastLine (string path)
        {
            string dongdautien="";
            string dongcuoicung = "";
            StreamReader nguoidoc = new StreamReader(path);
            
            while((dongdautien = nguoidoc.ReadLine()) != null)
            {
                dongcuoicung = dongdautien;
            }
            nguoidoc.Close();
            Console.WriteLine($"10.Dongcuoicung {dongcuoicung}");
        }
        static void ReadLastLines (string path, int n)
        {
            List<string> danhsachdong = new List<string>();
            string dong = "";
            StreamReader nguoidoc = new StreamReader(path);
            while ((dong = nguoidoc.ReadLine()) != null)
            {
                danhsachdong.Add(dong);
            }
            int tongdong = danhsachdong.Count;
            int sodongcuoi = tongdong - n;
            if (sodongcuoi < tongdong) sodongcuoi = 0;
            Console.WriteLine("N dong cuoi la: ");
            for (int i = sodongcuoi; i<tongdong; i++)
            {
                Console.WriteLine(danhsachdong[i]);
            }
            Console.WriteLine();
            nguoidoc.Close();
        }
        static void ReadSpecificLine(string path, int dong)
        {
            int vitricantim = 1;
            StreamReader nguoidoc = new StreamReader(path);
            string dongdangtim = "";
            string dongcantim = "";
            while ((dongdangtim=nguoidoc.ReadLine()) != null)
            {
                if (vitricantim == dong)
                {
                    dongcantim = dongdangtim;
                    break;
                }
                vitricantim++;
            }
            nguoidoc.Close();
            Console.WriteLine($"Dong {dong} co noi dung la {dongcantim}");
        }
        static void CountLines (string path)
        {
            int count = 0;
            string dautien = "";
            StreamReader nguoidoc = new StreamReader(path);
            while ((dautien = nguoidoc.ReadLine()) != null)
            {
                count++;
            }
            nguoidoc.Close();
            Console.WriteLine($"Tong so dong la {count}");
        }

    }
}
