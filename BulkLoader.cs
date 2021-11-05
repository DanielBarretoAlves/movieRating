using System.IO;
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
            }
            return data;
        }
        















    }

}