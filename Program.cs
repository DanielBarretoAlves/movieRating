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
            string path1 = @"input\ratingsF1.csv";
            string path2 = @"input\movies.csv";
            int[] rMovieID = bulk.readFileInt(path1,1);
            float[] rating = bulk.readFileFloat(path1,2);
            int[] movieId = bulk.readFileInt(path2,0);
            int[] mlsec = bulk.readFileInt(path1,3);
            string[] title = bulk.readFileString(path2,1);
            // string[] genres = bulk.readFileString(path2,2);


            Console.WriteLine("Lendo Arquivos Aguarde..");

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


            Console.WriteLine("Selecione o ID de um Filme:");
            int escolha = int.Parse(Console.ReadLine());
            Console.WriteLine("Filme: "+title[escolha]);
            Console.WriteLine("escolha fora do loop"+escolha);
            float notas = 0;
            int qtd =0;
            for (int i = 0; i < rMovieID.Length; i++)
            {
                // Console.WriteLine("Entrou no Loop");
                // Console.WriteLine("escolha dentro do loop"+escolha);
                if (rMovieID[i] == movieId[escolha-1])
                {
                    Console.WriteLine("escolha dentro do if"+escolha);
                    notas+=rating[i];
                    qtd++;
                    Console.WriteLine("-- "+rMovieID[i]);
                    Console.WriteLine("---"+movieId[escolha]);
                    Console.WriteLine("-- "+rating[i]);
                    Console.WriteLine(title[rMovieID[i]]);
                    Console.WriteLine("escolhido: " + title[movieId[escolha]]);
                    Console.WriteLine("movie: "+ movieId[i]+" - rMovie: "+rMovieID[i]);
                }
                
            }
            Console.WriteLine("Media de Notas Para o Filme: "+title[2]+" - "+notas/qtd);
            Console.WriteLine("- "+rMovieID[145]);


            
        }
    }
}


//1,1,4.0,964982703