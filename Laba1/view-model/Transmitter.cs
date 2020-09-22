using System;
using System.Collections.Generic;
using System.Text;
using Laba1.model;
using Laba1.view;

namespace Laba1.view_model
{
    abstract class Transmitter
    {
        private static Repres writter;
        public static uint take = 0;

        public static void init(string pathToBook = null, string pathToInput = null, string pathToOutput = null)
        {
            writter = new Repres(pathToBook, pathToInput, pathToOutput);
            message("Врайтер создался");
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
            writter.refreshOut(path);
        }

        public static void setPathToInp(string path)
        {
            writter.refresInp(path);
        }

        public static void setPathToBook(string path)
        {
            writter.refreshBook(path);
        }

        public static void startEncrypt()
        {
            Crypt.createDict();
            Crypt.encryptFile();
        }

        public static void startAnalys()
        {
            foreach (KeyValuePair<Place, int> keyValue in Analyst.FreqAnal())
                Console.WriteLine(keyValue.Key.row + "," + keyValue.Key.colomn + " : " + keyValue.Value + " (" +
                                  keyValue.Value * 100 / take + "%)");
            take = 0;
        }

        public static void startDecrypt()
        {
            Crypt.decryptoFile();
        }

        public static void finish()
        {
            writter.finish();
        }
        public static void showLine(string line)
        {
            writter.writeResultLine(line);
        }

        public static void show(string result)
        {

        }

        public static string getBook()
        {
            return writter.getBook();
        }

        public static string getLine()
        {
            return writter.getLine();
        }

        public static string getFile()
        {
            return writter.getFile();
        }

        public static string getFileLine()
        {
            return writter.getFileLine();
        }
    }
}
