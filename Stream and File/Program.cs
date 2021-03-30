using System;
using System.IO;
using System.Text;

namespace Stream_and_File
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Работа с файлами.
            // Открыть файл.
            // Прочесть/Записать в файл.
            // Закрыть.

            Console.OutputEncoding = Encoding.Unicode/*UTF8 ASCI*/;

            Console.WriteLine("Введите ФИО");
            string Full_Name = Console.ReadLine();

            using (var sw = new StreamWriter("test.txt", true, Encoding.UTF8/*ASCII*/))  // Позволяет объявить объект потока.
            {                             
                sw.WriteLine($"Hello, {Full_Name}");
            }

            using (var sr = new StreamReader("test.txt", Encoding.UTF8 /*ASCII UTF8*/))  // Позволяет считать объект потока.
            {
                while(!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine() + " (Конец строки)");
                }

                sr.DiscardBufferedData(); // Очищает буфер для объекта StreamReader.
                sr.BaseStream.Seek(0, SeekOrigin.Begin); // Обращаемся к основному потоку 
                                                         // и вызываем у него метод перехода в начало.
                var test = sr.ReadToEnd();
                Console.WriteLine(test);
            }
            // P.S. При использовании using, не приходится закрывать поток в ручную, 
            // т.к. за тебя это сделает система.

            Console.ReadLine();
            #endregion
        }
    }
}
