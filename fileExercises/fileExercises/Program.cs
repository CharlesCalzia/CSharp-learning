using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace fileExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> twoWordStations = new List<string>() { "Charing Cross", "Clapham Common", "Golders Green", "Seven Sisters", "Sloane Square" };

            Debug.Assert(stationsShareNoLetters("Mackerel") == "St. John's Wood");
            Debug.Assert(stationsShareNoLetters("Piranha") == "Stockwell");
            Debug.Assert(stationsShareNoLetters("Sturgeon") == "Balham");
            Debug.Assert(stationsShareNoLetters("Bacteria") == "none");
            
            Debug.Assert(listEqual(twoWords() , twoWordStations)==true);

            Console.WriteLine(displayFile());

            freqAnalysis();
        }
        static bool listEqual(List<string> list1, List<string> list2)
        {
            foreach (string i in list1)
            {
                if (!list2.Contains(i))
                {
                    return false;
                }
            }
            foreach (string i in list2)
            {
                if (!list1.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }

        static string stationsShareNoLetters(string word1, string fileName="stations.txt")
        {
            string word = word1.ToLower();
            bool exists = File.Exists(fileName);
            if (exists)
            {
                string data = File.ReadAllText(fileName);
                

                foreach(string line in data.Split("\n"))
                {
                    bool found = true;
                    foreach (char letter in line.Split(",")[0].ToLower())
                    {
                        if (word.Contains(letter)){
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        return line.Split(",")[0];
                    }
                }
                return "none";

            }
            else
            {
                Console.WriteLine("Error, file not found");
                return "none";
            }
        }
        static List<string> twoWords(string fileName = "stations.txt")
        {
            bool exists = File.Exists(fileName);

            List<string> stations = new List<string>();
            if (exists)
            {
                string data = File.ReadAllText(fileName);


                foreach (string line in data.Split("\n"))
                {
                    string stationName = line.Split(",")[0];
                    List<string> splitName = (stationName.Split(" ")).ToList();
                    if(splitName.Count==2 && splitName[0][0] == splitName[1][0])
                    {
                        stations.Add(stationName);
                    }
                    
                }
                return stations;

            }
            else
            {
                Console.WriteLine("Error, file not found");
                return stations;
            }
        }
        static string displayFile(string fileName = "thirty-nine-steps.txt")
        {
            bool exists = File.Exists(fileName);

            if (exists)
            {
                string data = File.ReadAllText(fileName);

                string formatted = Regex.Replace(data.ToLower(), @"[^\w\d\s]", "").Replace("\n", String.Empty);

                
                return String.Join(" ", (formatted.Split(" ")).OrderBy(x => x).ToList());

            }
            else
            {
                Console.WriteLine("Error, file not found");
                return "";
            }
        }
        static object freqAnalysis(string fileName = "thirty-nine-steps.txt")
        {
            bool exists = File.Exists(fileName);
            Dictionary<string, int> freqDict = new Dictionary<string, int>();
            if (exists)
            {
                string data = File.ReadAllText(fileName);

                string formatted = Regex.Replace(data.ToLower(), @"[^\w\d\s]", "").Replace("\n", String.Empty);

                foreach (string word in formatted.Split(" "))
                {
                    if (!freqDict.ContainsKey(word))
                    {
                        freqDict.Add(word, 0);
                    }
                    freqDict[word]++;
                }
                return freqDict;
            }
            else
            {
                Console.WriteLine("Error, file not found");
                return freqDict;
            }
        }
    }
}
