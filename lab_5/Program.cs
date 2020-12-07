using System;
using System.Text;
using System.IO;



namespace Task_5
{
    class A_elem
    {
        private A_elem elem;
        public int Elem
        {
            get
            {
                return Elem;
            }
            private set
            {
                Elem = value;
            }

        }

    }

    class Fileprogram
    {
        public static double[] ReadFileAndGetInArray(string path)
        {
            string[] text = File.ReadAllText(path).Split(", ");
            double[] array = new double[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    array[i] = Convert.ToDouble(text[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не можна прочитати файл:{ex.Message}");
                    System.Diagnostics.Process.GetCurrentProcess().Kill(); /* приложение убивается и нормально запускается по новой */
                }
            }
            return array;
        }

        public static void NegativeToSquare(ref double[] x) /*передача параметра по ссылке*/
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = (x[i] < 0) ? x[i] * x[i] : x[i];
            }
            foreach (int i in x)
                Console.WriteLine($"{i}");

        }

        public static void Transformation(double[] x, double[] y, ref double[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = x[i] + y[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fileprogram fileprogram = new Fileprogram();

            Console.OutputEncoding = Encoding.UTF8; /*Возвращает или задает кодировку, которую консоль использует для записи вывода.*/
            Console.InputEncoding = Encoding.UTF8; /*Получает или задает кодировку, которую консоль использует для чтения ввода.*/

            string X = @"D:\second course\oop\lab_5/x.txt";
            string Y = @"D:\second course\oop\lab_5/y.txt";
            string Z = @"D:\second course\oop\lab_5/z.txt";

            if (!File.Exists(X))
            {
                Console.WriteLine($"{Path.GetFileName(X)} не існує");
                return;
            }
            else if (new FileInfo(X).Length == 0)
            {
                Console.WriteLine($"{Path.GetFileName(X)} пустий");
                return;
            }

            else if (!File.Exists(Y))
            {
                Console.WriteLine($"{Path.GetFileName(Y)} не існує");
                return;
            }
            else
            {
                if (new FileInfo(Y).Length == 0)
                {
                    Console.WriteLine($"{Path.GetFileName(Y)} пустий");
                    return;
                }
            }
            double[] x = Fileprogram.ReadFileAndGetInArray(X); /*Открывает текстовый файл, считывает весь текст файла в строку и затем закрывает файл.*/
            double[] y = Fileprogram.ReadFileAndGetInArray(Y);
            double[] z = new double[x.Length];
            Fileprogram.NegativeToSquare(ref x);
            Fileprogram.Transformation(x, y, ref z);

            string text = string.Join(",", z);

            File.WriteAllText(Z, text);
            Console.WriteLine($"У файл {Path.GetFileName(Z)} буде записано: {text}");
        }

    }
}