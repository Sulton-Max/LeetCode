using System;
using System.Collections.Generic;

namespace Tester
{
    public class CustomRegex
    {
        public string Text { get; set; }
        public string Pattern { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var regexes = new List<CustomRegex>
            {
                new CustomRegex{Text = "aa", Pattern = "a" }, // False
                new CustomRegex{Text = "aa", Pattern = "." }, // False
                new CustomRegex{Text = "aa", Pattern = "a*" }, // True
                new CustomRegex{Text = "ab", Pattern = "." }, // False
                new CustomRegex{Text = "", Pattern = ".*" }, // True
                new CustomRegex{Text = "ab", Pattern = "abb*." }, // False
                new CustomRegex{Text = "abc", Pattern = "abb*." }, // True
                new CustomRegex{Text = "ab", Pattern = "abbc" }, // False
                new CustomRegex{Text = "abbbbc", Pattern = "ab*.c" }, // False
                new CustomRegex{Text = "aab", Pattern = "c*a*b" }, // True
                new CustomRegex{Text = "bab", Pattern = "c*a*b" }, // False
                new CustomRegex{Text = "aaa", Pattern = "aa" }, // False
                new CustomRegex{Text = "abcd", Pattern = "d*" }, // False
                new CustomRegex{Text = "ab", Pattern = ".*c" }, // False
                new CustomRegex{Text = "absdbbc", Pattern = ".*c" }, // True
                new CustomRegex{Text = "aaa", Pattern = "a.a" }, // True
                new CustomRegex{Text = "a", Pattern = "ab*" }, // True
                new CustomRegex{Text = "aaa", Pattern = "a*a" }, // True
                new CustomRegex{Text = "aaaaac", Pattern = "a*c" }, // True
                new CustomRegex{Text = "aaaadc", Pattern = "a*ad" }, // False
                new CustomRegex{Text = "", Pattern = "b*" }, // True
                new CustomRegex{Text = "", Pattern = "bb" }, // False
                new CustomRegex{Text = "", Pattern = "b*." }, // False
                new CustomRegex{Text = "", Pattern = "b*" }, // True
                new CustomRegex{Text = "", Pattern = "b*c" }, // False
                new CustomRegex{Text = "aaa", Pattern = "ab*a*c*a" }, // True
                new CustomRegex{Text = "aaca", Pattern = "ab*a*c*a" }, // True
                new CustomRegex{Text = "mississippi", Pattern = "mis*is*ip*." }, // True
            };
            
            RegularExpMatching_10.Solution solution = new RegularExpMatching_10.Solution();
            foreach (var regex in regexes)
            {
                var result = solution.IsMatch(regex.Text, regex.Pattern);
                Console.WriteLine($"Text : {regex.Text}, Pattern : {regex.Pattern}, Result : {result.ToString()}");
            }
        }
    }
}

