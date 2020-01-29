using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LogilityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string ReadLocation = args[0];
            string WriteLocation = args[1];

            string[] Words = Regex.Split(File.OpenText(ReadLocation).ReadToEnd(), @"\s");
            var MostCommonWords = Words.Where(w => !string.IsNullOrWhiteSpace(w)).GroupBy(w => w).Select(w => new
            {
                Key = w.Key,
                Count = w.Count()
            }).OrderByDescending(w => w.Key).OrderByDescending(w => w.Count);

            List<string> WordList = new List<string>();
            foreach (var word in MostCommonWords)
            {
                WordList.Add(String.Format("{0} {1}",word.Key,word.Count));
            }
            File.WriteAllLines(WriteLocation, WordList);
        }
    }
}
