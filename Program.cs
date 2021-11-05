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
                Console.WriteLine("Select Movie ID:");
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


            //bubble sort -------------------------------------------------------
            int temp = 0;
            int tempSec = 0;
            float tempRating = 0;

            for (int i = 0; i < rMovieID.Length; i++)
            {
                for (int j = 0; j < rMovieID.Length - 1; j++)
                {
                    if (rMovieID[j] > rMovieID[j + 1])
                    {

                        temp = rMovieID[j + 1];
                        rMovieID[j + 1] = rMovieID[j];
                        rMovieID[j] = temp;
                        //------------------------
                        tempRating = rating[j + 1];
                        rating[j + 1] = rating[j];
                        rating[j] = tempRating;
                        //------------------------
                        tempSec = mlsec[j + 1];
                        mlsec[j + 1] = mlsec[j];
                        mlsec[j] = tempSec;

                    }
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
            Console.WriteLine(qtd + " Review Found");
            Console.WriteLine("===========================================");
            Console.WriteLine("Avarage Review for the movie:  - " + notas / qtd);
            Console.WriteLine("===========================================");



        }
    }
}

