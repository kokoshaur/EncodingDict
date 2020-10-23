using System;
using System.Collections.Generic;
using Laba1.model;
using Laba1.view;

namespace Laba1.view_model
{
    abstract class Transmitter
    {
        public static int blockSize;
        public static fileType type;

        private static BitsFileShower bitsWritter;
        private static FileShower writter;
        private static ICrypto crypto;
        public static uint take = 0;

        public static void init(ICrypto methodCrypto, fileType type, string pathToInput = null, string pathToOutput = null, string pathToBook = null)
        {
            Transmitter.type = type;
            bitsWritter = new BitsFileShower(pathToInput, pathToOutput);
            //writter = new FileShower(secondPath, pathToInput, pathToOutput);
            crypto = methodCrypto;
        }

        public static void message(string text)
        {
            Console.WriteLine(text);
        }
        public static void problem(string message)
        {
            Console.WriteLine(message);
        }

        public static void setPathToOut(string path)
        {
            bitsWritter.pathToOut = path;
            //writter.refreshOut(path);
        }

        public static void setPathToInp(string path)
        {
            bitsWritter.pathToFile = path;
            //writter.refresInp(path);
        }

        public static void setPathToBook(string path)
        {
            writter.refreshSecondSubj(path);
        }

        public static void startEncrypt(byte pos = 0)
        {
            crypto.init();
            crypto.encryptFile(pos);
        }

        public static void startAnalys(IAnalyst anal)
        {
            foreach (KeyValuePair<Place, int> keyValue in anal.FreqAnal())
                Console.WriteLine(keyValue.Key.row + "," + keyValue.Key.colomn + " : " + keyValue.Value + " (" +
                                  keyValue.Value * 100 / take + "%)");
            take = 0;
        }

        public static void startAnalys2(IAnalyst anal)
        {

        }

        public static void startDecrypt()
        {
            crypto.decryptoFile();
        }

        public static void finish()
        {
            writter.finish();
        }

        public static string getCryptoLine()
        {
            return writter.getCryptoLine();
        }

        public static string getBlock()
        {
            return writter.getBlock();
        }

        public static byte[] getNextBlock()
        {
            return bitsWritter.getNextBlock();
        }

        public static void showLine(string line)
        {
            writter.writeResultLine(line);
        }
        public static void writeBlock(byte[] block)
        {
            bitsWritter.writeBlock(block);
        }

        public static void BitsFinish()
        {
            bitsWritter.finish();
        }

        public static void itIsLastBlock(byte[] block)
        {
            crypto.itIsLast(block);
        }
    }
}
