using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Laba1.view;
using Laba1.view_model;

namespace Laba1.model
{
    struct Place
    {
        public Place(int row, int colomn)
        {
            this.row = row;
            this.colomn = colomn;
        }
        public int row;
        public int colomn;
    }
    abstract class Crypt
    {
        private static Dictionary<char, List<Place>> dictionary = new Dictionary<char, List<Place>>();

        public static void createDict()
        {
            string line;
            int row = 1;
            while ((line = Transmitter.getLine()) != null)
            {
                int column = 1;

                foreach (char symbol in line)
                {
                    try
                    {
                        if (dictionary[symbol].Count < 10)
                            dictionary[symbol].Add(new Place(row, column));
                    }
                    catch (Exception e)
                    {
                        dictionary.Add(symbol, new List<Place>());
                        dictionary[symbol].Add(new Place(row, column));
                    }

                    column++;
                }

                row++;
            }
        }

        public static void encryptFile()
        {
            string line;
            Random rnd = new Random();

            while ((line = Transmitter.getFileLine()) != null)
            {
                StringBuilder ansver = new StringBuilder();
                foreach (char symbol in line)
                {
                    ansver.Append("[");

                    Place crypt = dictionary[symbol][rnd.Next(0, dictionary[symbol].Count)];

                    ansver.Append(crypt.row);
                    ansver.Append("/");
                    ansver.Append(crypt.colomn);
                    ansver.Append("]");
                }

                Transmitter.showLine(ansver.ToString());
            }
            Transmitter.finish();
        }

        public static void decryptoFile()
        {
            string line;

            while ((line = Transmitter.getFileLine()) != null)
            {
                StringBuilder ansver = new StringBuilder();
                StringBuilder sum1;
                StringBuilder sum2;

                int i = 0;

                while (line.Length > i)
                {
                    sum1 = new StringBuilder();
                    sum2 = new StringBuilder();
                    i++;
                    while (line[i] != '/')
                    {
                        sum1.Append(line[i]);
                        i++;
                    }

                    i++;
                    while (line[i] != ']')
                    {
                        sum2.Append(line[i]);
                        i++;
                    }

                    ansver.Append(searchSymbol(new Place(Convert.ToInt32(sum1.ToString()),
                        Convert.ToInt32(sum2.ToString()))));
                    i++;
                }

                Transmitter.showLine(ansver.ToString());
            }
            Transmitter.finish();
        }

        private static char searchSymbol(Place crypt)
        {
            foreach (KeyValuePair<char, List<Place>> keyValue in dictionary)
            {
                if (keyValue.Value.IndexOf(crypt) != -1)
                    return keyValue.Key;
            }

            return ' ';
        }
    }
}
