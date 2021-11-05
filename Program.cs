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
            //Call Path Files
            string path1 = @"input\ratingsF1.csv";
            string path2 = @"input\movies.csv";

            // Get Data From CSV Files
            Console.WriteLine("Loading Files..");
            int[] rMovieID = bulk.readFileInt(path1,1);
            float[] rating = bulk.readFileFloat(path1,2);
            int[] movieId = bulk.readFileInt(path2,0);
            int[] mlsec = bulk.readFileInt(path1,3);
            string[] title = bulk.readFileString(path2,1);
            Console.WriteLine("Load Files Complete!");
            // string[] genres = bulk.readFileString(path2,2);


            Console.WriteLine("Sorting Data..");

            // movieID = bulk.bubble(movieID);
            //bubble sort -------------------------------------------------------
            int temp = 0;
            int tempSec =0;
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


            Console.WriteLine("Select Movie ID:");
            int escolha = int.Parse(Console.ReadLine());
            Console.WriteLine("Movie: "+title[escolha]);
            float notas = 0;
            int qtd =0;
            
            //Adaptar para Rodar em Array
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
                    notas+=rating[i];
                    qtd++;
                    
                }
                
            }
            Console.WriteLine(qtd+" Review Found");
            Console.WriteLine("===========================================");
            Console.WriteLine("Avarage Review for the movie:  - "+notas/qtd);
            Console.WriteLine("===========================================");


            
        }
    }
}


//1,1,4.0,964982703