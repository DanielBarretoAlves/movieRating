using System.IO;
using System.Linq;

namespace MyApp
{
    class Bulkloader
    {


        public int[] readFileInt(string path, int escolha)
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


            }
            return data;
        }

        public float[] readFileFloat(string path, int escolha)
        {
            long size = getFileSize(path);
            float[] data = new float[size];
            using (var reader = new StreamReader(path))
            {

                for (int i = 0; i < size; i++)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    data[i] = float.Parse(values[escolha]);
                }


            }
            return data;
        }

        public string[] readFileString(string path, int escolha)
        {
            long size = getFileSize(path);
            string[] data = new string[size];
            using (var reader = new StreamReader(path))
            {

                for (int i = 0; i < size; i++)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    data[i] = values[escolha];
                }


            }
            return data;
        }


        public long getFileSize(string path)
        {

            long length = File.ReadLines(path).Count();
            return length;

        }

        public int[] bubble(int[] arrInt)
        {
            int n = arrInt.Length;
            int temp = 0;
            for (int i = 0; i < n; i++)
            {
                for (int v = 1; v < (n - i); v++)
                {
                    if (arrInt[v - 1] < arrInt[v])
                    {
                        temp = arrInt[v - 1];
                        arrInt[v - 1] = arrInt[v];
                        arrInt[v] = temp;
                    }

                }
            }
            return arrInt;
        }


    }

}