using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks.Dataflow;
class Filethayhai
{

    //    Bài 1: Ghi và đọc dãy số nguyên
    //• Mã hàm: static void GhiDaySo(string path, int n) và static void InDaySo(string path)
    //• Yêu cầu: Hàm thứ nhất sinh ngẫu nhiên $n$ số nguyên từ 1 đến 100 và ghi vào file, mỗi số một dòng.
    //Hàm thứ hai đọc file đó và in toàn bộ dãy số lên màn hình cách nhau bởi dấu phẩy.
    static void TaoFile(string path)
    {
        StreamWriter nguoighi = new StreamWriter(path);
        nguoighi.WriteLine("“The NRF Center for Retail Sustainability will augment industry sustainability efforts and resources across the retail sector, centralizing engagement across the full retail value chain,” NRF President and CEO Matthew Shay said in an announcement. “Its work will highlight the many ways retailers are making their own operations more sustainable and making it easier for consumers to find high-quality, affordable and more sustainable products.”\r\n\r\nScot Case, the NRF’s vice president of corporate social responsibility and sustainability, will serve as the center’s executive director. An external advisory board, comprised of senior-level sustainability executives, industry partners, academics and subject-matter experts, will govern the new organization, the NRF said in the announcement. The center will also leverage existing activities from the NRF’s Sustainability Council.");
        nguoighi.Close();
    }
    static void GhiDaySo(string path, int n)
    {
        Random r = new Random();
        StreamWriter nguoighi = new StreamWriter(path);
        for (int i = 0; i < n; i++)
        {
            nguoighi.WriteLine(r.Next(1, 101));
        }
        nguoighi.Close();
    }
    static void Indayso(string path)
    {
        if (File.Exists(path))
        {
            string[] chuoi = File.ReadAllLines(path);
            Console.WriteLine(string.Join(", ", chuoi));
        }
    }
    //Bài 2: Sao chép tập tin loại bỏ dòng trống
    //• Mã hàm: static void SaoChepLoaiBoDongTrong(string srcPath, string destPath)
    //• Yêu cầu: Đọc file nguồn từng dòng một, nếu dòng nào không trống thì mới ghi vào file đích.Các dòng
    //trống(chỉ chứa khoảng trắng hoặc xuống dòng) sẽ bị loại bỏ hoàn toàn.
    static void SaoChepLoaiBoDongTrong(string path, string destini)
    {
        if (!File.Exists(path)) return;
        using (StreamReader nguoidoc = new StreamReader(path))
        using (StreamWriter nguoighi = new StreamWriter(destini))
        {
            string line;
            while ((line = nguoidoc.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    nguoighi.Write(line);
            }
        }
        //Bài 3: Đọc file và lọc số chẵn
        //• Mã hàm: static void LocSoChanTrongFile(string inputPath, string outputPath)
        //• Yêu cầu: Đọc một file chứa các số nguyên(mỗi số một dòng). Lọc ra các số chẵn và ghi chúng sang
        //một file mới.
        static void Locsochantrongfile(string input, string output)
        {
            if (!File.Exists(input)) return;
            using (StreamReader nguoidoc = new StreamReader(input))
            using (StreamWriter nguoighi = new StreamWriter(output))
            {
                string line;
                while ((line = nguoidoc.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int num) && num % 2 != 0)
                        nguoighi.Write(line + ", ");
                }

            }
        }
        //Bài 4: Đếm số lượng từ khóa xuất hiện trong file
        //• Mã hàm: static int DemTuKhoa(string path, string keyword)
        //• Yêu cầu: Đọc toàn bộ nội dung của tập tin văn bản và đếm xem cụm từ keyword xuất hiện chính xác
        //bao nhiêu lần(không phân biệt chữ hoa, chữ thường). Hàm trả về số lần đếm được.
        static int DemTukhoa(string input, string keyword)
        {
            int count = 0;
            if (!File.Exists(input) || string.IsNullOrEmpty(keyword)) return 0;
            char[] kitucat = { '.', ';', ',', '\t', ' ', '?', '!' };
            string text = File.ReadAllText(input);
            string[] mangtu = text.Split(kitucat, StringSplitOptions.RemoveEmptyEntries);
            string tumuontim = keyword.ToLower();
            for (int i = 0; i < mangtu.Length; i++)
            {
                if (mangtu[i].ToLower() == tumuontim)
                    count++;
            }
            return count;
        }
        //Bài 5: Chuyển đổi định dạng chữ trong file
        //• Mã hàm: static void ChuyenDoiChuHoaThuong(string path, bool toUpper)
        //• Yêu cầu: Đọc nội dung file.Nếu toUpper = true, chuyển toàn bộ nội dung file thành chữ IN HOA;
        //    ngược lại chuyển thành chữ in thường.Sau đó ghi đè nội dung mới lại vào chính file đó.
        static void Chuyendoichuhoathuong(string path, bool toUpper)
        {
            if (!File.Exists(path)) return;
            using (StreamWriter nguoighi = new StreamWriter(path))
            {
                string context = File.ReadAllText(path);
                if (toUpper == true)
                {
                    context = context.ToUpper();
                }
                context = context.ToLower();
                nguoighi.WriteLine(path, context);
            }
            //    Bài 6: Tìm và thay thế từ khóa(Find & Replace)
            //• Mã hàm: static void ThayTheTuKhoa(string path, string oldWord, string newWord)
            //• Yêu cầu: Đọc tập tin văn bản, tìm tất cả các vị trí xuất hiện của cụm từ oldWord để thay thế bằng
            //newWord, sau đó lưu lại file.
            static void Thaythetukhoa(string path, string oldword, string newword)
            {
                if (!File.Exists(path)) return;
                string context = File.ReadAllText(path);
                context = context.Replace(oldword, newword);
                File.WriteAllText(path, context);
            }
            //Bài 7: Ghép hai tệp văn bản(Merge File)
            //• Mã hàm: static void GhepHaiFile(string file1, string file2, string fileDich)
            //• Yêu cầu: Đọc toàn bộ nội dung của file1, ghi vào fileDich.Sau đó đọc tiếp nội dung của file2 và ghi nối
            //tiếp vào cuối fileDich.
            static void GhepHaiFile(string file1, string file2, string fileDich)
            {
                if (File.Exists(fileDich)) File.Delete(fileDich);
                if (File.Exists(file1))
                {
                    using (StreamReader sr1 = new StreamReader(file1))
                    using (StreamWriter sw = new StreamWriter(fileDich, true))
                    {
                        sw.WriteLine(sr1.ReadToEnd());
                    }
                }
                if (File.Exists(file2))
                {
                    using (StreamReader sr2 = new StreamReader(file2))
                    using (StreamWriter sw = new StreamWriter(fileDich, true))
                    {
                        sw.WriteLine(sr2.ReadToEnd());
                    }
                }
            }
            //Bài 8: Đọc file lấy thông tin số lớn nhất và nhỏ nhất
            //• Mã hàm: static void TimMinMaxTrongFile(string path, out int max, out int min)
            //• Yêu cầu: Tập tin chứa một dãy số nguyên.Hàm đọc file, tìm ra số lớn nhất và nhỏ nhất rồi trả về cho
            //Main qua tham số out.
            static void TimMinMaxTrongFile(string path, out int max, out int min)
            {
                max = 0; min = 0;
                if (!File.Exists(path)) return;
                string text = File.ReadAllText(path);
                bool laso = false;
                using (StreamReader r = new StreamReader(path))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int num))
                        {
                            if (num > max) max = num;
                            if (num < min) min = num;

                            laso = true;
                        }
                        if (laso == false)
                        {
                            min = -1;
                            max = -1;
                        }
                        
                    }
                }
            }
            //Bài 9: Đảo ngược thứ tự các dòng trong file
            //• Mã hàm: static void DaoNguocCacDong(string inputPath, string outputPath)
            //• Yêu cầu: Đọc file nguồn, dòng cuối cùng của file nguồn sẽ trở thành dòng đầu tiên của file đích, dòng
            //kế cuối thành dòng thứ hai,... (đảo ngược trật tự dòng).
            static void DaoNguocCacDong(string inputPath, string outputPath)
            {
                StreamWriter w = new StreamWriter(outputPath);

                string[] line = File.ReadAllLines(inputPath);
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    w.WriteLine(line[i]);
                }
                w.Close();
            }
            //Bài 10: Trích xuất n dòng đầu tiên của file
            //• Mã hàm: static void TrichXuatDongDau(string srcPath, string destPath, int n)
            //• Yêu cầu: Đọc file nguồn và chỉ sao chép đúng n dòng đầu tiên sang file đích.Nếu file nguồn ít hơn n
            //dòng thì sao chép toàn bộ.
            static void TrichXuatDongDau(string srcPath, string destPath, int n)
            {
              
                using (StreamWriter w = new StreamWriter(destPath))
                {
                    string[] line = File.ReadAllLines(srcPath);
                    int sodong = Math.Min(line.Length, n);
                    for (int i = 0; i < sodong; i++)
                    {
                        w.WriteLine(destPath, line[i]);
                    }
                }

            }

        }
    }
}