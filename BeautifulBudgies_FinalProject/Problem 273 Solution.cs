/*
* Name: Jack Driehaus
* email:  driehajl@mail.uc.edu
* Assignment Number: Final Project
* Due Date:   12/10/2024
* Course #/Section:   IS3050-001
* Semester/Year:   Fall 2024
* Brief Description of the assignment:  Final Project for the IS 3050 Web Development w/ .NET

* Brief Description of what this module does. Has us solve hard problems from LeetCode and collaborate through Github to put them all on one VS project
* Citations: https://leetcode.com/problems/integer-to-english-words/description/
             https://github.com/cole-crooks/crookscl_FinalProject
* Anything else that's relevant:My collaborators on this project are Derick Bellofatto (bellofdk@mail.uc.edu), Cole Crooks (crookscl@mail.uc.edu), and Daquan Daniels (danieldu@mail.uc.edu)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crookscl_FinalProject
{
    using System;
    using System.Text;

    public class NumberToWordsConverter
    {
        private static readonly string[] BelowTwenty = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static readonly string[] Thousands = { "", "Thousand", "Million", "Billion" };

        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            int index = 0;
            StringBuilder result = new StringBuilder();

            while (num > 0)
            {
                if (num % 1000 != 0)
                {
                    result.Insert(0, $"{Helper(num % 1000)} {Thousands[index]} ");
                }
                num /= 1000;
                index++;
            }

            return result.ToString().Trim();
        }

        private string Helper(int num)
        {
            if (num == 0)
            {
                return string.Empty;
            }
            else if (num < 20)
            {
                return BelowTwenty[num];
            }
            else if (num < 100)
            {
                return $"{Tens[num / 10]} {Helper(num % 10)}".Trim();
            }
            else
            {
                return $"{BelowTwenty[num / 100]} Hundred {Helper(num % 100)}".Trim();
            }
        }
    }

    // Example usage:
    public class Program
    {
        public static void Main()
        {
            var converter = new NumberToWordsConverter();

            Console.WriteLine(converter.NumberToWords(123));         // Output: "One Hundred Twenty Three"
            Console.WriteLine(converter.NumberToWords(12345));      // Output: "Twelve Thousand Three Hundred Forty Five"
            Console.WriteLine(converter.NumberToWords(1234567));    // Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
        }
    }
}