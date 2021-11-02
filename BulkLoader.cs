using System.IO;
namespace MyApp
{
    class Bulkloader
    {


        public int[] readFile(string path, int escolha)
        {
            long size = getFileSize(path);
            int[] data = new int[size];
            using (var reader = new StreamReader(path))
            {

                for (int i = 0; i < size; i++)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    data[i] = int.Parse(values[escolha]);
                }
                Console.WriteLine("foi");


            }
            return data;
        }



        public long getFileSize(string path)
        {

            long length = File.ReadLines(path).Count();
            Console.WriteLine("Size: " + length);
            return length;

        }



        public int[]bubble(int[] data)
        {

            int temp = 0;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        temp = data[j + 1];
                        data[j + 1] = data[j];
                        data[j] = temp;
                    }
                }
                // Console.Write("{0} ", data[i]);
            }
            return data;
        }
        // public String[] readFile2(string path, int escolha)
        // {
        //     long size = getFileSize(path);
        //     int[] data = new int[size];
        //     int temp = 0;
        //     using (var reader = new StreamReader(path))
        //     {

        //         for (int write = 0; write < data.Length; write++)
        //         {
        //             for (int sort = 0; sort < data.Length - 1; sort++)
        //             {
        //                 if (data[sort] > data[sort + 1])
        //                 {
        //                     temp = data[sort + 1];
        //                     data[sort + 1] = data[sort];
        //                     data[sort] = temp;
        //                 }
        //             }
        //         }


        //     }
        //     return data;
        // }















    }

}