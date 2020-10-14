using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

Console.SetWindowSize(150, 50);

string groupingCol = args[0];
string numericCol = args[1];
int maxGroups = int.Parse(args[2]);

string s = Console.ReadLine();
string[] columns = s.Split("\t");

Dictionary<string, int> dictionary = new Dictionary<string, int>();
while ((s = Console.ReadLine()) != null)
{
    string[] elements = s.Split("\t");
    string groupingVal = elements[Array.IndexOf<string>(columns, groupingCol)];
    int numericVal = int.Parse(elements[Array.IndexOf<string>(columns, numericCol)]);

    if (dictionary.Keys.Contains(groupingVal))
    {
        dictionary[groupingVal] += numericVal;
    }
    else
    {
        dictionary.Add(groupingVal, numericVal);
    }
}

dictionary = dictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
int maxValue = dictionary.Max(x => x.Value);

int i = 0;
Console.ForegroundColor = ConsoleColor.Green;
foreach (KeyValuePair<string, int> pair in dictionary)
{
    if (i == maxGroups) break; 
    int barLength = (int)Math.Ceiling(pair.Value * 100.0 / maxValue);
    Console.Write(string.Format("{0,40} | ", pair.Key));
    Console.BackgroundColor = ConsoleColor.Magenta;
    Console.WriteLine(new string(' ', barLength));
    Console.BackgroundColor = ConsoleColor.Black;
    i++;
}