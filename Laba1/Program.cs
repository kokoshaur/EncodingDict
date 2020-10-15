using System;
using Laba1.model;
using Laba1.model.Subj;
using Laba1.view_model;

namespace Laba1
{
    enum fileType
    {
        TXT = 0,
        BMP = 136
    }
    class Program
    {
        static void Main(string[] args)
        {
            Laba2();
        }

        private static void Laba1() //Вариант 16. Реализовать алгоритм книжного шифрования. Провести его частотный анализ.
        {
            Transmitter.init(new booksCrypto(), fileType.TXT, "../../../Example/File.txt", "../../../Example/Result.txt", "../../../Example/Book.txt");

            Transmitter.startEncrypt();

            Transmitter.setPathToInp("../../../Example/Result.txt");
            Transmitter.setPathToOut("../../../Example/DecryptoResult.txt");

            Transmitter.startDecrypt();

            Transmitter.startAnalys();
        }

        private static void Laba2() //Вариант 18. Реализовать алгоритм шифрования SAFER+.
        {
            byte[] key = new byte[128];
            byte[] IV = new byte[128];
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = (byte) (i + 100);
                IV[i] = (byte) (i + 100);
            }

            string type = ".bmp";
            Transmitter.init(new SAFERCrypto(key, IV), fileType.BMP, "../../../Example/File" + type, "../../../Example/Result" + type);

            Transmitter.startEncrypt();

            Transmitter.setPathToInp("../../../Example/Result" + type);
            Transmitter.setPathToOut("../../../Example/DecryptoResult" + type);

            Transmitter.startDecrypt();
        }
    }
}
