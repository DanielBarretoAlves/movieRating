using System;
using System.Collections.Generic;
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
                escolha = int.Parse(Console.ReadLine());
                Console.WriteLine("Is this the Movie? " + title[escolha]);
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
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
            Bulkloader bulk = new Bulkloader();
            //Call Path Files
            string path1 = @"input\ratingsF1.csv";
            string path2 = @"input\movies.csv";

            // Get Data From CSV Files
            Console.WriteLine("Loading Files..");
            int[] rMovieID = bulk.readFileInt(path1, 1);
            float[] rating = bulk.readFileFloat(path1, 2);
            int[] movieId = bulk.readFileInt(path2, 0);
            int[] mlsec = bulk.readFileInt(path1, 3);
            string[] title = bulk.readFileString(path2, 1);
            Console.WriteLine("Load Files Complete!");


            Console.WriteLine("Sorting Data..");


            //sELECTION sort -------------------------------------------------------
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
            Console.WriteLine("Data Sorted Successfully!");



            int escolha = menu(title);

            //Adaptar para Rodar em Array
            float notas = 0;
            int qtd = 0;
            if (escolha != 0)
            {
                escolha--;
            }
            int test = escolha;

            Console.WriteLine("Calc Reviews..");
            for (int i = 0; i < rMovieID.Length; i++)
            {

                if (rMovieID[i] == movieId[test])
                {
                    escolha = test;
                    notas += rating[i];
                    qtd++;

                }

            }
            Console.WriteLine(qtd + " Reviews Found!");
            Console.WriteLine("===========================================");
            float some = notas/qtd;
            Console.WriteLine("Avarage Review for the movie:  - " + some);
            Console.WriteLine("===========================================");



        }
    }
}

