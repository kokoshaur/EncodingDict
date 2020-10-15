using System;
using System.Collections.Generic;
using System.Text;
using Laba1.view_model;

namespace Laba1.model
{
    abstract class AnalystLaba1
    {
        public static Dictionary<Place, int> FreqAnal()
        {
            Dictionary<Place, int> asnver = new Dictionary<Place, int>();

            string line;

            while ((line = Transmitter.getBlock()) != null)
            {
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

                    try
                    {
                        asnver[new Place(Convert.ToInt32(sum1.ToString()),
                            Convert.ToInt32(sum2.ToString()))]++;
                    }
                    catch (Exception e)
                    {
                        asnver.Add(new Place(Convert.ToInt32(sum1.ToString()),
                            Convert.ToInt32(sum2.ToString())), 1);
                    }
                    i++;
                    Transmitter.take++;
                }

            }
            Transmitter.finish();

            return asnver;
        }
    }
}
