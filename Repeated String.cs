using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static long repeatedString(string s, long n)
    {
        long countAInS = s.Count(c => c == 'a');
        
        long fullRepetitions = n / s.Length;
        
        long totalA = countAInS * fullRepetitions;

        long remainingChars = n % s.Length;
        for (int i = 0; i < remainingChars; i++)
        {
            if (s[i] == 'a')
                totalA++;
        }
        
        return totalA;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
