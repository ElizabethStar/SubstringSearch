using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab6;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestSubstring
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SearchTest()
        {
            var algms = new List<ISubstringSearch>()
            {
                //new Boyer_Moore(),
                new B_M(),
                new Brute_force(),
                new Rabin_Karp(),
                new Knuth_Morris_Pratt()
   };
            string text = "aaaaaaaaaa"; //10
            string pattern = "aa";
            var expected = Enumerable.Range(0, 9).ToList();
            foreach (var algm in algms)
            {
                var actual = algm.SubstringSearch(pattern, text);
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void SearchBagOfWordsOnAnnaTxt()
        {
            var algms = new List<ISubstringSearch>()
            {
                new Boyer_Moore(),
                new Rabin_Karp(),
                new Knuth_Morris_Pratt()
            };
            string text;
            using (var sr = new StreamReader("anna.txt", Encoding.UTF8))
            {
                text = sr.ReadToEnd().ToLower();
            }

            int number = 100;
            Regex rg = new Regex(@"\w+");
            var bag = new HashSet<string>();
            var matches = rg.Matches(text);
            foreach (var match in matches)
            {
                bag.Add(match.ToString());
                if (bag.Count > number) break;
            }
            foreach (var pattern in bag)
            {
                var BF = new Brute_force();
                var expected = BF.SubstringSearch(pattern, text);
                foreach (var algm in algms)
                {
                    var actual = algm.SubstringSearch(pattern, text);
                    CollectionAssert.AreEqual(expected, actual);
                }
            }
        }
    }
}
