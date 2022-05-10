using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace ThicknessDataTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CSV파일읽기()
        {
            var reader = new StreamReader(File.OpenRead(@"2022_05_10.csv"));
            Console.WriteLine(reader.ReadLine());
            Console.WriteLine(reader.ReadLine());
            Console.WriteLine(reader.ReadLine());

        }

        [TestMethod]
        public void 헤더_날리기()
        {
            var reader = new StreamReader(File.OpenRead(@"2022_05_10.csv"));
            reader.ReadLine();
            reader.ReadLine();
            Console.WriteLine(reader.ReadLine());
        }

        [TestMethod]
        public void csv_행수()
        {
            var reader = new StreamReader(File.OpenRead(@"2022_05_10.csv"));
            int rowCount = 0;
            while(reader.ReadLine() != null)
            {
                rowCount++;
            }
            Console.WriteLine(rowCount);
        }

        [TestMethod]
        public void 측정포인트_개수()
        {
            var reader = new StreamReader(File.OpenRead(@"2022_05_10.csv"));

            var columns = reader.ReadLine().Split(',');
            int sitesColumnIndex = Array.IndexOf(columns, "SITES");
            reader.ReadLine();
            var readLine = reader.ReadLine();
            var data = readLine.Split(',');
            Console.WriteLine(data[sitesColumnIndex]);
            
        }

        [TestMethod]
        public void 측정_매수()
        {
            int rowCount = 0;
            var reader = new StreamReader(File.OpenRead(@"2022_05_10.csv"));
            reader.ReadLine();
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                rowCount++;
                reader.ReadLine();
            }
            Console.WriteLine(rowCount/2);

        }

        [TestMethod]
        public void 측정웨이퍼_리스트출력()
        {
            var reader = new StreamReader(File.OpenRead(@"2022_05_10.csv"));
            var columns = reader.ReadLine().Split(',');
            int waferIdColumnIndex = Array.IndexOf(columns, "WAFER ID");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine().Split(',')[waferIdColumnIndex]);
                reader.ReadLine();
            }

        }

        [TestMethod]
        public void 측정로트_리스트출력()
        {
            var reader = new StreamReader(File.OpenRead(@"2022_05_10.csv"));
            var columns = reader.ReadLine().Split(',');
            int lotIdColumnIndex = Array.IndexOf(columns, "LOT ID");
            reader.ReadLine();

            List<string> array = new List<string>();
            Dictionary<string, bool> lotDict = new Dictionary<string, bool>();
            while (!reader.EndOfStream)
            {
                string lotId = reader.ReadLine().Split(',')[lotIdColumnIndex];
                if (!lotDict.ContainsKey(lotId))
                {
                    lotDict[lotId] = true;
                    array.Add(lotId);
                }
            }
            foreach(string str in array)
            {
                Console.WriteLine(str);
            }
        }
    }
}
