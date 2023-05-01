using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string pat = "Степан Аркадьич";
            //string pat = "Анна";
            var algms = new List<ISubstringSearch>()
                {
                    new Brute_force(),
                    new Rabin_Karp(),
                    new Boyer_Moore(),
                    new Knuth_Morris_Pratt()
                };
            string text;
            using (var sr = new StreamReader("anna.txt", Encoding.UTF8))
            {
                text = sr.ReadToEnd().ToLower();
            }
            string pattern;
            using (var sr = new StreamWriter("search.txt"))
            {
                sr.Write(pat);
            }
            using (var sr = new StreamReader("search.txt", Encoding.UTF8))
            {
                pattern = sr.ReadToEnd().ToLower();
            }
            //for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("___________________________");

                foreach (var algm in algms)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var actual = algm.SubstringSearch(pattern, text);
                    stopWatch.Stop();
                    Console.WriteLine(algm + ": {0}", stopWatch.ElapsedMilliseconds);
                    Console.WriteLine("Количество повторений:" + actual.Count);
                    Console.WriteLine();
                }
                long time1=0;
                for (int i=0;i<100;i++)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    algms[0].SubstringSearch(pattern, text);
                    time1 += stopWatch.ElapsedMilliseconds;
                }
                Console.WriteLine("Brute force - " + time1/100);


                long time2 = 0;
                for (int i = 0; i < 100; i++)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    algms[1].SubstringSearch(pattern, text);
                    time2 += stopWatch.ElapsedMilliseconds;
                }
                Console.WriteLine("Rabin Karp - " + time2/100);


                long time3 = 0;
                for (int i = 0; i < 100; i++)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    algms[2].SubstringSearch(pattern, text);
                    time3 += stopWatch.ElapsedMilliseconds;
                }
                Console.WriteLine("Boyer_Moore - " + time3 / 100);



                long time4 = 0;
                for (int i = 0; i < 100; i++)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    algms[3].SubstringSearch(pattern, text);
                    time4 += stopWatch.ElapsedMilliseconds;
                }
                Console.WriteLine("Knuth_Morris_Pratt - " + time4 / 100);

            }
            Console.ReadKey();
        }
    }
}
