using System.IO;
namespace MyApp
{
    class Bulkloader
    {


        public String[] readFile(string path, int escolha)
        {
            long size = getFileSize(path);
            String[] data = new String[size];
            using (var reader = new StreamReader(path))
            {

                for (int i = 0; i < size; i++)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Console.WriteLine(i+ "- Value: " + values[escolha]);
                    Console.WriteLine("------------------------------------------------------");
                    data[i] = values[escolha];
                }


            }
            return data;
        }



        public long getFileSize(string path)
        {

            long length = File.ReadLines(path).Count();
            Console.WriteLine("Size: " + length);
            return length;

        }


    }

}