using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MyApp
{

    public class Program
    {

        public static int menu(string[] title)
        {
            bool key = false;
            int escolha = 0;
            while (key != true)
            {
                Console.WriteLine("******************************************");
                Console.WriteLine("Select Movie ID:");
                Console.WriteLine("Ex: '5' Heat (1995)");
                Console.WriteLine("******************************************");
                Console.Write(": ");
                escolha = int.Parse(Console.ReadLine());
                Console.WriteLine("Is this the Movie? " + title[escolha]);
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
                Console.Write(": ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    key = true;
                }
            }


            
            return escolha;
        }




        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch(); 
            Bulkloader bulk = new Bulkloader();
            //Call Path Files
            string path1 = @"input\ratingsF1.csv";
            string path2 = @"input\movies.csv";

            // Get Data From CSV Files
            stopwatch.Start();
            Console.WriteLine("Loading Files..");
            int[] rMovieID = bulk.readFileInt(path1, 1);
            float[] rating = bulk.readFileFloat(path1, 2);
            int[] movieId = bulk.readFileInt(path2, 0);
            int[] mlsec = bulk.readFileInt(path1, 3);
            string[] title = bulk.readFileString(path2, 1);
            stopwatch.Stop();
            Console.WriteLine("Load Files Complete! | "+stopwatch.Elapsed+" Seconds!");

            stopwatch.Restart();
            Console.WriteLine("Sorting Data..");

            //Selection sort -------------------------------------------------------
            int min, aux;
            float auxRating;
            int auxmlSec;

            for (int i = 0; i < rMovieID.Length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < rMovieID.Length; j++)
                    if (rMovieID[j] < rMovieID[min])
                        min = j;

                if (min != i)
                {
                    aux = rMovieID[min];
                    rMovieID[min] = rMovieID[i];
                    rMovieID[i] = aux;
                    //----------------------
                    auxRating = rating[min];
                    rating[min] = rMovieID[i];
                    rating[i] = auxRating;
                    //----------------------
                    auxmlSec = mlsec[min];
                    mlsec[min] = mlsec[i];
                    mlsec[i] = auxmlSec;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Data Sorted Successfully! | "+stopwatch.Elapsed+" Seconds!");



            int escolha = menu(title);

            //Percorrer Array para encontrar e calcular todas reviews
            float notas = 0;
            int qtd = 0;
            if (escolha != 0)
            {
                escolha--;
            }
            int test = escolha;

            Console.WriteLine("Calc Reviews..");
            stopwatch.Restart();
            for (int i = 0; i < rMovieID.Length; i++)
            {

                if (rMovieID[i] == movieId[test])
                {
                    escolha = test;
                    notas += rating[i];
                    qtd++;

                }

            }
            stopwatch.Stop();
            Console.WriteLine(qtd + " Reviews Found! | " + stopwatch.Elapsed+ " Secconds!");
            Console.WriteLine("===========================================");
            float some = notas/qtd;
            Console.WriteLine("Avarage Review for the movie:  = " + some);
            Console.WriteLine("===========================================");



        }
    }
}

