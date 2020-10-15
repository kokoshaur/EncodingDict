using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;
using Laba1.view_model;

namespace Laba1.view
{
    class FileShower
    {
        public string secondPath { get; private set; }
        public string pathToInput { get; private set; }
        public string pathToOutput { get; private set; }
        private StreamReader book;
        private StreamReader ansver;
        private StreamWriter outpute;
        public FileShower(string secondPath = null, string pathToInput = null, string pathToOutput = null)
        {
            this.secondPath = secondPath;
            this.pathToInput = pathToInput;
            this.pathToOutput = pathToOutput;
        }

        public void refreshSecondSubj(string pathToSubj)
        {
            secondPath = pathToSubj;
            book = new StreamReader(pathToSubj);
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

        public string getCryptoLine()
        {
            if (book == null)
            {
                try
                {
                    book = new StreamReader(secondPath);
                }
                catch (Exception e)
                {
                    Transmitter.problem(e.ToString());
                    throw;
                }
            }

            return book.ReadLine();
        }

        public string getBlock()
        {
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
