using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;
using Laba1.view_model;

namespace Laba1.view
{
    class Repres
    {
        public string pathToBook { get; private set; }
        public string pathToInput { get; private set; }
        public string pathToOutput { get; private set; }
        private StreamReader book;
        private StreamReader ansver;
        private StreamWriter outpute;
        public Repres(string pathToBook = null, string pathToInput = null, string pathToOutput = null)
        {
            this.pathToBook = pathToBook;
            this.pathToInput = pathToInput;
            this.pathToOutput = pathToOutput;
        }

        public void refreshBook(string pathToBook)
        {
            this.pathToBook = pathToBook;
            book = new StreamReader(pathToBook);
        }

        public void refresInp(string pathToInp)
        {
            pathToInput = pathToInp;
            ansver = new StreamReader(pathToInp);
        }

        public void refreshOut(string pathToOut)
        { 
            pathToOutput = pathToOut;
            outpute = new StreamWriter(pathToOut);
        }

        public string getBook()
        {
            if (book == null)
            {
                try
                {
                    book = new StreamReader(pathToBook);
                }
                catch (Exception e)
                {
                    Transmitter.problem(e.ToString());
                    throw;
                }
            }

            return book.ReadToEnd();
        }

        public string getLine()
        {
            if (book == null)
            {
                try
                {
                    book = new StreamReader(pathToBook);
                }
                catch (Exception e)
                {
                    Transmitter.problem(e.ToString());
                    throw;
                }
            }

            return book.ReadLine();
        }

        public string getFile(string pathToFile = null)
        {
            if (pathToFile != null)
                pathToInput = pathToFile;

            if (ansver == null)
            {
                try
                {
                    ansver = new StreamReader(pathToInput);
                }
                catch (Exception e)
                {
                    Transmitter.problem(e.ToString());
                    throw;
                }
            }
            return ansver.ReadToEnd();
        }

        public string getFileLine(string pathToFile = null)
        {
            if (pathToFile != null)
                pathToInput = pathToFile;

            if (ansver == null)
            {
                try
                {
                    ansver = new StreamReader(pathToInput);
                }
                catch (Exception e)
                {
                    Transmitter.problem(e.ToString());
                    throw;
                }
            }

            return ansver.ReadLine();
        }

        public void writeResultLine(string line)
        {
            if (outpute == null)
            {
                try
                {
                    outpute = new StreamWriter(pathToOutput);
                }
                catch (Exception e)
                {
                    Transmitter.problem(e.ToString());
                    throw;
                }
            }

            outpute.WriteLine(line);
            Console.WriteLine(line);
        }

        public void finish()
        {
            if (book != null)
            {
                book.Close();
                book = null;
            }

            if (ansver != null)
            {
                ansver.Close();
                ansver = null;
            }

            if (outpute != null)
            {
                outpute.Close();
                outpute = null;
            }
        }
    }
}
