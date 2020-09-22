using System;
using Laba1.view_model;

//Вариант 16. Реализовать алгоритм книжного шифрования. Провести его частотный анализ.


namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Transmitter.init("../../../Example/Book.txt", "../../../Example/File.txt", "../../../Example/Result.txt");

            Transmitter.startEncrypt();

            Transmitter.setPathToInp("../../../Example/Result.txt");
            Transmitter.setPathToOut("../../../Example/DecryptoResult.txt");

            Transmitter.startDecrypt();

            Transmitter.startAnalys();

            Console.ReadKey();
        }
    }
}
