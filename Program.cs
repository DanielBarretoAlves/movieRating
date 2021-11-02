using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bulkloader bulk = new Bulkloader();
            string path = @"input\ratings.csv";
            int[] data = bulk.readFile(path,1);

            data = bulk.bubble(data);
            Console.WriteLine("Fim");
        }
    }
}