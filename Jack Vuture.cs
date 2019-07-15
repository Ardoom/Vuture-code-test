using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuture.CodingTest
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {

        // Method that return count of the given 
        // character in the string 
    

        //task1
        public static int count(string s, char c)
        {
            int res = 0;

            for (int i = 0; i < s.Length; i++)
            {

                // checking character in string 
                if (s[i] == c)
                    res++;
            }

            return res;
        }
        //Palindrome checker
        public static bool Task2(string str)
        {
            int i = 0;
            int j = str.Length - 1;

            while (i < j)
            {
                if (str[i] != str[j])
                    return false;

                i++;
                j--;
            }

            return true;
        }


        // Driver method 
        public static void Main()
        {
            string str = "";
            char c;
            string Task;
            string Palin;

           Console.WriteLine("Select a task: 1, 2, 3 ,3b or 3c");
           Task = Console.ReadLine();

            switch (Task)

            {
                case "1": //Task 1
                    Console.WriteLine("Please select what character you wish to track");
                    c = Console.ReadKey().KeyChar;
                    Console.WriteLine("");
                    Console.WriteLine("Enter the string you want to check");
                    str = Console.ReadLine();
                    Console.WriteLine(count(str, c));
                    Console.ReadKey();
                    break;

                case "2": //Task 2
                    Console.WriteLine("Enter a string to be checked if it is a palindrome");
                    Palin = Console.ReadLine();
                    Console.WriteLine(Task2(Palin));
                    Console.Read();
                   
                    break;

                case "3": //Task 3
                    IDictionary<string, int> dict = new Dictionary<string, int>();
                    String words;
                    String source;
                    dict.Clear();
                    Console.WriteLine("Add a word you wish to censor");
                    words = Console.ReadLine();

                    while (!string.IsNullOrEmpty(words))
                    {

                        dict.Add(words, 0);
                        Console.WriteLine("Add another word to censor, or press enter to move on");
                        words = Console.ReadLine();

                    }
                    Console.WriteLine("Input the sentence you wish to check");
                    source = Console.ReadLine();


                    IDictionary<string, int> dict2 = new Dictionary<string, int>(dict);

                    String[] split_source = source.Split(' ');
                    foreach (string word in split_source)
                    {
                        foreach (string key in dict.Keys)
                        {
                            if (word == key)
                            {
                                dict2[key] += 1;
                            }
                        }
                    }

                    foreach (string key in dict2.Keys)
                    {
                        Console.WriteLine(key + " => " + dict2[key]);
                    }
                    break;

                case "3b": //Task 3B
                    string input;
                    Console.WriteLine("Please input the sentence you wish to have censored");
                    input = Console.ReadLine();
                    Console.WriteLine("Please input 3 words to censor");
                    string[] splitwords = new string[3];
                    for (int i = 0; i < splitwords.Length; i++)
                    {
                        splitwords[i] = Console.ReadLine();
                    }

                    foreach (string word in splitwords)
                    {
                        var regex = new Regex(@"(?<![\w])" + word + @"(?![\w])", RegexOptions.IgnoreCase);
                        input = regex.Replace(input, m => "****");

                    }
                    Console.WriteLine(input);

              
                    break;

                case "3c": // task 3C

                    string data;
                    Console.WriteLine("Please enter your sentence to be checked.");
                    data = Console.ReadLine();
                    string[] wordsi = data.Split(' ');
                    foreach (string word in wordsi)
                    {
                       if (Task2(word) == true)
                        {
                            Console.Write("**** ");
                        }
                       else
                        {
                            Console.Write(word + " ");
                        }
                    }
                    break;

                case "3d":
                    Console.WriteLine("1. An external file could be created and costantly added too to keep it up to date. This file would be checked against words written, and if they match, replace them.");
                    Console.WriteLine("2. Pattern matching could be another thing used, to deal with people trying to avoid the filter using 'LeetSpeak' or incorrect spelling.");
                    Console.WriteLine("3. LINQ could be used to search a sentence for words that you could want to sensor.");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;


            }
        }
    }
}
