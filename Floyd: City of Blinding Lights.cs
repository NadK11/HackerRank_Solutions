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

public class Solution
{
    public static int[,] adjMatrix;
    
    public static void Main(string[] args)
    {
        var input = Console.In;
        var firstLine = input.ReadLine().Split().Select(int.Parse).ToArray();
        int numNodes = firstLine[0];
        int numConnections = firstLine[1];

        adjMatrix = new int[numNodes + 1, numNodes + 1];

        for (int i = 1; i <= numNodes; i++)
        {
            for (int j = 1; j <= numNodes; j++)
            {
                if (i == j)
                    adjMatrix[i, j] = 0;
                else
                    adjMatrix[i, j] = 100000;
            }
        }

        for (int i = 0; i < numConnections; i++)
        {
            var line = input.ReadLine().Split().Select(int.Parse).ToArray();
            int n1 = line[0];
            int n2 = line[1];
            int c = line[2];
            adjMatrix[n1, n2] = c;
        }

        for (int i = 1; i <= numNodes; i++)
        {
            for (int j = 1; j <= numNodes; j++)
            {
                for (int k = 1; k <= numNodes; k++)
                {
                    adjMatrix[j, k] = Math.Min(adjMatrix[j, k], adjMatrix[j, i] + adjMatrix[i, k]);
                }
            }
        }

        int numQueries = int.Parse(input.ReadLine());
        for (int i = 0; i < numQueries; i++)
        {
            var query = input.ReadLine().Split().Select(int.Parse).ToArray();
            int n1 = query[0];
            int n2 = query[1];

            if (adjMatrix[n1, n2] == 100000)
                Console.WriteLine("-1");
            else
                Console.WriteLine(adjMatrix[n1, n2]);
        }
    }
}
